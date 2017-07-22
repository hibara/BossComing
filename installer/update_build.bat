@echo. ======================================================================v
@echo. Batch process file that create installer to package.
@echo. 
@echo. * Required "Inno Setup 5" later
@echo. * Required "7Zip"
@echo. ======================================================================

@echo 
@echo -----------------------------------
@echo Rebuild BossComing2.exe
@echo -----------------------------------


msbuild.exe /p:Configuration="Release" /p:Platform="AnyCPU" /t:ReBuild /v:n ..\BossComing\BossComing.csproj


@echo 
@echo -----------------------------------
@echo Delete old files
@echo -----------------------------------

del /Q Archives\

@echo 
@echo -----------------------------------
@echo copy files
@echo -----------------------------------

mkdir bin

copy ..\BossComing\bin\Release\BossComing.exe bin\BossComing.exe
mkdir bin\ja-JP
copy ..\BossComing\bin\Release\ja-JP\BossComing.resources.dll bin\ja-JP\BossComing.resources.dll

@echo 
@echo -----------------------------------
@echo Code signing
@echo -----------------------------------

SET PATH="C:\Program Files\Microsoft SDKs\Windows\v7.0A\bin";%PATH%
SET PATH="C:\Program Files\Microsoft SDKs\Windows\v7.1\Bin";%PATH%
SET PATH="C:\Program Files\Windows Kits\8.0\bin\x86";%PATH%

signtool.exe sign /v /a /n "Mitsuhiro Hibara" /tr http://rfc3161timestamp.globalsign.com/advanced /td sha256 bin\BossComing.exe

@echo. 
@echo. -----------------------------------
@echo. create installer package
@echo. -----------------------------------

if "%PROCESSOR_ARCHITECTURE%" == "AMD64" (
"%ProgramFiles(x86)%\Inno Setup 5\ISCC.exe" BossComing.iss
) else (
"%ProgramFiles%\Inno Setup 5\ISCC.exe" BossComing.iss
)

echo %ERRORLEVEL%

signtool.exe sign /v /a /n "Mitsuhiro Hibara" /tr http://rfc3161timestamp.globalsign.com/advanced /td sha256 Archives\bscm*.exe


@echo. 
@echo. -----------------------------------
@echo. Create zip archive
@echo. -----------------------------------

@rem Get version number
for /F "delims=" %%s in ('..\tools\getver\getver\bin\Release\GetVer.exe bin\BossComing.exe') do @set NUM=%%s

@rem ZIP
cd bin
7z a -tzip ..\Archives\bscm%NUM%.zip BossComing.exe ja-JP\AttacheCase.resources.dll
cd ..\


@echo. 
@echo. -----------------------------------
@echo. make hash file
@echo. -----------------------------------

..\tools\GetHash\GetHash\bin\Release\GetHash.exe Archives\bscm%NUM%.exe
..\tools\GetHash\GetHash\bin\Release\GetHash.exe Archives\bscm%NUM%.zip


@echo. 
@echo. -----------------------------------
@echo. Delete temporary directrory
@echo. -----------------------------------

@rem rd /s /q "bin"

:END

@echo 
@echo **********************************************************************
@echo Batch process finished.
@echo **********************************************************************
@echo 


pause

