# VRCSDK GUID patch

Used for patching folder GUID search. Created this because VRCSDKBase-Editor.dll is the same between SDKs.

Works for:
 - WORLD_2021.11.24.16 (Needs further fixes)
 - AVATAR_2021.11.24.16 (Should work, not tested)


## DLL Patch

VRCSDKBase-Editor.dll > VRC.SDKBase.Editor > VRC_SdkBuilder:263
Method: GetKnownFolderPath
```cs
// On method begin
if(knownFolderId.ToString() == "a520a1a4-1780-4ff6-bd18-167343c5af16")
	return EditorPrefs.GetString("VRC_steamappsPath") + "/compatdata/438100/pfx/drive_c/users/steamuser/AppData/LocalLow/";

Debug.Log("Uncaught folder UUID = " + knownFolderId.ToString());
```

Currently this is the only GUID that appears to be used, can be extended in future
