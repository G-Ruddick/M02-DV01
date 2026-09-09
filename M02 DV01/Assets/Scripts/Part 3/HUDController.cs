using UnityEngine;

namespace Chapter.EventBus {
    public class HUDController : MonoBehaviour {
        private bool isDisplayOn;

        void OnEnable() {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
        }
        
        void OnDisable() {
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayHUD);
        }

        private void DisplayHUD() {
            isDisplayOn = true;
        }

        void OnGUI() {
            if (isDisplayOn) {
                if (GUILayout.Button("Stop Race")) {
                    isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);
                }
            }
        }
    }
}