# VRChat SDK linux patch

A very primitive patch to add linux support to VRChat SDK
Basically everything was working but one line which interacted with shell32.dll

Tested only avatar testing and u

1. Make a backup of your SDK
2. cd into the directory of your sdk version
3. ./patch.sh
4. Go to vrc control panel in unity
5. Go to settings
6. Select steamapps location
