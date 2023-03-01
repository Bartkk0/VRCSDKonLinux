# VRChat SDK Linux patch (New and improved)

## Warning: By modifying the SDK you are violating the VRChat TOS. Do it at your own risk!

Now using Harmony to avoid DLL patches.

1. Import SDK.
2. Download Harmony .NET 4.7 into `Assets/Editor` (Create if doesn't exist).
3. Copy SdkPatchBase.cs into Assets/Editor.

If you are using the Avatar SDK
4. Copy AvatarSdkPatcher.cs into `Assets/Editor`
5. Select your steamapps folder location in SDK settings.

If you are using the World SDK
4. Copy WorldSdkPatcher.cs into `Assets/Editor`
5. Select VRChat.exe from this repo in SDK settings

## Compatibility

The last checked version is `2022.1.1` but the patches should work on newer versions
