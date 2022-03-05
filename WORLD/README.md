# Linux world SDK

After a lot of work, i managed to make the world SDK work without any patching needed. Just download the vrchat.exe script and select it in VRChat SDK settings in unity.

Remember to make the script executable.

Limitations:
 - You have to have to specify vrchat install location and proton location in vrchat.exe
 - Reloading doesn't work(probably the client not the SDK) 
 - Unable to publish world(problem with case sensitivity)

Some issues are caused by unity saving files with lowercase names and searching for files with uppercase letters in their name.

## SDK reload patch
Fixes reloading from SDK side

`VRCSDK/SDK3/Editor/VRCSdkControlPanelWorldBuilder3.cs:135`

Replace

```cs
string path = EditorPrefs.GetString("lastVRCPath");
```

with

```cs
string p = EditorPrefs.GetString("lastVRCPath");
string path = Path.GetDirectoryName(p) + "/" + Path.GetFileName(p).ToLower();
```
