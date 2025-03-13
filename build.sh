#!/bin/bash

echo "Building CSQLY solution..."

# Navigate to solution directory
cd "$(dirname "$0")"

# Clean (optional)
if [ "$1" = "clean" ]; then
  echo "Cleaning output directories..."
  rm -rf */bin */obj
fi

# Restore and build
dotnet restore CSQLY.sln
dotnet build CSQLY.sln --configuration Release

echo "Build completed."
