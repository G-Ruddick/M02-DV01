using UnityEngine;

namespace Chapter.State {
    public class BikeStopState : MonoBehaviour, IBikeState{
        private BikeController bikeController;
        
        // overriding IBikeState's Handle function
        public void Handle(BikeController controller) {
            if (!bikeController) {
                bikeController = controller;
            }

            bikeController.CurrentSpeed = 0;
        }
    }
}