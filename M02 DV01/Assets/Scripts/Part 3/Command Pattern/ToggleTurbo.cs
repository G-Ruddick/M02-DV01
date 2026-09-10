namespace Chapter.Command {
    public class ToggleTurbo : Command {
        private BikeController controller;
        
        public ToggleTurbo(BikeController newController) {
            controller = newController;
        }
        
        public override void Execute() {
            controller.ToggleTurbo();
        }
    }
}