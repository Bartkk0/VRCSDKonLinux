# VRChat SDK linux patch

## Warning: By modifying the SDK you are violiating the VRChat TOS. Do it at your own risk!

A very primitive patch to add linux support to VRChat SDK
Basically everything was working, but one line which interacted with shell32.dll was broken.

Tested only avatar testing and uploading

1. Make a backup of your SDK
2. cd into the directory of your sdk version
3. run ./patch.sh
4. Go to VRChat Control Panel in unity
5. Go to settings
6. Select the steamapps location
7. profit.
