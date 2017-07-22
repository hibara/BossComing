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

namespace BossComing
{
  public partial class Form3 : Form
  {
    public Form3()
    {
      InitializeComponent();
    }

    private void Form3_Load(object sender, EventArgs e)
    {
      checkBoxCtrl.Checked = AppSettings.Instance.KeyModCtrl;
      checkBoxAlt.Checked = AppSettings.Instance.KeyModAlt;
      checkBoxShift.Checked = AppSettings.Instance.KeyModShift;

      checkBoxMouseLeft.Checked = AppSettings.Instance.MouseModLeft;
      checkBoxMouseMiddle.Checked = AppSettings.Instance.MouseModMiddle;
      checkBoxMouseRight.Checked = AppSettings.Instance.MouseModRight;

      string[] itemsArray = new string[]
      {
        "F1",
        "F2",
        "F3",
        "F4",
        "F5",
        "F6",
        "F7",
        "F8",
        "F9",
        "F10",
        "F11",
        "F12",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "0",
        "MiddleClick",
        "RightClick",
        "WheelUp",
        "WheelDown",
        "LeftDoubleClick",
        "RightDoubleClick"
      };

      for (int i = 0; i < itemsArray.Length; i++)
      {
        if (itemsArray[i] == AppSettings.Instance.KeyString)
        {
          listBoxKeyString.SelectedIndex = i;
          break;
        }
      }

      trackBar1.Value = AppSettings.Instance.FadeinSpeed;

      checkBoxSpecifyImageFile.Checked = AppSettings.Instance.fGazoFile;
      textBoxSpecifyImageFile.Text = AppSettings.Instance.GazoFilePath;
      checkBoxMuteSystemSound.Checked = AppSettings.Instance.fMuteSystemSound;
      checkBoxInTaskbar.Checked = AppSettings.Instance.fInTaskBar;

      buttonApply.Enabled = false;

    }

    private void Form3_FormClosed(object sender, FormClosedEventArgs e)
    {
      // stab
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      if ( buttonApply.Enabled == true)
      {
        buttonApply.PerformClick();
      }
      this.Close();
    }

    private void buttonApply_Click(object sender, EventArgs e)
    {
      // Key
      AppSettings.Instance.KeyModCtrl = checkBoxCtrl.Checked;
      AppSettings.Instance.KeyModAlt = checkBoxAlt.Checked;
      AppSettings.Instance.KeyModShift = checkBoxShift.Checked;

      AppSettings.Instance.MouseModLeft = checkBoxMouseLeft.Checked;
      AppSettings.Instance.MouseModMiddle = checkBoxMouseMiddle.Checked;
      AppSettings.Instance.MouseModRight = checkBoxMouseRight.Checked;

      AppSettings.Instance.KeyString = listBoxKeyString.SelectedItem.ToString();

      // Fade In speed
      AppSettings.Instance.FadeinSpeed = trackBar1.Value;

      // Use external image file
      AppSettings.Instance.fGazoFile = checkBoxSpecifyImageFile.Checked;
      AppSettings.Instance.GazoFilePath = textBoxSpecifyImageFile.Text;

      // Mute system sound
      AppSettings.Instance.fMuteSystemSound = checkBoxMuteSystemSound.Checked;

      // In task bar
      AppSettings.Instance.fInTaskBar = checkBoxInTaskbar.Checked;

      // Save options
      AppSettings.Instance.SaveOptions();

      buttonApply.Enabled = false;

    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ChangedValue(object sender, EventArgs e)
    {
      buttonApply.Enabled = true;
    }

    private void checkBoxSpecifyImageFile_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxSpecifyImageFile.Checked == true)
      {
        textBoxSpecifyImageFile.Enabled = true;
        textBoxSpecifyImageFile.BackColor = SystemColors.Window;
        buttonSelectFile.Enabled = true;
      }
      else
      {
        textBoxSpecifyImageFile.Enabled = false;
        textBoxSpecifyImageFile.BackColor = SystemColors.ButtonFace;
        buttonSelectFile.Enabled = false;
      }
      buttonApply.Enabled = true;
    }

    private void buttonSelectFile_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        textBoxSpecifyImageFile.Text = openFileDialog1.FileName;
      }
    }

    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
      labelFadeInSpeed.Text = trackBar1.Value.ToString() + "ms";
      buttonApply.Enabled = true;
    }

  }
}
