# Avatar patch

Use GUIDPatch instead

## DLL patch

The entire DLL patch is:

VRCSDK3A-Editor.dll > VRC.SDK3.Builder > ExportAndTestAvatarBlueprint:11

\---
```cs
string text = VRC_SdkBuilder.GetKnownFolderPath(VRC_SdkBuilder.LocalLowGUID) + "/VRChat/vrchat/Avatars/";
```

+++
```cs
string text = EditorPrefs.GetString("VRC_steamappsPath") + "/compatdata/438100/pfx/drive_c/users/steamuser/AppData/LocalLow/VRChat/VRChat/Avatars/";
```