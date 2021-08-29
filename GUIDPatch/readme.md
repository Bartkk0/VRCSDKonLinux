# VRCSDK GUID patch

Used for patching folder GUID search. Created this because VRCSDKBase-Editor.dll is the same between SDKs.

Works for:
 - WORLD-2021.08.11.15.16 (Doesn't need the other patch)
 - AVATAR_2021.08.11.15.16 (Needs further fixes)


## DLL Patch

VRCSDKBase-Editor.dll > VRC.SDKBase.Editor > VRC_SdkBuilder:281
```cs
// On method begin
if(knownFolderId.ToString() == "a520a1a4-1780-4ff6-bd18-167343c5af16")
	return EditorPrefs.GetString("VRC_steamappsPath") + "/compatdata/438100/pfx/drive_c/users/steamuser/AppData/LocalLow/";

Debug.Log("Uncaught folder UUID = " + knownFolderId.ToString());
```

Currently this is the only GUID that appears to be used, can be extended in future