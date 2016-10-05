#define MyAppVer GetFileVersion("bin\BossComing.exe")
#define MyAppVerNum StringChange(MyAppVer, ".", "")

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "jp"; MessagesFile: "compiler:Languages\Japanese.isl"

[CustomMessages]
en.AppName=BossComing
jp.AppName=BossComing
en.AppComments="When you are working sideline, or you don't want to be seen in the family, this software replaces the screen with the fake desktop for the moment."
jp.AppComments="�d�����̓��E��A�Ƒ��Ɍ���ꂽ���Ȃ���Ƃ����Ă���Ƃ��A��l�ɋU�f�X�N�g�b�v��ʂ֓���ւ���\�t�g"
en.SetUpProgramDescription=Set up program for 'BossComing2'
jp.SetUpProgramDescription=BossComing2�Z�b�g�A�b�v�v���O���� 
en.UnintallName=Uninstall
jp.UnintallName=�A���C���X�g�[��
en.MsgFailedToInstallDotNetFramework=Failed to install .NET Framework 4.0.%nPlease install the .NET Framework 4.0 such as from Windows update.%nAnd then please start this setup program again.
jp.MsgFailedToInstallDotNetFramework=.NET Framework 4.0 �̃C���X�g�[���Ɏ��s�����悤�ł��B%nWindows�A�b�v�f�[�g�Ȃǂ��� .NET Framework���C���X�g�[�����āA%n�Z�b�g�A�b�v�v���O�������ēx�N�����Ă��������B
en.mdSampleFile=help.md
jp.mdSampleFile=help-ja.md
en.LaunchProgram=Start BossComing2 after finishing installation.
jp.LaunchProgram=�C���X�g�[��������ɁABossComing2 ���N�����܂��B

[Setup]AppName={cm:AppName}
AppVersion={#MyAppVer}AppVerName={cm:AppName} ver.{#MyAppVer}
DefaultGroupName={cm:AppName}
OutputBaseFilename=atcs{#MyAppVerNum}
DefaultDirName={pf}\BossComing
UsePreviousAppDir=yes
AppendDefaultDirName=yes 
OutputDir=.\archives
TouchTime=00:00
ShowLanguageDialog=yes
UsePreviousLanguage=no
;-----------------------------------
;�C���X�g�[���v���O����
;-----------------------------------
VersionInfoVersion={#MyAppVer}
;VersionInfoDescription={cm:SetUpProgramDescription}
AppCopyright=Copyright(C) 2016 M.Hibara, All rights reserved.
;SetupIconFile=icon\main_icon.ico
;�E�B�U�[�h�y�[�W�ɕ\�������O���t�B�b�N�i*.bmp: 164 x 314�j
;Graphic in wizard page.
WizardImageFile=bmp\installer_pic_01.bmp
;�E�B�U�[�h�y�[�W�ɕ\�������O���t�B�b�N���g�傳��Ȃ�
;Graphic in wizard page that is not expanded.
WizardImageStretch=no
;���̌��ԐF
;Background color.
WizardImageBackColor=$ffffff 
;�E�B�U�[�h�y�[�W�̉E�㕔���̃O���t�B�b�N�i*.bmp: 55 x 58�j
;Graphic in top-right window of wizard page.
WizardSmallImageFile=bmp\installer_pic_02.bmp
;�i���\��
;Progress.
ShowTasksTreeLines=yes

;------------------------------------------
;�u�v���O�����̒ǉ��ƍ폜�v�_�C�A���O���
;------------------------------------------
;�z�z��
AppPublisher=Mitsuhiro Hibara
;�A�v���P�[�V�����z�z�� Web�T�C�g�� URL
AppPublisherURL=https://hibara.org
;�A����
AppContact=m@hibara.org
;�T�|�[�g�T�C�gURL
AppSupportURL=https://hibara.org/software/
;ReadMe�t�@�C���p�X;AppReadmeFile="{app}\AttacheCase3\readme.txt"
;���i�X�V���URL
AppUpdatesURL=https://hibara.org/software/BossComing/
;�A�v���P�[�V�����̐���
AppComments={cm:AppComments}

[Files]
Source: "bin\BossComing.exe"; DestDir: "{app}"; Flags: ignoreversion touch; Check: InitializeSetup
Source: "bin\ja-JP\BossComing.resources.dll"; DestDir: "{app}\ja-JP"; Flags: ignoreversion touch
;Source: "bin\readme.txt"; DestDir: "{userappdata}\AttacheCase3"; Flags: ignoreversion touch

[Icons]
Name: "{group}\BossComing"; Filename: "{app}\BossComing"; WorkingDir: "{app}"
Name: "{group}\{cm:UnintallName}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{cm:AppName}"; Filename: "{app}\BossComing"; WorkingDir: "{app}"; Tasks: desktopicon

[Tasks]
;"�f�X�N�g�b�v��ɃA�C�R�����쐬����(&D)"
;Create a &desktop icon
Name: desktopicon; Description: {cm:CreateDesktopIcon};

[Run]
Filename: "{app}\BossComing.exe"; Description: {cm:LaunchProgram}; Flags: nowait postinstall skipifsilent

[UninstallDelete]


[Registry]
;����ݒ���폜
Root: HKCU; Subkey: "Software\Hibara\BossComing2"; Flags: uninsdeletekey


[Code]
function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1.4322'     .NET Framework 1.1
//    'v2.0.50727'    .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
  key: string;
  install, serviceCount: cardinal;
  success: boolean;
begin
  key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + version;
  // .NET 3.0 uses value InstallSuccess in subkey Setup
  if Pos('v3.0', version) = 1 then begin
    success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
  end else begin
    success := RegQueryDWordValue(HKLM, key, 'Install', install);
  end;
  // .NET 4.0 uses value Servicing instead of SP
  if Pos('v4', version) = 1 then begin
    success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
  end else begin
    success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
  end;
  result := success and (install = 1) and (serviceCount >= service);
end;

function InitializeSetup(): Boolean;
begin
  if not IsDotNetDetected('v4\Full', 0) then begin
    MsgBox('{cm:MsgFailedToInstallDotNetFramework}', mbInformation, MB_OK);
    result := false;
  end else
    result := true;
end;

