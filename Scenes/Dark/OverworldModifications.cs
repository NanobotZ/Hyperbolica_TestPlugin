using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace HyperbolicaPlugin
{
    internal class OverworldModifications
    {
        internal static GameObject darkGuard = null;
        internal static GameObject darkPortal = null;

        internal static void OnOverLoaded()
        {
            darkGuard = CreateGuard();
            darkPortal = CreatePortal(darkGuard);
        }

        private static GameObject CreatePortal(GameObject guard)
        {
            var LLLLL = GameObject.Find("tile_LLLLL");
            var LDL = GameObject.Find("tile_LDL");
            var ldlHO = LDL.GetComponent<HyperObject>();

            var basePortal = LLLLL.transform.FindChild("Portal").gameObject;

            var clonePortal = Object.Instantiate(basePortal, LDL.transform);
            clonePortal.name = "Portal";
            clonePortal.transform.position = new Vector3(-0.22f, 0.18f, 0.0f);
            clonePortal.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            clonePortal.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

            var portal = clonePortal.GetComponent<Portal>();


            portal.portalID = 100;
            portal.restrictName = guard.name;
            portal.scene = "Dark";

            ldlHO.AddChildObject(clonePortal);


            return clonePortal;
        }

        private static GameObject CreateGuard()
        {
            var NPC = GameObject.Find("NPC");
            var guard = NPC.transform.FindChild("gallery_guard").gameObject;

            var cloneGuard = Object.Instantiate(guard, NPC.transform);
            cloneGuard.transform.rotation = Quaternion.Euler(0.0f, 70.0f, 0.0f);

            var guardHO = cloneGuard.GetComponent<HyperObject>();
            var guardRobot = cloneGuard.GetComponent<Robot>();

            cloneGuard.name = guardRobot.dialogKey = guardRobot.profile = "dark_guard";
            guardHO.localGV = new GyroVector(new Vector3(-0.883f, 0.0f, -0.28f), Quaternion.Euler(0.0f, 0.0f, 0.0f));

            var robot_body = cloneGuard.transform.FindChild("robot_body");
            var bob_body = robot_body.FindChild("bob_body");
            var body = bob_body.FindChild("body");
            body.GetComponent<SetTextures>().UpdateColorOnly(new Color(1, 0, 0, 1));
            Object.DestroyImmediate(body.FindChild("bow_tie(Clone)").gameObject);
            Object.DestroyImmediate(body.FindChild("bow_tie(Clone)").gameObject);

            var bob_head = bob_body.FindChild("bob_head");
            var head_root = bob_head.FindChild("head_root");
            var head = head_root.FindChild("head");
            head.GetComponent<SetTextures>().UpdateColorOnly(new Color(0, 1, 0, 1));
            var eyes = head.FindChild("eyes");
            eyes.GetComponent<SetTextures>().UpdateColorOnly(new Color(0, 0, 1, 1));
            Object.DestroyImmediate(head_root.FindChild("top_hat(Clone)").gameObject);
            Object.DestroyImmediate(head_root.FindChild("top_hat(Clone)").gameObject);

            var robot_arm_r = bob_body.FindChild("robot_arm_r").FindChild("default");
            robot_arm_r.GetComponent<SetTextures>().UpdateColorOnly(new Color(1, 1, 1, 1));
            var robot_arm_l = bob_body.FindChild("robot_arm_l").FindChild("default");
            robot_arm_l.GetComponent<SetTextures>().UpdateColorOnly(new Color(0, 0, 0, 0));

            return cloneGuard;
        }
    }
}
