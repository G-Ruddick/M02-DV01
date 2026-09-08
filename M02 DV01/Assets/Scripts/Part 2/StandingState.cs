using UnityEngine;

public class StandingState : HeroineState {
    private int timer;
    private bool runCheck;

    public void HandleInput(Heroine player) {
        player.transform.localScale = new Vector3(1f, 1f, 1f);

        player.playerSpeed = 8f;
        timer = 0;

        Debug.Log("Standing");
    }

    public void UpdateHeroine(Heroine player) {
        if (Input.GetKeyDown(KeyCode.W)) {
            runCheck = true;
        }
        if (runCheck) {
            timer++;
        }
        if (timer >= 100) {
            runCheck = false;
            timer = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            player.ChangeState(Heroine.duckingState);
        }
        else if (Input.GetKey(KeyCode.Space)) {
            player.ChangeState(Heroine.jumpingState);
        }
        else if (Input.GetKeyDown(KeyCode.W) && timer > 1) {
            player.ChangeState(Heroine.runningState);
        }
    }
}