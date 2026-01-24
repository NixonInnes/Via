#!/usr/bin/env bash
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$repo_root"

# Packs Via into ./.nupkg (see Via/Via.csproj PackageOutputPath)
dotnet pack Via/Via.csproj -c Release -v minimal

# Builds Via.Extensions against the packed Via NuGet package
# (see Via.Extensions/Via.Extensions.csproj conditional references)
dotnet build Via.slnx -c Release -v minimal -p:ViaUseProjectReference=false
