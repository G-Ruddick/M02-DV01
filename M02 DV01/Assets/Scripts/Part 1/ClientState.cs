using UnityEngine;

namespace Chapter.State {
    public class ClientState : MonoBehaviour {
        private BikeController bikeController;

        void Start() {
            bikeController = (BikeController)FindAnyObjectByType(typeof(BikeController));
        }

        void OnGUI() {
            if (GUILayout.Button("Start Bike")) {
                bikeController.StartBike();
            }

            if (GUILayout.Button("Turn Left")) {
                bikeController.TurnBike(Direction.Left);
            }

            if (GUILayout.Button("Turn Right")) {
                bikeController.TurnBike(Direction.Right);
            }
            
            if (GUILayout.Button("Stop Bike")) {
                bikeController.StopBike();
            }
        }
    }
}