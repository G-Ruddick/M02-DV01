using UnityEngine;

namespace Chapter.State {
    public class BikeTurnState : MonoBehaviour, IBikeState{
        private Vector3 turnDirection;
        private BikeController bikeController;
        
        // overriding IBikeState's Handle function
        public void Handle(BikeController controller) {
            if (!bikeController) {
                bikeController = controller;
            }
            
            turnDirection.y = (float)bikeController.CurrentTurnDirection;

            if (bikeController.CurrentSpeed > 0) {
                transform.eulerAngles += turnDirection * bikeController.turnDistance;
            }
        }
    }
}