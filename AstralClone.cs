﻿using MelonLoader;
using System;
using System.Reflection;

[assembly: MelonInfo(typeof(Astrum.AstralClone), "SaferClone", "0.1.0", downloadLink: "https://github.com/VRChat-is-Awesome/SaferClone")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace Astrum
{
    public class AstralClone : MelonMod
    {
        public override void OnApplicationStart() =>
            HarmonyInstance.Patch(
                typeof(VRC.Core.APIUser).GetProperty(nameof(VRC.Core.APIUser.allowAvatarCopying)).GetSetMethod(),
                new HarmonyLib.HarmonyMethod(typeof(AstralClone).GetMethod(nameof(AstralClone.Hook), BindingFlags.NonPublic | BindingFlags.Static))
            );

        private static void Hook(ref bool __0) => __0 = true;
    }
}
