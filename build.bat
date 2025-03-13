@echo off
echo Building CSQLY solution...

REM Navigate to solution directory
cd /d %~dp0

REM Clean (optional)
if "%1"=="clean" (
  echo Cleaning output directories...
  for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"
)

REM Restore and build
dotnet restore CSQLY.sln
dotnet build CSQLY.sln --configuration Release

echo Build completed.
