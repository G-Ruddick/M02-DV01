using UnityEngine;

public class JumpingState : HeroineState {
    private LayerMask ground;
    private int count;

    public void HandleInput(Heroine player) {
        ground = LayerMask.NameToLayer("Ground");

        player.transform.localScale = new Vector3(1f, 1.2f, 1f);
        player.playerRigidBody.AddForce(Vector3.up * player.playerJump, ForceMode.Impulse);
        count = 0;

        player.playerSpeed = 1f;

        Debug.Log("Jumping");
    }
    
    public void UpdateHeroine(Heroine player) {
        if (count++ < 10) {
            return;
        }

        if (Physics.Raycast(player.transform.position, Vector3.down, 0.7f, ground)) {
            player.ChangeState(Heroine.standingState);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)) {
            player.ChangeState(Heroine.divingState);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && count > 30) {
            player.ChangeState(Heroine.jetPackState);
        }
    }
}