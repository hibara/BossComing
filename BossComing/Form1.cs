//---------------------------------------------------------------------- 
// "BossComing2"
// Copyright (C) 2017  Mitsuhiro Hibara
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.If not, see<http://www.gnu.org/licenses/>.
//---------------------------------------------------------------------- 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Gma.System.MouseKeyHook;
using Gma.System.MouseKeyHook.Implementation;
using System.Runtime.InteropServices;


namespace BossComing
{
  public partial class Form1 : Form
  {
    private IKeyboardMouseEvents m_Events;
    public DateTime NowDateTime;

    private bool fKeyModAlt = false;
    private bool fKeyModCtrl = false;
    private bool fKeyModShift = false;

    public static bool fMouseModLeft = false;
    public static bool fMouseModMiddle = false;
    public static bool fMouseModRight = false;

    // https://stackoverflow.com/questions/13139181/how-to-programmatically-set-the-system-volume
    private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
    private const int APPCOMMAND_VOLUME_UP = 0xA0000;
    private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
    private const int WM_APPCOMMAND = 0x319;

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    private void Mute()
    {
      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
    }
    private void VolDown()
    {
      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
    }
    private void VolUp()
    {
      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
    }

    public Form1()
    {
      InitializeComponent();
      SubscribeGlobal();

      // Load Options
      AppSettings.Instance.ReadOptions();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // Ajust invalid window form position
      this.Width = AppSettings.Instance.FormWidth;
      this.Height = AppSettings.Instance.FormHeight;

      //初期位置（スクリーン中央）
      //Default window position ( in screen center )
      if (AppSettings.Instance.FormLeft < 0)
      {
        this.Left = Screen.GetBounds(this).Width / 2 - this.Width / 2;
      }
      else
      {
        this.Left = AppSettings.Instance.FormLeft;
      }

      if (AppSettings.Instance.FormTop < 0)
      {
        this.Top = Screen.GetBounds(this).Height / 2 - this.Height / 2;
      }
      else
      {
        this.Top = AppSettings.Instance.FormTop;
      }

      pictureBox1.Dock = DockStyle.Fill;


      //-----------------------------------

      // http://stackoverflow.com/questions/15847637/take-screenshot-of-multiple-desktops-of-all-visible-applications-and-forms

      // Determine the size of the "virtual screen", which includes all monitors.
      int screenLeft = SystemInformation.VirtualScreen.Left;
      int screenTop = SystemInformation.VirtualScreen.Top;
      int screenWidth = SystemInformation.VirtualScreen.Width;
      int screenHeight = SystemInformation.VirtualScreen.Height;

      // Create a bitmap of the appropriate size to receive the screenshot.
      AppSettings.Instance.BitmapMainGazo = new Bitmap(screenWidth, screenHeight);

      // Draw the screenshot into our bitmap.
      using (Graphics g = Graphics.FromImage(AppSettings.Instance.BitmapMainGazo))
      {
        g.CopyFromScreen(screenLeft, screenTop, 0, 0, AppSettings.Instance.BitmapMainGazo.Size);
      }

      //string DesktopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      //string GazoFilePath = Path.Combine(DesktopPath, "test.jpg");
      // Do something with the Bitmap here, like save it to a file:
      //bmp.Save(GazoFilePath, ImageFormat.Jpeg);

      pictureBox1.Image = AppSettings.Instance.BitmapMainGazo;

      DisplayCurrentShortCut();

      NowDateTime = DateTime.Now;
      toolStripStatusLabelCaptureDateTime.Text = "Capture: " + NowDateTime.ToString();

    }

