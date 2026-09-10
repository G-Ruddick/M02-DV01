using UnityEngine;

namespace Chapter.Command {
    public class InputHandler : MonoBehaviour {
        private Invoker invoker;
        private bool isReplaying;
        private bool isRecording;
        private BikeController bikeController;
        private Command buttonA, buttonD, buttonW;

        void Start() {
            invoker = gameObject.AddComponent<Invoker>();
            bikeController = FindObjectOfType<BikeController>();

            buttonA = new TurnLeft(bikeController);
            buttonD = new TurnRight(bikeController);
            buttonW = new ToggleTurbo(bikeController);
        }

        void Update() {
            if (!isReplaying && isRecording) {
                if (Input.GetKeyUp(KeyCode.A)) {
                    invoker.ExecuteCommand(buttonA);
                }
                if (Input.GetKeyUp(KeyCode.D)) {
                    invoker.ExecuteCommand(buttonD);
                }
                if (Input.GetKeyUp(KeyCode.W)) {
                    invoker.ExecuteCommand(buttonW);
                }
            }
        }

        void OnGUI() {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();

            if (GUILayout.Button("Start Recording")) {
                bikeController.ResetPosition();
                isReplaying = false;
                isRecording = true;
                invoker.Record();
            }

            if (GUILayout.Button("Stop Recording")) {
                bikeController.ResetPosition();
                isRecording = false;
            }

            if (!isRecording) {
                if (GUILayout.Button("Start Replaying")) {
                    bikeController.ResetPosition();
                    isRecording = false;
                    isReplaying = true;
                    invoker.Replay();
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }
}