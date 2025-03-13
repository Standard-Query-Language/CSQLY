#!/bin/bash

echo "Running tests for CSQLY..."

# Navigate to solution directory
cd "$(dirname "$0")"

# Exit on any error
set -e

# Clean output directories
echo "Cleaning output directories..."
rm -rf CSQLY/bin CSQLY/obj CSQLY.Tests/bin CSQLY.Tests/obj CSQLY.CLI/bin CSQLY.CLI/obj

# Check if solution file exists
if [ ! -f "CSQLY.sln" ]; then
    echo "Error: CSQLY.sln not found in current directory"
    exit 1
fi

# Restore and build the solution
echo "Restoring and building solution..."
dotnet restore --verbosity minimal
dotnet build --configuration Release --verbosity minimal

# Run tests with verbose output
echo "Running tests..."
dotnet test CSQLY.Tests/CSQLY.Tests.csproj --configuration Release --no-build --verbosity normal

echo "Tests completed."
