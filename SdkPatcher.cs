using System;
using HarmonyLib;
using UnityEditor;
using UnityEngine;
using VRC.SDKBase.Editor;

[InitializeOnLoad]
public static class SdkPatcher {
    private static Harmony _harmony;
    public static string _steamPath;

    static SdkPatcher() {
        if (_harmony == null) {
            _harmony = new Harmony("pl.barkk.vrcsdk_linux");
        }
        
        _steamPath = "";
        if (EditorPrefs.HasKey("VRC_steamappsPath"))
            _steamPath = EditorPrefs.GetString("VRC_steamappsPath");
        _harmony.UnpatchAll();
        _harmony.PatchAll();
    }
}
 
[HarmonyPatch(typeof(VRC_SdkBuilder))]
[HarmonyPatch(nameof(VRC_SdkBuilder.GetKnownFolderPath))]
class EditorPatch {
    static bool Prefix(ref string __result, Guid knownFolderId) {
        Debug.Log(knownFolderId);
        if (knownFolderId.ToString() == "a520a1a4-1780-4ff6-bd18-167343c5af16") {
            __result = EditorPrefs.GetString("VRC_steamappsPath") +
                       "/compatdata/438100/pfx/drive_c/users/steamuser/AppData/LocalLow/";
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(VRCSdkControlPanel))]
[HarmonyPatch("OnVRCInstallPathGUI")]
class ControlPanelPatch {
    static void Prefix() {
        EditorGUILayout.LabelField("steamapps directory", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("steamapps: ", SdkPatcher._steamPath);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("");
        if (GUILayout.Button("Edit")) {
            string initPath = "";
            if (!string.IsNullOrEmpty(SdkPatcher._steamPath))
                initPath = SdkPatcher._steamPath;

            SdkPatcher._steamPath = EditorUtility.OpenFolderPanel("Choose steamapps directory", initPath, "");

            EditorPrefs.SetString("VRC_steamappsPath", SdkPatcher._steamPath);
            // window.OnConfigurationChanged();
        }

        EditorGUILayout.EndHorizontal();
    }
}