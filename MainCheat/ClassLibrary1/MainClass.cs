using UnityEngine;
using MelonLoader;
using CheatGrap;
using Il2Cpp;
using Il2CppMirror;

namespace Main
{
    public class ClientMain : MelonMod
    {
        public static bool player_esp = false;
        public override void OnGUI()
        {
            player_esp = GUI.Toggle(new Rect(10, 70, 120, 30), player_esp, "ESP");
            Hacks.LaunchHack();
        }
    }
    public class Hacks
    {
        public static Il2CppSystem.Collections.Generic.List<PlayerGameObjectController> AllPlayers = default!;
        public static GameObject localplayer = default!;
        public static void FindLocalPlayer()
        {
            foreach (Camera cam in GameObject.FindObjectsOfType<Camera>())
            {
                if (cam != null)
                {
                    foreach (GrapplingHook controller in GameObject.FindObjectsOfType<GrapplingHook>())
                    {
                        if (controller.cam != cam)
                            continue;
                        localplayer = controller.player;
                        break;
                    }
                    break;
                }
            }
        }
        public static void LaunchHack()
        {
            //ESP
            if (ClientMain.player_esp)
            {

                foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
                {
                    if (player != null & localplayer != player)
                    {
                        FindLocalPlayer();
                        //aimbot = GUI.Toggle(new Rect(10, 100, 120, 30), aimbot, "AIMBOT"); IN TEST
                        Render.DrawNameESP(player.transform.position, "Player", new Color(1.0f, 0.0f, 0.0f, 1.0f));
                    }
                }
            }
            
        }
    }
}

