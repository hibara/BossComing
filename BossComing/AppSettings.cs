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
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;

namespace BossComing
{
  /// <summary>
  /// Save AttacheCase setting to registry class by Singleton pattern
  /// </summary>
  public class AppSettings
  {

    //-----------------------------------
    // メンバ変数(Member Variable)
    //-----------------------------------

    // Self instance
    private static AppSettings _Instance;

    private string RegistryPathAppInfo = String.Format(@"Software\Hibara\{0}\AppInfo", "BossComing2");
    private string RegistryPathWindowPos = String.Format(@"Software\Hibara\{0}\WindowPos", "BossComing2");
    private string RegistryPathKeyCode = String.Format(@"Software\Hibara\{0}\KeyCode", "BossComing2");
    private string RegistryPathOption = String.Format(@"Software\Hibara\{0}\Option", "BossComing2");

    // Static instance ( Singleton pattern )
    public static AppSettings Instance
    {
      get
      {
        if (_Instance == null)
        {
          _Instance = new AppSettings();
        }
        return _Instance;
      }
      set
      {
        _Instance = value;
      }
    }
    //----------------------------------------------------------------------
    // Main Bitmap
    //----------------------------------------------------------------------
    private Bitmap _BitmapMainGazo;
    public Bitmap BitmapMainGazo
    {
      get { return this._BitmapMainGazo; }
      set { this._BitmapMainGazo = value; }
    }

    //----------------------------------------------------------------------
    // Window Pos
    #region
    //----------------------------------------------------------------------
    private int _FormTop;
    public int FormTop
    {
      get { return this._FormTop; }
      set { this._FormTop = value; }
    }
    private int _FormLeft;
    public int FormLeft
    {
      get { return this._FormLeft; }
      set { this._FormLeft = value; }
    }
    private int _FormWidth;
    public int FormWidth
    {
      get { return this._FormWidth; }
      set { this._FormWidth = value; }
    }
    private int _FormHeight;
    public int FormHeight
    {
      get { return this._FormHeight; }
      set { this._FormHeight = value; }
    }
    private int _FormStyle;
    public int FormStyle
    {
      get { return this._FormStyle; }
      set { this._FormStyle = value; }
    }

    private int _AppVersion;                      // アプリケーションのバージョン
                                                  // Get this application version
    public int AppVersion
    {
      get { return this._AppVersion; }
      set { this._AppVersion = value; }
    }

    #endregion

    //----------------------------------------------------------------------
    // KeyCode
    #region

    private string _KeyString;
    public string KeyString
    {
      get { return this._KeyString; }
      set
      {
        if (value == "Left click" || value == "左クリック")
        {
          this._KeyString = "LeftClick";
        }
        else if (value == "Middle click" || value == "中央クリック")
        {
          this._KeyString = "MiddleClick";
        }
        else if (value == "Right click" || value == "右クリック")
        {
          this._KeyString = "RightClick";
        }
        else if (value == "Wheel up" || value == "ホイールアップ")
        {
          this._KeyString = "WheelUp";
        }
        else if (value == "Wheel down" || value == "ホイールダウン")
        {
          this._KeyString = "WheelDown";
        }
        else if (value == "Left double click" || value == "左ダブルクリック")
        {
          this._KeyString = "LeftDoubleClick";
        }
        else if (value == "Right double click" || value == "右ダブルクリック")
        {
          this._KeyString = "RightDoubleClick";
        }
        else
        {
          this._KeyString = value;
        }
      }
    }

    private bool _KeyModAlt;
    public bool KeyModAlt
    {
      get { return this._KeyModAlt; }
      set { this._KeyModAlt = value; }
    }
    private bool _KeyModCtrl;
    public bool KeyModCtrl
    {
      get { return this._KeyModCtrl; }
      set { this._KeyModCtrl = value; }
    }
    private bool _KeyModShift;
    public bool KeyModShift
    {
      get { return this._KeyModShift; }
      set { this._KeyModShift = value; }
    }

    private bool _MouseModLeft;
    public bool MouseModLeft
    {
      get { return this._MouseModLeft; }
      set { this._MouseModLeft = value; }
    }

    private bool _MouseModMiddle;
    public bool MouseModMiddle
    {
      get { return this._MouseModMiddle; }
      set { this._MouseModMiddle = value; }
    }

    private bool _MouseModRight;
    public bool MouseModRight
    {
      get { return this._MouseModRight; }
      set { this._MouseModRight = value; }
    }

    //-----------------------------------
    // Not use from ver.1.1.0.0
    private int _keyCode;
    public int keyCode
    {
      get { return this._keyCode; }
      set { this._keyCode = value; }
    }
    // Not use from ver.1.1.0.0
    private int _ModKeyCode;
    public int ModKeyCode
    {
      get { return this._ModKeyCode; }
      set { this._ModKeyCode = value; }
    }

    #endregion


    //----------------------------------------------------------------------
    // Option
    #region
    //----------------------------------------------------------------------

    private int _FadeinSpeed;
    public int FadeinSpeed
    {
      get { return this._FadeinSpeed; }
      set { this._FadeinSpeed = value; }
    }

    private bool _fGazoFile;
    public bool fGazoFile
    {
      get { return this._fGazoFile; }
      set { this._fGazoFile = value; }
    }

    private string _GazoFilePath;
    public string GazoFilePath
    {
      get { return this._GazoFilePath; }
      set { this._GazoFilePath = value; }
    }

    private bool _fInTaskTrayIcon;
    public bool fInTaskTrayIcon
    {
      get { return this._fInTaskTrayIcon; }
      set { this._fInTaskTrayIcon = value; }
    }

