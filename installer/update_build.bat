@echo. ======================================================================
@echo. Batch process file that create installer to package.
@echo. 
@echo. * Required "Inno Setup 5" later
@echo. * Required "7Zip"
@echo. ======================================================================

@echo 
@echo -----------------------------------
@echo copy files
@echo -----------------------------------

mkdir bin

copy ..\BossComing\bin\Release\BossComing.exe bin\BossComing.exe
mkdir bin\ja-JP
copy ..\BossComing\bin\Release\ja-JP\BossComing.resources.dll bin\ja-JP\BossComing.resources.dll
copy ..\readme.txt bin\readme.txt

@echo 
@echo -----------------------------------
@echo Timestamp zero clear
@echo -----------------------------------

..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe bin\readme.txt
..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe bin\BossComing.exe
..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe bin\ja-JP\BossComing.resources.dll

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

@rem Code signing
if exist "code_signing\_password.txt" (

for /f "tokens=*" %%i in (code_signing\_password.txt) do Set PASS=%%i 

)

"C:\Program Files\Microsoft SDKs\Windows\v7.1A\Bin\signtool.exe" sign /v /fd sha256 /f code_signing\OS201608304212.pfx /p %PASS% /t http://timestamp.globalsign.com/?signature=sha2 Archives\*.exe


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
@echo. Timestamp ( only time ) zero clear
@echo. -----------------------------------

..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe /w Archives\*.exe
..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe /w Archives\*.zip
..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe /w Archives\*.md5
..\tools\setTimeZero\setTimeZero\bin\Release\setTimeZero.exe /w Archives\*.sha1


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

