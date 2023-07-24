using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;
using JetBrains.Annotations;

using Assets.Scripts;
using Assets.Scripts.UI;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Structures;

using Assets.Scripts.GridSystem;
using Assets.Scripts.Networking;

using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Entities;

using Assets.Scripts.Inventory;

using Assets.Scripts.Util;
using Objects.Items;
using Assets.Scripts.Objects.Items;



/*
Thanks to guiding of the TurkeyKittin! 
And other guide of RoboPhred.
And inspiration from DevCo constructions.
And Inaki's exercises!
*/

namespace StationeersCreativeFreedom
{
    #region Structure
    [HarmonyPatch(typeof(Structure), "Awake")]
    internal class Structure_Awake_Patch
    {
        [HarmonyPostfix]
        //[UsedImplicitly]//dunno what is for, something for simpler replacing of the field values.
        public static void Postfix(Structure __instance)
        {
            __instance.RotationAxis = RotationAxis.All; //thanks for Kamuchi for idea of using the named enumerator values
            __instance.AllowedRotations = AllowedRotations.All;
            //TODO key switcher to change precisement of constructions
            //__instance.GridSize = 0.5f; 
            //__instance.PlacementType = PlacementSnap.Grid;
        }
    }
    /*OLD CODE
    [HarmonyPatch(typeof(Structure), "CanConstruct")]
    public class CanConstructInfo_Patch
    {
        [HarmonyPostfix]
        [UsedImplicitly]
        public static void Postfix(Structure __instance, CanConstructInfo __result)
        {
            if (__instance.PlacementType == PlacementSnap.Grid)
            {
                __result = CanConstructInfo.ValidPlacement;
                return true;
            }
        }
    }*/

    [HarmonyPatch(typeof(CanConstructInfo), "InvalidPlacement")]
    public class CanConstructInfo_InvalidPlacement_Patch
    {
        [HarmonyPostfix]
        //[UsedImplicitly]
        public static void Postfix(ref CanConstructInfo __result)
        {

            __result = new CanConstructInfo(true, string.Empty);
        }
    }

    #endregion Structure

    #region SmallGrid
    [HarmonyPatch(typeof(SmallGrid), "_IsCollision")]
    public class SmallGrid_isCollision_Patch
    {
        [HarmonyPrefix]
        [UsedImplicitly]
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SmallGrid), "HasFrameBelow")]
    public class SmallGrid_HasFrameBelow_Patch
    {
        [HarmonyPostfix]
        //[UsedImplicitly]
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SmallGrid), "HasVoxelBelow")]
    public class SmallGrid_HasVoxelBelow_Patch
    {
        [HarmonyPostfix]
        //[UsedImplicitly]
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    #endregion SmallGrid

    #region Devices

    /*[HarmonyPatch(typeof(Airlock), "CheckSidesBlocked")]
    public class Airlock_CheckSidesBlocked_Patch
    {
        [HarmonyPostfix]
        //[UsedImplicitly]
        public static void Postfix(ref bool __result)
        {
            __result = true; //evading of CheckSidesBlocked
        }
    }*/

    #endregion

    #region DynamicThing

    #endregion DynamicThing

    #region Items

    #endregion

    #region Mothership

    #endregion

    #region Entity

    #endregion Entity

}