    private bool _fMuteSystemSound;
    public bool fMuteSystemSound
    {
      get { return this._fMuteSystemSound; }
      set { this._fMuteSystemSound = value; }
    }

    private bool _fInTaskBar;
    public bool fInTaskBar
    {
      get { return this._fInTaskBar; }
      set { this._fInTaskBar = value; }
    }

    private string _InitDirPath;
    public string InitDirPath
    {
      get { return this._InitDirPath; }
      set { this._InitDirPath = value; }
    }

    #endregion

    //----------------------------------------------------------------------
    /// <summary>
    /// Cunstractor（コンストラクタ）
    /// </summary>
    //----------------------------------------------------------------------
    private AppSettings()
    {
    }

    public void ReadOptions()
    {
      // 設定をレジストリから読み込む
      // Load ALL settings from registry
      this.ReadOptionsFromRegistry();

    }

    public void SaveOptions()
    {
      //レジストリへの保存
      SaveOptionsToRegistry();

    }

    //----------------------------------------------------------------------
    /// <summary>
    /// Read options from sysytem registry
    /// 設定をレジストリから読み込む
    /// </summary>
    //----------------------------------------------------------------------
    public void ReadOptionsFromRegistry()
    {
      using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegistryPathAppInfo, false))
      {
        if (reg == null)
        {
          Registry.CurrentUser.CreateSubKey(RegistryPathAppInfo);
          Registry.CurrentUser.CreateSubKey(RegistryPathWindowPos);
          Registry.CurrentUser.CreateSubKey(RegistryPathKeyCode);
          Registry.CurrentUser.CreateSubKey(RegistryPathOption);
        }
      }

      //----------------------------------------------------------------------
      // Windows Positions and size
      using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegistryPathWindowPos, false))
      {
        _FormTop = (int)reg.GetValue("WindowTop", -1);
        _FormLeft = (int)reg.GetValue("WindowLeft", -1);
        _FormWidth = (int)reg.GetValue("WindowWidth", 420);
        _FormHeight = (int)reg.GetValue("WindowHeight", 380);
      }

      //----------------------------------------------------------------------
      // KeyCode
      using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegistryPathKeyCode, false))
      {
        _KeyString = (string)reg.GetValue("KeyString", "Q");
        _KeyModAlt = bool.Parse((string)reg.GetValue("KeyModAlt", "false"));
        _KeyModCtrl = bool.Parse((string)reg.GetValue("KeyModCtrl", "true"));
        _KeyModShift = bool.Parse((string)reg.GetValue("KeyModShift", "false"));
        _MouseModLeft = bool.Parse((string)reg.GetValue("MouseModLeft", "false"));
        _MouseModMiddle = bool.Parse((string)reg.GetValue("MouseModMiddle", "false"));
        _MouseModRight = bool.Parse((string)reg.GetValue("MouseModRight", "false"));
      }
      //----------------------------------------------------------------------
      // Option
      using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegistryPathOption, false))
      {
        _FadeinSpeed = (int)reg.GetValue("FadeinSpeed", 100);
        _fGazoFile = bool.Parse((string)reg.GetValue("fGazoFile", "false"));
        _GazoFilePath = (string)reg.GetValue("GazoFilePath", "");
        _fMuteSystemSound = bool.Parse((string)reg.GetValue("fMuteSystemSound", "false"));
        _fInTaskTrayIcon = bool.Parse((string)reg.GetValue("fInTaskTrayIcon", "false"));
        _fInTaskBar = bool.Parse((string)reg.GetValue("fInTaskBar", "false"));
        _InitDirPath = (string)reg.GetValue("InitDirPath", "");
      }
    }

    //----------------------------------------------------------------------
    /// <summary>
    /// Save options to system registry
    /// 設定をレジストリに書き込む
    /// </summary>
      //----------------------------------------------------------------------
    public void SaveOptionsToRegistry()
		{
			//-----------------------------------
			// Open the registry key (AppInfo).
			using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(RegistryPathAppInfo))
			{
				reg.SetValue("AppPath", Application.ExecutablePath);
				reg.SetValue("AppVersion", _AppVersion);
			}

			//-----------------------------------
			// Window
			using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(RegistryPathWindowPos))
			{
				// Windows Positions and size
				reg.SetValue("WindowTop", _FormTop);
				reg.SetValue("WindowLeft", _FormLeft);
				reg.SetValue("WindowWidth", _FormWidth);
				reg.SetValue("WindowHeight", _FormHeight);
				reg.SetValue("FormStyle", _FormStyle);
			}

      //-----------------------------------
      // Key code
      using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(RegistryPathKeyCode))
      {
        reg.SetValue("KeyString", _KeyString);
        reg.SetValue("KeyModAlt", _KeyModAlt);
        reg.SetValue("KeyModCtrl", _KeyModCtrl);
        reg.SetValue("KeyModShift", _KeyModShift);
        reg.SetValue("MouseModLeft", _MouseModLeft);
        reg.SetValue("MouseModMiddle", _MouseModMiddle);
        reg.SetValue("MouseModRight", _MouseModRight);
      }

      //----------------------------------------------------------------------
      // Options
      using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(RegistryPathOption))
			{
        reg.SetValue("FadeinSpeed", _FadeinSpeed);
        reg.SetValue("fGazoFile", _fGazoFile);
        reg.SetValue("GazoFilePath", _GazoFilePath);
        reg.SetValue("fMuteSystemSound", _fMuteSystemSound);
        reg.SetValue("fInTaskTrayIcon", _fInTaskTrayIcon);
        reg.SetValue("fInTaskBar", _fInTaskBar);
        reg.SetValue("InitDirPath", _InitDirPath);
      }

    }

  }

}
