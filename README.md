> [!WARNING]
> I don't have much time to maintain this. A newer patch is available at: \
> https://befuddledlabs.github.io/LinuxVRChatSDKPatch/ \
> https://github.com/BefuddledLabs/LinuxVRChatSDKPatch

# VRChat SDK Linux patch (New and improved)

## Warning: By modifying the SDK you are violating the VRChat TOS. Do it at your own risk!

Now using Harmony to avoid DLL patches.

## Installation

### Unity package method
Import the corresponding unitypackage.
If you are using the world SDK change steamapps path in SDK settings.
If you are using the avatar SDK change the client path in SDK settings to the one in Editor folder.

### Manual installation
1. Import SDK.
2. Download Harmony (https://github.com/pardeike/Harmony/releases) .NET 4.7 into `Assets/Editor` (Create if doesn't exist).
3. Copy SdkPatchBase.cs into Assets/Editor.

If you are using the Avatar SDK
4. Copy AvatarSdkPatcher.cs into `Assets/Editor`
5. Select your steamapps folder location in SDK settings.

If you are using the World SDK
4. Copy WorldSdkPatcher.cs into `Assets/Editor`
2. Select VRChat.exe from this repo in SDK settings

## Compatibility

The last checked version is `2022.1.1` but the patches should work on newer versions
