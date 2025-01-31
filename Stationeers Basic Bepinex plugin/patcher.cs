﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace StationeersCreativeFreedom
{
        [BepInPlugin("org.bepinex.plugins.CreativeFreedom", "Stationeers Creative Freedom", "0.6.0.1-STH64")]
        public class StationeersCreativeFreedom : BaseUnityPlugin
        {  
           public void Awake()
           {
            Logger.LogInfo("CF Initialized");
            var harmony = new Harmony("org.bepinex.plugins.CreativeFreedom");
            harmony.PatchAll();
            Logger.LogInfo("Patched with Harmony");
           }
        //public static StationeersCreativeFreedom Instance;
        }
 }