    private void DisplayCurrentShortCut()
    {
      string ShortCutString = "";
      if (AppSettings.Instance.KeyModAlt == true)
      {
        ShortCutString = "Alt + ";
      }
      if (AppSettings.Instance.KeyModCtrl == true)
      {
        ShortCutString = ShortCutString + "Ctrl + ";
      }
      if (AppSettings.Instance.KeyModShift == true)
      {
        ShortCutString = ShortCutString + "Shift + ";
      }
      if (AppSettings.Instance.MouseModLeft == true)
      {
        ShortCutString = ShortCutString + Properties.Resources.MouseModLeft + " + ";
      }
      if (AppSettings.Instance.MouseModMiddle == true)
      {
        ShortCutString = ShortCutString + Properties.Resources.MouseModMiddle + " + ";
      }
      if (AppSettings.Instance.MouseModRight == true)
      {
        ShortCutString = ShortCutString + Properties.Resources.MouseModRight + " + ";
      }

      switch (AppSettings.Instance.KeyString)
      {
        case "LeftClick":
          ShortCutString = ShortCutString + Properties.Resources.LeftClick;
          break;
        case "MiddleClick":
          ShortCutString = ShortCutString + Properties.Resources.MiddleClick;
          break;
        case "RightClick":
          ShortCutString = ShortCutString + Properties.Resources.RightClick;
          break;
        case "WheelUp":
          ShortCutString = ShortCutString + Properties.Resources.WheelUp;
          break;
        case "WheelDown":
          ShortCutString = ShortCutString + Properties.Resources.WheelDown;
          break;
        case "LeftDoubleClick":
          ShortCutString = ShortCutString + Properties.Resources.LeftDoubleClick;
          break;
        case "RightDoubleClick":
          ShortCutString = ShortCutString + Properties.Resources.RightDoubleClick;
          break;
        default:
          ShortCutString = ShortCutString + AppSettings.Instance.KeyString;
          break;
      }

      toolStripStatusLabelKeyString.Text = ShortCutString;

    }

    private void SubscribeApplication()
    {
      Unsubscribe();
      Subscribe(Hook.AppEvents());
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Unsubscribe();
    }

    private void SubscribeGlobal()
    {
      Unsubscribe();
      Subscribe(Hook.GlobalEvents());
    }

    private void Subscribe(IKeyboardMouseEvents events)
    {
      m_Events = events;
      m_Events.KeyDown += OnKeyDown;
      m_Events.KeyUp += OnKeyUp;
      m_Events.KeyPress += HookManager_KeyPress;

      m_Events.MouseUp += OnMouseUp;
      m_Events.MouseClick += OnMouseClick;
      m_Events.MouseDoubleClick += OnMouseDoubleClick;

      m_Events.MouseMove += HookManager_MouseMove;

      m_Events.MouseDragStarted += OnMouseDragStarted;
      m_Events.MouseDragFinished += OnMouseDragFinished;

      m_Events.MouseWheel += HookManager_MouseWheel;

      m_Events.MouseDown += OnMouseDown;
    }

    private void Unsubscribe()
    {
      if (m_Events == null) return;
      m_Events.KeyDown -= OnKeyDown;
      m_Events.KeyUp -= OnKeyUp;
      m_Events.KeyPress -= HookManager_KeyPress;

      m_Events.MouseUp -= OnMouseUp;
      m_Events.MouseClick -= OnMouseClick;
      m_Events.MouseDoubleClick -= OnMouseDoubleClick;

      m_Events.MouseMove -= HookManager_MouseMove;

      m_Events.MouseDragStarted -= OnMouseDragStarted;
      m_Events.MouseDragFinished -= OnMouseDragFinished;

      m_Events.MouseWheel -= HookManager_MouseWheel;

      m_Events.MouseDown -= OnMouseDown;

      m_Events.Dispose();
      m_Events = null;
    }


    // https://msdn.microsoft.com/ja-jp/library/system.windows.forms.keys(v=vs.110).aspx


    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      //Log(string.Format("KeyDown  \t\t {0}\n", e.KeyCode));

      if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu) // Altキー
      {
        fKeyModAlt = true;
      }
      else if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
      {
        fKeyModCtrl = true;
      }
      else if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
      {
        fKeyModShift = true;
      }

      if (CheckUserControlKey() == false) return;

