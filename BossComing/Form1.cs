//---------------------------------------------------------------------- 
// "BossComing2" -- File encryption software.
// Copyright (C) 2016  Mitsuhiro Hibara
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

namespace BossComing
{
  public partial class Form1 : Form
  {

    public DateTime NowDateTime;

    public Form1()
    {
      InitializeComponent();

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

      NowDateTime = DateTime.Now;
      toolStripStatusLabelCaptureDateTime.Text = "Capture: " + NowDateTime.ToString();

      //----------------------------------------------------------------------
      // Hot key
      AppSettings.Instance.HK = new Hotkey();

      ArrayList KeyList = new ArrayList();

      Keys key;
      Enum.TryParse(AppSettings.Instance.KeyString, out key);
      AppSettings.Instance.HK.KeyCode = key;

      //AppSettings.Instance.HK.Windows = true;
      if (AppSettings.Instance.KeyModCtrl == true)
      {
        AppSettings.Instance.HK.Control = true;
        KeyList.Add("Ctrl");
      }
      if (AppSettings.Instance.KeyModAlt == true)
      {
        AppSettings.Instance.HK.Alt = true;
        KeyList.Add("Alt");
      }
      if (AppSettings.Instance.KeyModShift == true)
      {
        AppSettings.Instance.HK.Shift = true;
        KeyList.Add("Shift");
      }

      KeyList.Add(AppSettings.Instance.KeyString);
      toolStripStatusLabelKeyString.Text = String.Join(" + ", KeyList.ToArray());

      AppSettings.Instance.HK.Pressed += delegate { ReplaceShowScreen(); };

      if (!AppSettings.Instance.HK.GetCanRegister(this))
      {
        MessageBox.Show("Whoops, looks like attempts to register will fail or throw an exception, show error to user");
      }
      else
      {
        AppSettings.Instance.HK.Register(this);
      }


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

      if (AppSettings.Instance.HK.Registered)
      {
        AppSettings.Instance.HK.Unregister();
      }

    }

    /// <summary>
    /// Replace dummy Desktop image and show
    /// </summary>
    private void ReplaceShowScreen()
    {
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

      ArrayList KeyList = new ArrayList();

      Keys key;
      Enum.TryParse(AppSettings.Instance.KeyString, out key);
      AppSettings.Instance.HK.KeyCode = key;

      //AppSettings.Instance.HK.Windows = true;
      if (AppSettings.Instance.KeyModCtrl == true)
      {
        AppSettings.Instance.HK.Control = true;
        KeyList.Add("Ctrl");
      }
      if (AppSettings.Instance.KeyModAlt == true)
      {
        AppSettings.Instance.HK.Alt = true;
        KeyList.Add("Alt");
      }
      if (AppSettings.Instance.KeyModShift == true)
      {
        AppSettings.Instance.HK.Shift = true;
        KeyList.Add("Shift");
      }

      KeyList.Add(key);
      toolStripStatusLabelKeyString.Text = String.Join(" + ", KeyList.ToArray());

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
