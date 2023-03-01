using System;
using HarmonyLib;
using UnityEditor;
using UnityEngine;
using VRC.SDKBase.Editor;

[InitializeOnLoad]
public static class AvatarSdkPatcher
{
    public static string _steamPath;

    static AvatarSdkPatcher()
    {
        _steamPath = "";
        if (EditorPrefs.HasKey("VRC_steamappsPath"))
            _steamPath = EditorPrefs.GetString("VRC_steamappsPath");
    }
}

[HarmonyPatch(typeof(VRC_SdkBuilder))]
[HarmonyPatch(nameof(VRC_SdkBuilder.GetKnownFolderPath))]
class EditorPatch
{
    static bool Prefix(ref string __result, Guid knownFolderId)
    {
        Debug.Log(knownFolderId);
        if (knownFolderId.ToString() == "a520a1a4-1780-4ff6-bd18-167343c5af16")
        {
            __result = EditorPrefs.GetString("VRC_steamappsPath") +
                       "/compatdata/438100/pfx/drive_c/users/steamuser/AppData/LocalLow/";
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(VRCSdkControlPanel))]
[HarmonyPatch("OnVRCInstallPathGUI")]
class ControlPanelPatch
{
    static void Prefix()
    {
        EditorGUILayout.LabelField("Steamapps directory", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Steamapps directory containing VRChat");
        EditorGUILayout.LabelField("Locaton: ", AvatarSdkPatcher._steamPath);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("");
        if (GUILayout.Button("Edit"))
        {
            string initPath = "";
            if (!string.IsNullOrEmpty(AvatarSdkPatcher._steamPath))
                initPath = AvatarSdkPatcher._steamPath;

            AvatarSdkPatcher._steamPath = EditorUtility.OpenFolderPanel("Choose steamapps directory", initPath, "");

            EditorPrefs.SetString("VRC_steamappsPath", AvatarSdkPatcher._steamPath);
            // window.OnConfigurationChanged();
        }

        EditorGUILayout.EndHorizontal();
    }
}
