using UnityEngine;

namespace Chapter.State {
    public class BikeStartState : MonoBehaviour, IBikeState{
        private BikeController bikeController;
        
        // overriding IBikeState's Handle function
        public void Handle(BikeController controller) {
            if (!bikeController) {
                bikeController = controller;
            }
            
            bikeController.CurrentSpeed = bikeController.maxSpeed;
        }

        void Update() {
            if (bikeController) {
                if (bikeController.CurrentSpeed > 0) {
                    bikeController.transform.Translate(Vector3.forward * bikeController.CurrentSpeed * Time.deltaTime);
                }
            }    
        }
    }
}