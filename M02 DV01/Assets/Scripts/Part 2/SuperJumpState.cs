using UnityEngine;

public class SuperJumpState : HeroineState {
    private LayerMask ground;
    private int count;

    public void HandleInput(Heroine player) {
        ground = LayerMask.NameToLayer("Ground");

        player.transform.localScale = new Vector3(1f, 1.1f, 1f);
        player.playerRigidBody.AddForce(Vector3.up * player.playerJump * 3, ForceMode.Impulse);
        count = 0;

        player.playerSpeed = 0f;

        Debug.Log("Super Jump");
    }
    
    public void UpdateHeroine(Heroine player) {
        if (count++ < 10) {
            return;
        }

        if (Physics.Raycast(player.transform.position, Vector3.down, 0.6f, ground)) {
            player.ChangeState(Heroine.standingState);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)) {
            player.ChangeState(Heroine.divingState);
        }
    }
}