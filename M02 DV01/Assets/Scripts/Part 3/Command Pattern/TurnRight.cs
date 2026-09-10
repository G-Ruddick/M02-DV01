namespace Chapter.Command {
    public class TurnRight : Command {
        private BikeController controller;
        
        public TurnRight(BikeController newController) {
            controller = newController;
        }
        
        public override void Execute() {
            controller.Turn(BikeController.Direction.Right);
        }
    }
}