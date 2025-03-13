@echo off
echo Running tests for CSQLY...

REM Navigate to solution directory
cd /d %~dp0

REM Clean output directories
if exist CSQLY\bin rmdir /s /q CSQLY\bin
if exist CSQLY\obj rmdir /s /q CSQLY\obj
if exist CSQLY.Tests\bin rmdir /s /q CSQLY.Tests\bin
if exist CSQLY.Tests\obj rmdir /s /q CSQLY.Tests\obj
if exist CSQLY.CLI\bin rmdir /s /q CSQLY.CLI\bin
if exist CSQLY.CLI\obj rmdir /s /q CSQLY.CLI\obj

REM Check if solution file exists
if not exist CSQLY.sln (
  echo Error: CSQLY.sln not found in current directory
  exit /b 1
)

REM Restore and build the solution
echo Restoring and building solution...
dotnet restore --verbosity minimal
if %ERRORLEVEL% neq 0 (
  echo Failed to restore packages
  exit /b %ERRORLEVEL%
)

dotnet build --configuration Release --verbosity minimal
if %ERRORLEVEL% neq 0 (
  echo Failed to build projects
  exit /b %ERRORLEVEL%
)

REM Run tests
echo Running tests...
dotnet test CSQLY.Tests\CSQLY.Tests.csproj --configuration Release --no-build --verbosity normal
if %ERRORLEVEL% neq 0 (
  echo Tests failed
  exit /b %ERRORLEVEL%
)

echo Tests completed.
