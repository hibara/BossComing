//---------------------------------------------------------------------- 
// "BossComing2" -- File encryption software.
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

namespace BossComing
{
  public partial class Form4 : Form
  {
    public double FadeInValue = 1000 - ((double)AppSettings.Instance.FadeinSpeed / 1000);

    public Form4()
    {
      InitializeComponent();

      this.Opacity = 0;

      pictureBox1.Dock = DockStyle.Fill;
      pictureBox1.Image = AppSettings.Instance.BitmapMainGazo;
      buttonClose.Size = new Size(1, 1);

    }

    private void Form4_Load(object sender, EventArgs e)
    {
      if (AppSettings.Instance.fGazoFile == true)
      {
        if (File.Exists(AppSettings.Instance.GazoFilePath) == true )
        {
          Image img = Image.FromFile(AppSettings.Instance.GazoFilePath);
          pictureBox1.Image = img;
        }
      }

      this.FormBorderStyle = FormBorderStyle.None;

      //this.WindowState = FormWindowState.Maximized;
      this.Left = SystemInformation.VirtualScreen.Left;
      this.Top = SystemInformation.VirtualScreen.Top;
      this.Width = SystemInformation.VirtualScreen.Width;
      this.Height = SystemInformation.VirtualScreen.Height;

      // This is gradually displayed
      for (int i = 0; i <= AppSettings.Instance.FadeinSpeed; i++)
      {
        if ( this.Opacity < 1)
        {
          // Change the transparency of the form.
          this.Opacity += 0.01;
          this.Refresh();
          // Pause and redraw the form.
          System.Threading.Thread.Sleep(AppSettings.Instance.FadeinSpeed/10);
        }
      }
      
    }

    private void Form4_MouseClick(object sender, MouseEventArgs e)
    {
      this.Close();
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      // Grobal variables from Form1
      if (Form1.fMouseModLeft == true || Form1.fMouseModMiddle == true || Form1.fMouseModRight == true)
      {
        Form1.fMouseModLeft = false;
        Form1.fMouseModMiddle = false;
        Form1.fMouseModRight = false;
      }
      else
      {
        this.Close();
      } 

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.Opacity < 1)
      {
        this.Opacity += FadeInValue;
        this.Refresh();
      }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {

    }
  }
}
