using UnityEngine;

public class DuckingState : HeroineState {
    private int timer;

    public void HandleInput(Heroine player) {
        player.transform.localScale = new Vector3(1f, 0.5f, 1f);
        // player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.25f, player.transform.position.z);

        player.playerSpeed = 4f;

        timer = 0;

        Debug.Log("Ducking");
    }

    public void UpdateHeroine(Heroine player) {
        if (timer++ > 500 && Input.GetKey(KeyCode.Space)) {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.25f, player.transform.position.z);
            player.ChangeState(Heroine.superJumpState);
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.25f, player.transform.position.z);
            player.ChangeState(Heroine.standingState);
        }
    }
}