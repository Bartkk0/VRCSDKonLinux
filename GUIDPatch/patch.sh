#!/usr/bin/env bash

PATCHES="$PWD"

echo "Select SDK location: "
read SDK

cd "$SDK"

dos2unix Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelSettings.cs
dos2unix Dependencies/VRChat/Editor/ControlPanel/VRCSdkControlPanelAccount.cs

patch -p1 < "$PATCHES/patch.diff"

xdelta3 -f -d -s Plugins/VRCSDKBase-Editor.dll "$PATCHES/VRCSDKBase-Editor.vcdiff" Plugins/VRCSDKBase-Editor.dll
