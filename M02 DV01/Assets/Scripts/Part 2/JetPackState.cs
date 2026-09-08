using UnityEngine;

public class JetPackState : HeroineState {
    private LayerMask ground;

    public void HandleInput(Heroine player) {
        ground = LayerMask.NameToLayer("Ground");

        player.transform.localScale = new Vector3(1f, 1f, 1f);

        player.playerSpeed = 3f;
        player.jetPack.SetActive(true);

        Debug.Log("jetpack");
    }
    
    public void UpdateHeroine(Heroine player) {
        player.playerRigidBody.AddForce(Vector3.up * 2f, ForceMode.Acceleration);

        if (Input.GetKeyUp(KeyCode.Space)) {
            player.ChangeState(Heroine.jumpingState);
            player.jetPack.SetActive(false);
        }
        if (Physics.Raycast(player.transform.position, Vector3.down, 0.7f, ground)) {
            player.ChangeState(Heroine.standingState);
            player.jetPack.SetActive(false);
        }
    }
}