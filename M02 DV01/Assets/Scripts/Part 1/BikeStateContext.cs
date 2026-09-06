namespace Chapter.State {
    public class BikeStateContext {
        public IBikeState CurrentState {
            get;
            set;
        }

        private readonly BikeController bikeController;
        
        public BikeStateContext(BikeController controller) {
            bikeController = controller;
        }

        public void Transition(IBikeState state) {
            CurrentState = state;
            CurrentState.Handle(bikeController);
        }
    }
}
