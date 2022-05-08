using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace AutoKey
{
    public partial class AutoWinWindow : Form
    {
        // Imports
        // ---------------------------------
        #region NativeImports
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        // Related to the imports
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        private readonly LowLevelKeyboardProc llKeyProcess = ProcessEvent;
        private static IntPtr hhook = IntPtr.Zero;


        // Internals
        // -------------------------------------

        public static bool IsEnabled { get; private set; } = true;
        public static List<string> autoWindow { get; private set; } = new List<string>();

        private NotifyIcon trayIcon;


        /// <summary>
        /// Ctor
        /// </summary>
        public AutoWinWindow()
        {
            InitializeComponent();

            // Configure Keyboard hook
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, llKeyProcess, LoadLibrary("User32"), 0);

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = this.Icon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Maximize", RestoreWindow_Click)
                ,new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            // Set the Event Listeners
            this.FormClosing += AutoWinWindow_FormClosing;
            this.Load += AutoWinWindow_Load;
            ApplicationListBox.TextChanged += ApplicationListBox_TextChanged;

            // Update the instance settings
            configureVisualSettings();
            updateProtectionList();

        }

        // -----------------------------

        /// <summary>
        /// Watches and intercepts the windows messages
        /// </summary>
        public static IntPtr ProcessEvent(int code, IntPtr wParam, IntPtr lParam)
        {
            // Only watch for KeyDown event messages
            if (wParam == (IntPtr)WM_KEYDOWN)
            {
                // Get the virtual key code
                int vkCode = Marshal.ReadInt32(lParam);

                // Check if the keypress was Windows Key
                if (IsEnabled && vkCode == (int)Keys.LWin && IsProtectedWindow())
                    return (IntPtr)1;

                // Not the key we're watching ford
                return (IntPtr)0;
            }

            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

        // -----------------------------

        /// <summary>
        /// Customize some of the visual aspects
        /// </summary>
        void configureVisualSettings()
        {
            // Top bar
            MoveBar.FlatStyle = FlatStyle.Flat;
            MoveBar.FlatAppearance.BorderColor = BackColor;
            MoveBar.FlatAppearance.MouseOverBackColor = BackColor;
            MoveBar.FlatAppearance.MouseDownBackColor = BackColor;

            // Set form values
            this.RunAtStartupChkBox.Checked = Properties.Settings.Default.RunAtStartup;
            this.IsEnabledCheckbox.Checked = Properties.Settings.Default.IsEnabled;
            IsEnabled = this.IsEnabledCheckbox.Checked;
        }

        // ----------------------------

        /// <summary>
        /// Check if the foreground window is in the protected list
        /// </summary>
        internal static bool IsProtectedWindow()
        {
            // Get the list of active windows we're protecting
            foreach (var item in autoWindow)
            {
                // If the title matches, consider it protected
                if (GetActiveWindow().ToLowerInvariant().Contains(item.ToLowerInvariant()))
                    return true;
            }

            return false;
        }

        // ----------------------------

        /// <summary>
        /// Gets the foreground (Active) Window
        /// </summary>
        private static string GetActiveWindow()
        {
            // Create the container
            const int nChars = 256;
            StringBuilder sb = new StringBuilder(nChars);

            // Get the foreground window
            int handle = GetForegroundWindow();
            if (GetWindowText(handle, sb, nChars) > 0)
                return sb.ToString();

            // In case nothing was returned for some reason
            return string.Empty;
        }

        #region FormEvents

        // Whether this application is enabled
        private void EnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            IsEnabled = IsEnabledCheckbox.Checked;
            Properties.Settings.Default.IsEnabled = IsEnabled;
        }

        // ---------------------------------------

        // Custom window drag
        private void MoveBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // ---------------------------------------

        // Minimize to sytem tray
        void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // ---------------------------------------

        // Restore from system tray
        void RestoreWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        // ---------------------------------------

        // Exit application
        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        // ---------------------------------------

        private void RunAtStartupChkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Set the registry Key
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Flip it
            if (this.RunAtStartupChkBox.Checked)
                regKey.SetValue("AutoWin", Application.ExecutablePath);
            else
                regKey.DeleteValue("AutoWin", false);

            Properties.Settings.Default.RunAtStartup = this.RunAtStartupChkBox.Checked;
        }

        // ---------------------------------------

        /// <summary>
        /// Onload event when the form is created
        /// </summary>
        private void AutoWinWindow_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.StoredApplicationsList))
            {
                this.ApplicationListBox.Items.Clear();

                Properties.Settings.Default.StoredApplicationsList.Split(',')
                    .ToList()
                    .ForEach(item =>
                    {
                        this.ApplicationListBox.Items.Add(item);
                    });
            }

            Properties.Settings.Default.Reload();
            updateProtectionList();
        }

        // ---------------------------------------

        /// <summary>
        /// Called when the form is exiting
        /// </summary>
        private void AutoWinWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var applications = this.ApplicationListBox.Items.Cast<string>().ToArray();
            Properties.Settings.Default.StoredApplicationsList = string.Join(",", applications);
            Properties.Settings.Default.Save();
            trayIcon.Visible = false;
        }

        // ---------------------------------------

        /// <summary>
        /// Remove the selected index from the list
        /// </summary>
        private void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            if (this.ApplicationListBox.SelectedItem != null)
                this.ApplicationListBox.Items.RemoveAt(this.ApplicationListBox.SelectedIndex);

            // Make sure we're using the addition
            updateProtectionList();
        }

        // ---------------------------------------

        /// <summary>
        /// Add new Applications OnClick
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // If its blank, bail out
            if (string.IsNullOrEmpty(AdditionBox.Text))
                return;

            // Avoid duplicate entries
            bool hasEntry = false;
            for (int i = 0; i < ApplicationListBox.Items.Count; i++)
            {
                if (ApplicationListBox.Items.Contains(AdditionBox.Text))
                {
                    hasEntry = true;
                    break;
                }
            }

            // Entry didn't exist, lets add it
            if (!hasEntry)
                this.ApplicationListBox.Items.Add(AdditionBox.Text);

            // Make sure we're using the addition
            updateProtectionList();

            // Clear out the text box
            AdditionBox.Text = String.Empty;
        }

        #endregion

        // Random Stuff mostly
        #region MiscHelpers

        private void ApplicationListBox_TextChanged(object sender, EventArgs e)
        {
            updateProtectionList();
        }

        // ---------------------------------------

        private void updateProtectionList()
        {
            // Move our values from the UI to the static list so native functions can access it
            autoWindow.Clear();
            for (int i = 0; i < this.ApplicationListBox.Items.Count; i++)
            {
                autoWindow.Add((string)this.ApplicationListBox.Items[i]);
            }
        }

        #endregion

    }
}