      if ( CheckUserSpecifiedKey(e) == true)
      {
        ReplaceShowScreen();
      }

    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
      //Log(string.Format("KeyUp  \t\t {0}\n", e.KeyCode));
      if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
      {
        fKeyModAlt = false;
      }
      else if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
      {
        fKeyModCtrl = false;
      }
      else if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
      {
        fKeyModShift = false;
      }
    }

    private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
    {
      //Log(string.Format("KeyPress \t\t {0}\n", e.KeyChar));
    }

    private void HookManager_MouseMove(object sender, MouseEventArgs e)
    {
      //labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
      //Log(string.Format("MouseDown \t\t {0}\n", e.Button));

      if (e.Button == MouseButtons.Left)
      {
        fMouseModLeft = true;
      }
      else if (e.Button == MouseButtons.Middle)
      {
        fMouseModMiddle = true;
      }
      else if (e.Button == MouseButtons.Right)
      {
        fMouseModRight = true;
      }

      if (CheckUserControlKey() == false) return;

      switch (AppSettings.Instance.KeyString)
      {
        case "MiddleClick":
          if (e.Button == MouseButtons.Middle)
          {
            ReplaceShowScreen();
            return;
          }
          break;

        case "RightClick":
          if (e.Button == MouseButtons.Right)
          {
            ReplaceShowScreen();
            return;
          }
          break;
      }
      
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
      //Log(string.Format("MouseUp \t\t {0}\n", e.Button));

      if (e.Button == MouseButtons.Left)
      {
        fMouseModLeft = false;
      }
      else if (e.Button == MouseButtons.Middle)
      {
        fMouseModMiddle = false;
      }
      else if (e.Button == MouseButtons.Right)
      {
        fMouseModRight = false;
      }
    }

    private void OnMouseClick(object sender, MouseEventArgs e)
    {
      //Log(string.Format("MouseClick \t\t {0}\n", e.Button));
    }

    private void OnMouseDoubleClick(object sender, MouseEventArgs e)
    {
      //Log(string.Format("MouseDoubleClick \t\t {0}\n", e.Button));

      if (CheckUserControlKey() == false) return;

      switch (AppSettings.Instance.KeyString)
      {
        case "LeftDoubleClick":
          if (e.Button == MouseButtons.Left)
          {
            ReplaceShowScreen();
            return;
          }
          break;

        case "RightDoubleClick":
          if (e.Button == MouseButtons.Right)
          {
            ReplaceShowScreen();
            return;
          }
          break;
      }
      
    }

    private void OnMouseDragStarted(object sender, MouseEventArgs e)
    {
      //Log("MouseDragStarted\n");
    }

    private void OnMouseDragFinished(object sender, MouseEventArgs e)
    {
      //Log("MouseDragFinished\n");
    }

    private void HookManager_MouseWheel(object sender, MouseEventArgs e)
    {
      //labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
      if (e.Delta > 0)
      {
        if(AppSettings.Instance.KeyString == "WheelUp")
        {
          if (CheckUserControlKey() == true)
          {
            ReplaceShowScreen();
          }
        }
      }
      else
      {
        if (AppSettings.Instance.KeyString == "WheelDown")
        {
          if (CheckUserControlKey() == true)
          {
            ReplaceShowScreen();
          }
        }
      }
    }

    private void HookManager_MouseWheelExt(object sender, MouseEventExtArgs e)
    {
      //labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
      //Log("Mouse Wheel Move Suppressed.\n");
      //e.Handled = true;
    }

    //----------------------------------------------------------------------
    // Check control key
    //----------------------------------------------------------------------
    private bool CheckUserControlKey()
    {
      if (AppSettings.Instance.KeyModAlt == true)
      {
        if (fKeyModCtrl == false)
        {
          return (false);
        }
      }

      if (AppSettings.Instance.KeyModCtrl == true)
      {
        if (fKeyModCtrl == false)
        {
          return (false);
        }
      }

      if (AppSettings.Instance.KeyModShift == true)
      {
        if (fKeyModShift == false)
        {
          return (false);
        }
      }

      if (AppSettings.Instance.MouseModLeft == true)
      {
        if (fMouseModLeft == false)
        {
          return (false);
        }
      }

      if (AppSettings.Instance.MouseModMiddle == true)
      {
        if (fMouseModMiddle == false)
        {
          return (false);
        }
      }

      if (AppSettings.Instance.MouseModRight == true)
      {
        if (fMouseModRight == false)
        {
          return (false);
        }
      }

      return (true);

    }

    //----------------------------------------------------------------------
    // User specified key check
    //----------------------------------------------------------------------
    private bool CheckUserSpecifiedKey(KeyEventArgs e)
    {
      switch (AppSettings.Instance.KeyString)
      {
        case "F1":
          if (e.KeyCode == Keys.F1) return (true);
          break;
        case "F2":
          if (e.KeyCode == Keys.F2) return (true);
          break;
        case "F3":
          if (e.KeyCode == Keys.F3) return (true);
          break;
        case "F4":
          if (e.KeyCode == Keys.F4) return (true);
          break;
        case "F5":
          if (e.KeyCode == Keys.F5) return (true);
          break;
        case "F6":
          if (e.KeyCode == Keys.F6) return (true);
          break;
        case "F7":
          if (e.KeyCode == Keys.F7) return (true);
          break;
        case "F8":
          if (e.KeyCode == Keys.F8) return (true);
          break;
        case "F9":
          if (e.KeyCode == Keys.F9) return (true);
          break;
        case "F10":
          if (e.KeyCode == Keys.F10) return (true);
          break;
        case "F11":
          if (e.KeyCode == Keys.F11) return (true);
          break;
        case "F12":
          if (e.KeyCode == Keys.F12) return (true);
          break;
        case "A":
          if (e.KeyCode == Keys.A) return (true);
          break;
        case "B":
          if (e.KeyCode == Keys.B) return (true);
          break;
        case "C":
          if (e.KeyCode == Keys.C) return (true);
          break;
        case "D":
          if (e.KeyCode == Keys.D) return (true);
          break;
        case "E":
          if (e.KeyCode == Keys.E) return (true);
          break;
        case "F":
          if (e.KeyCode == Keys.F) return (true);
          break;
        case "G":
          if (e.KeyCode == Keys.G) return (true);
          break;
        case "H":
          if (e.KeyCode == Keys.H) return (true);
          break;
        case "I":
          if (e.KeyCode == Keys.I) return (true);
          break;
        case "J":
          if (e.KeyCode == Keys.J) return (true);
          break;
        case "K":
          if (e.KeyCode == Keys.K) return (true);
          break;
        case "L":
          if (e.KeyCode == Keys.L) return (true);
          break;
        case "M":
          if (e.KeyCode == Keys.M) return (true);
          break;
        case "N":
          if (e.KeyCode == Keys.N) return (true);
          break;
        case "O":
          if (e.KeyCode == Keys.O) return (true);
          break;
        case "P":
          if (e.KeyCode == Keys.P) return (true);
          break;
        case "Q":
          if (e.KeyCode == Keys.Q) return (true);
          break;
        case "R":
          if (e.KeyCode == Keys.R) return (true);
          break;
        case "S":
          if (e.KeyCode == Keys.S) return (true);
          break;
        case "T":
          if (e.KeyCode == Keys.T) return (true);
          break;
        case "U":
          if (e.KeyCode == Keys.U) return (true);
          break;
        case "V":
          if (e.KeyCode == Keys.V) return (true);
          break;
        case "W":
          if (e.KeyCode == Keys.W) return (true);
          break;
        case "X":
          if (e.KeyCode == Keys.X) return (true);
          break;
        case "Y":
          if (e.KeyCode == Keys.Y) return (true);
          break;
        case "Z":
          if (e.KeyCode == Keys.Z) return (true);
          break;
        case "1":
          if (e.KeyCode == Keys.D1) return (true);
          break;
        case "2":
          if (e.KeyCode == Keys.D2) return (true);
          break;
        case "3":
          if (e.KeyCode == Keys.D3) return (true);
          break;
        case "4":
          if (e.KeyCode == Keys.D4) return (true);
          break;
        case "5":
          if (e.KeyCode == Keys.D5) return (true);
          break;
        case "6":
          if (e.KeyCode == Keys.D6) return (true);
          break;
        case "7":
          if (e.KeyCode == Keys.D7) return (true);
          break;
        case "8":
          if (e.KeyCode == Keys.D9) return (true);
          break;
        case "0":
          if (e.KeyCode == Keys.D0) return (true);
          break;
        default:
          return (false);
      }

      return (false);
      
    }
    

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      // Save main form position and size
      AppSettings.Instance.FormLeft = this.Left;
      AppSettings.Instance.FormTop = this.Top;
      AppSettings.Instance.FormWidth = this.Width;
      AppSettings.Instance.FormHeight = this.Height;

      // Application version
      System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
      System.Version ver = asm.GetName().Version;
      AppSettings.Instance.AppVersion = int.Parse(ver.ToString().Replace(".", ""));

      AppSettings.Instance.SaveOptions();

    }

    /// <summary>
    /// Replace dummy Desktop image and show
    /// </summary>
    private void ReplaceShowScreen()
    {
      if (AppSettings.Instance.fMuteSystemSound == true)
      {
        Mute();
      }
      
      Form4 frm4 = new Form4();
      frm4.ShowDialog();
      frm4.Dispose();
      
    }

    private void buttonExecute_Click(object sender, EventArgs e)
    {
      ReplaceShowScreen();
    }

    private void buttonExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ToolStripMenuItemFile_Click(object sender, EventArgs e)
    {
      if (Clipboard.ContainsImage())
      {
        ToolStripMenuItemPasteImageFromClipboard.Enabled = true;
      }
      else
      {
        ToolStripMenuItemPasteImageFromClipboard.Enabled = false;
      }
    }

    private void ToolStripMenuItemOpenImageFile_Click(object sender, EventArgs e)
    {
      // Open folder
      if (Directory.Exists(AppSettings.Instance.InitDirPath) == true)
      {
        openFileDialog1.InitialDirectory = AppSettings.Instance.InitDirPath;
      }
      else
      { // default - Desktop
        openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      }

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        Bitmap bmp = new Bitmap(openFileDialog1.FileName);
        pictureBox1.Image = bmp;
      }
    }

    private void ToolStripMenuItemOpenImageFromClipboard_Click_1(object sender, EventArgs e)
    {
      if (Clipboard.ContainsImage())
      {
        Image img = Clipboard.GetImage();
        if (img != null)
        {
          pictureBox1.Image = img;
        }
      }
    }

    private void ToolStripMenuItemSaveImageFile_Click(object sender, EventArgs e)
    {
      // Open folder
      if (Directory.Exists(AppSettings.Instance.InitDirPath) == true)
      {
        saveFileDialog1.InitialDirectory = AppSettings.Instance.InitDirPath;
      }
      else
      { // default - Desktop
        saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      }

      saveFileDialog1.FileName = NowDateTime.ToString("yyyy-MM-dd_HH-mm-ss");
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        pictureBox1.Image.Save(saveFileDialog1.FileName);
      }

    }

    private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ToolStripMenuItemOption_Click(object sender, EventArgs e)
    {
      // Show Option Panel
      Form3 frm3 = new Form3();
      frm3.ShowDialog();
      frm3.Dispose();
      DisplayCurrentShortCut();

    }

    private void ToolStripMenuItemOnlineHelp_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("https://hibara.org/software/bosscoming/");
    }

    private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
    {
      // Show this application's information
      Form2 frm2 = new Form2();
      frm2.ShowDialog();
      frm2.Dispose();
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Visible = true;
      if (this.WindowState == FormWindowState.Minimized)
      {
        this.WindowState = FormWindowState.Normal;
      }
      this.Activate();
    }

    private void Form1_ClientSizeChanged(object sender, EventArgs e)
    {
      if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
      {
        if (AppSettings.Instance.fInTaskBar == false)
        {
          this.Hide();
        }
        notifyIcon1.Visible = true;
      }
    }

    private void ToolStripMenuItemDisplayForm_Click(object sender, EventArgs e)
    {
      this.Visible = true;
      if (this.WindowState == FormWindowState.Minimized)
      {
        this.WindowState = FormWindowState.Normal;
      }
      this.Activate();
    }

    private void buttonMinimize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

  }

}
