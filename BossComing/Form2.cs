﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BossComing.Properties;

namespace BossComing
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      labelVersion.Text = "Version." + ApplicationInfo.Version;
      labelCopyright.Text = ApplicationInfo.CopyrightHolder;
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    /// <summary>
    /// アセンブリ情報を取得する
    /// Get assembly infomations
    /// http://stackoverflow.com/questions/909555/how-can-i-get-the-assembly-file-version
    /// </summary>
    static public class ApplicationInfo
    {
      public static Version Version { get { return Assembly.GetCallingAssembly().GetName().Version; } }

      public static string Title
      {
        get
        {
          object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
          if (attributes.Length > 0)
          {
            AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
            if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
          }
          return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
      }

      public static string ProductName
      {
        get
        {
          object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
          return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }
      }

      public static string Description
      {
        get
        {
          object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
          return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
      }

      public static string CopyrightHolder
      {
        get
        {
          object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
          return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
      }

      public static string CompanyName
      {
        get
        {
          object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
          return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
      }

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      linkLabel1.LinkVisited = true;
      System.Diagnostics.Process.Start(linkLabel1.Text);
      this.Close();

    }
  }
}
