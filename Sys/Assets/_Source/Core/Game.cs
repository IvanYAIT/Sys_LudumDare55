using Character;
using UnityEngine;

namespace Core
{
    public class Game
    {
        public static void Pause()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            InputListener.CharacterInput = false;
        }

        public static void UnPause()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            InputListener.CharacterInput = true;
        }
    }
}