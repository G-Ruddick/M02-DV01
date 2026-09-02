using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Singleton {
    public class GameManager : Singleton<GameManager> {
        private DateTime sessionStartTime;
        private DateTime sessionEndTime;

        void Start() {
            sessionStartTime = DateTime.Now;
            Debug.Log("Game session start @: " + DateTime.Now);
        }

        void OnApplicationQuit() {
            sessionEndTime = DateTime.Now;

            TimeSpan timeDifference = sessionEndTime.Subtract(sessionStartTime);
            Debug.Log("Game session ended @: " + DateTime.Now);
            Debug.Log("Game session lasted: " + timeDifference);
        }

        void OnGUI() {
            GUI.backgroundColor = Color.white;
            if (GUILayout.Button("Next Scene", GUILayout.Width(80), GUILayout.Height(80))) {
                if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
                }
                else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
