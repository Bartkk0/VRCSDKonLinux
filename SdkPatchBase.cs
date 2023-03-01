using HarmonyLib;
using UnityEditor;

namespace Editor
{
    [InitializeOnLoad]
    public static class SdkPatchBase
    {
        private static Harmony _harmony;

        static SdkPatchBase()
        {
            if (_harmony == null)
            {
                _harmony = new Harmony("pl.barkk.vrcsdk_linux");
            }

            
            _harmony.UnpatchAll();
            _harmony.PatchAll();
        }
    }
}