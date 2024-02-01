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
        public static bool InfAmmo = false;
        public static bool InfHealth = false;
        public static bool KickAllPlayers = false;
        public static bool StartMatch = false;
        public override void OnGUI()
        {
            InfAmmo = GUI.Toggle(new Rect(10, 90, 120, 30), InfAmmo, "Inf Ammo");
            InfHealth = GUI.Toggle(new Rect(10, 110, 120, 30), InfHealth, "Inf Health");
            KickAllPlayers = GUI.Toggle(new Rect(10, 130, 120, 30), KickAllPlayers, "Kill all Players");
            StartMatch = GUI.Toggle(new Rect(10, 150, 130, 30), StartMatch, "Inst Start Match (In lobby)");
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
            //Inf AMMO (ONLY HOST)
            if (ClientMain.InfAmmo)
            {
                
            }
            //Inf Health (ONLY HOST)
            if (ClientMain.InfHealth)
            {
                foreach (GrapplingHook hook in GameObject.FindObjectsOfType<GrapplingHook>())
                {
                    if (hook == null)
                        continue;
                    MelonLogger.Msg(hook.player.tag);
                    MelonLogger.Msg(hook.player.name);
                    MelonLogger.Msg("----------------------");
                }
            }

            if (ClientMain.KickAllPlayers)
            {
                foreach (CustomNetworkManager networkManager in GameObject.FindObjectsOfType<CustomNetworkManager>())
                {
                    if (networkManager != null & networkManager.gamePlayers != null)
                    {
                        AllPlayers = networkManager.gamePlayers;
                        foreach (PlayerGameObjectController player in AllPlayers)
                        {
                            if (player == null) continue;
                            if (player.playerName == "PedoBoy") continue;
                            networkManager.KickPlayer(player.PlayerSteamID, player.ConnectionID);
                        }
                    }
                }
            }
            if (ClientMain.StartMatch)
            {
                foreach (LobbyController controller in GameObject.FindObjectsOfType<LobbyController>())
                {
                    if (controller != null)
                        controller.StartGame();
                }
            }

        }
    }
}

