using UnityEngine;

namespace CheatGrap
{
    public class Render
    {   
        /* For aimbot (In Future)
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        */
        public static void DrawNameESP(Vector3 pos, string name, Color color )
        {
            foreach (Camera cam in GameObject.FindObjectsOfType<Camera>())
            {
                if ( cam == null ) { continue; }
                Vector3 vector = cam.WorldToScreenPoint(pos);
                if (vector.z > 0f & Main.ClientMain.player_esp)
                {
                    vector.y = (float)Screen.height - (vector.y + 1f);
                    GUI.color = color;
                    // (Draw cross on player)
                    GUI.DrawTexture(new Rect(new Vector2(vector.x,vector.y), new Vector2(7f,2f)), Texture2D.whiteTexture,0);
                    GUI.DrawTexture(new Rect(new Vector2(vector.x, vector.y), new Vector2(-6f, 2f)), Texture2D.whiteTexture, 0);
                    GUI.DrawTexture(new Rect(new Vector2(vector.x, vector.y), new Vector2(2f, 7f)), Texture2D.whiteTexture, 0);
                    GUI.DrawTexture(new Rect(new Vector2(vector.x, vector.y), new Vector2(2f, -5f)), Texture2D.whiteTexture, 0);
                    GUI.Label(new Rect(new Vector2(vector.x, vector.y+8), new Vector2(100f, 100f)), name);
                    GUI.color = Color.white;
                }
                
            }
            
        }
    }
}
