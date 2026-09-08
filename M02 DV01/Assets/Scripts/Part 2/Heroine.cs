using UnityEngine;

public class Heroine : MonoBehaviour {
    public float playerSpeed = 8f;
    public float playerJump = 5f;

    public Rigidbody playerRigidBody;
    public GameObject jetPack;

    public static JumpingState jumpingState;
    public static StandingState standingState;
    public static DuckingState duckingState;
    public static DivingState divingState;
    public static RunningState runningState;
    public static SuperJumpState superJumpState;
    public static JetPackState jetPackState;

    public HeroineState playerState;

    float y;

    private void Awake() {
        playerRigidBody = GetComponent<Rigidbody>();

        jetPack.SetActive(false);

        jumpingState = new JumpingState();
        standingState = new StandingState();
        duckingState = new DuckingState();
        divingState = new DivingState();
        runningState = new RunningState();
        superJumpState = new SuperJumpState();
        jetPackState = new JetPackState();

        playerState = standingState;
    }
    
    public void Update() {
        float verticalMove = Input.GetAxis("Vertical") * playerSpeed;
        float horizontalMove = Input.GetAxis("Horizontal") * playerSpeed;

        playerState.UpdateHeroine(this);

        transform.Rotate(0, horizontalMove / 20, 0);
        playerRigidBody.AddForce(transform.forward * verticalMove, ForceMode.Acceleration);

        float x = Mathf.Clamp(playerRigidBody.linearVelocity.x, -playerSpeed, playerSpeed);
        float z = Mathf.Clamp(playerRigidBody.linearVelocity.z, -playerSpeed, playerSpeed);

        playerRigidBody.linearVelocity = new Vector3(x, playerRigidBody.linearVelocity.y, z);
    }

    public void ChangeState(HeroineState state) {
        playerState = state;
        playerState.HandleInput(this);
    }
}
