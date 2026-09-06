using UnityEngine;

public class DivingState : HeroineState {
    private LayerMask ground;

    public void HandleInput(Heroine player) {
        ground = LayerMask.NameToLayer("Ground");

        player.transform.localScale = new Vector3(1f, 0.5f, 1f);

        player.playerRigidBody.AddForce(new Vector3(0f, -10f, 4f), ForceMode.Impulse);

        Debug.Log("Diving");
    }

    public void UpdateHeroine(Heroine player) {
        if (Physics.Raycast(player.transform.position, Vector3.down, 0.25f, ground)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                player.ChangeState(Heroine.duckingState);
            }
            else {
                player.ChangeState(Heroine.standingState);
            }
        }
    }
}