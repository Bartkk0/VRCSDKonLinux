# Linux world SDK

After a lot of work, i managed to make the world SDK work without any patching needed. Just download the vrchat.exe script and select it in VRChat SDK settings in unity.

Limitations:
 - Only 1 instance
 - Reloading doesn't work(probably the client not the SDK)

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