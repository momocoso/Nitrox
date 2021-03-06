﻿using System;
using System.Reflection;
using Harmony;
using NitroxModel.Core;
using NitroxClient.GameLogic;

namespace NitroxPatcher.Patches
{
    public class uGUI_SignInput_OnDeselect_Patch : NitroxPatch
    {
        public static readonly Type TARGET_CLASS = typeof(uGUI_SignInput);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("OnDeselect", BindingFlags.Public | BindingFlags.Instance);

        public static void Postfix(uGUI_SignInput __instance)
        {
            NitroxServiceLocator.LocateService<Signs>().Changed(__instance);
        }

        public override void Patch(HarmonyInstance harmony)
        {
            PatchPostfix(harmony, TARGET_METHOD);
        }
    }
}
