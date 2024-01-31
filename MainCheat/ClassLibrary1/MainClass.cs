using UnityEngine;
using MelonLoader;
using CheatGrap;

namespace Main
{
    public class ClientMain : MelonMod
    {
        public static bool player_esp = false;
        /* All this function i will add
        public static bool InfAmmo = false;
        public static bool InfHealth = false;
        public static bool KillAllPlayers = false;
        public static bool StartMatch = false;
        */
        public override void OnGUI()
        {
            player_esp = GUI.Toggle(new Rect(10, 70, 120, 30), player_esp, "ESP");
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
            {
                if(player == null)
                    continue;   
                Render.DrawNameESP(player.transform.position, "Player",new Color(128f, 0f, 0f));
            }
        }

    }
}

