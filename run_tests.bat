@echo off
echo Running tests for CSQLY...

REM Navigate to solution directory
cd /d %~dp0

REM Force clean the output directories
for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"

REM Restore packages with explicit projects
echo Restoring packages...
dotnet restore CSQLY\CSQLY.csproj
dotnet restore CSQLY.Tests\CSQLY.Tests.csproj

REM Build the projects
echo Building projects...
dotnet build CSQLY\CSQLY.csproj --configuration Release
dotnet build CSQLY.Tests\CSQLY.Tests.csproj --configuration Release

REM Run tests
echo Running tests...
dotnet test CSQLY.Tests\CSQLY.Tests.csproj --configuration Release --verbosity normal

echo Tests completed.
