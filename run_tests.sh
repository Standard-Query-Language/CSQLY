#!/bin/bash

echo "Running tests for CSQLY..."

# Navigate to solution directory
cd "$(dirname "$0")"

# Force clean the output directories
find . -name "bin" -type d -exec rm -rf {} +
find . -name "obj" -type d -exec rm -rf {} +

# Recreate directories
mkdir -p CSQLY/obj CSQLY/bin CSQLY.Tests/obj CSQLY.Tests/bin

# Restore packages with explicit projects
echo "Restoring packages..."
dotnet restore CSQLY/CSQLY.csproj
dotnet restore CSQLY.Tests/CSQLY.Tests.csproj

# Build the projects
echo "Building projects..."
dotnet build CSQLY/CSQLY.csproj --configuration Release
dotnet build CSQLY.Tests/CSQLY.Tests.csproj --configuration Release

# Run tests
echo "Running tests..."
dotnet test CSQLY.Tests/CSQLY.Tests.csproj --configuration Release --verbosity normal

echo "Tests completed."
