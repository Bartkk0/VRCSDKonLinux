using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using VRC.SDK3.Editor.Builder;

[HarmonyPatch(typeof(VRCWorldAssetExporter))]
[HarmonyPatch("ExportCurrentSceneResource", new Type[] { typeof(bool), typeof(Action<string>), typeof(Action<object>) })]
class ExportCurrentSceneResourcePatch
{
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = instructions.ToList();
        for (var i = 0; i < codes.Count; i++)
        {
            if (codes[i].opcode == OpCodes.Ldstr)
            {
                if (codes[i].operand.ToString().Contains(".vrcw"))
                {
                    Debug.LogWarning("FOUND i = " + i);
                    i += 3;
                    var str2 = codes[i].operand;
                    i++;
                    codes.Insert(i++, new CodeInstruction(OpCodes.Ldloc_S, str2));
                    codes.Insert(i++,CodeInstruction.Call(typeof(String), "ToLower"));
                    codes.Insert(i++, new CodeInstruction(OpCodes.Stloc_S, str2));
                    break;
                }
            }
        }

        return codes.AsEnumerable();
    }
}
