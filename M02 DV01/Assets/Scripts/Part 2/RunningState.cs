using UnityEngine;

public class RunningState : HeroineState {
    public void HandleInput(Heroine player) {
        player.transform.localScale = new Vector3(1f, 1f, 1f);

        player.playerSpeed = 16f;

        Debug.Log("Running");
    }

    public void UpdateHeroine(Heroine player) {
        if (Input.GetKey(KeyCode.LeftShift)) {
            player.ChangeState(Heroine.duckingState);
        }
        else if (Input.GetKey(KeyCode.Space)) {
            player.ChangeState(Heroine.jumpingState);
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            player.ChangeState(Heroine.standingState);
        }
    }
}