using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Kawaiisun.SimpleHostile
{
    public class MainMenu : MonoBehaviour
    {
        public Launcher launcher;

        private void Start()
        {
            Pause.paused = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void JoinMatch()
        {
            launcher.TabOpenRooms();
        }

        public void CreateMatch()
        {
            launcher.TabOpenCreate();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}