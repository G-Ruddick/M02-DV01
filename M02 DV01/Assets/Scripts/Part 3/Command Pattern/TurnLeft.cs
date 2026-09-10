namespace Chapter.Command {
    public class TurnLeft : Command {
        private BikeController controller;
        
        public TurnLeft(BikeController newController) {
            controller = newController;
        }
        
        public override void Execute() {
            controller.Turn(BikeController.Direction.Left);
        }
    }
}