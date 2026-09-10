using UnityEngine;

public class BikeController : MonoBehaviour {
    public enum Direction {
        Left = -1,
        Right = 1
    }

    private bool isTurbo;
    private float distance = 1.0f;

    public void ToggleTurbo() {
        isTurbo = !isTurbo;
    }

    public void Turn(Direction direction) {
        if (direction == Direction.Left) {
            transform.Translate(Vector3.left * distance);
        }
        if (direction == Direction.Right) {
            transform.Translate(Vector3.right * distance);
        }
    }

    public void ResetPosition() {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
