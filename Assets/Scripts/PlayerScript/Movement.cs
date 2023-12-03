using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Input input;
    private Input.MovementActions movement;
    private InputAction forwardsBack;
    private InputAction rightLeft;
    private InputAction jump;
    public Rigidbody rb;
    public float BaseSpeed;
    public float JumpStrength;

    private bool OnGround = false;
    private bool IsRunning;
    [SerializeField] private Transform CheckGround;
    [SerializeField] private float GroundRadius;
    [SerializeField] private LayerMask PlatformLM;




    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        movement = input.Movement;

        forwardsBack = movement.MoveX;
        rightLeft = movement.MoveZ;

        movement.Jump.performed += PlayerJump;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    void PlayerMove(){
        float RunSpeed = 3 * BaseSpeed;
        float currentSpeed;
        if(movement.Run.ReadValue<float>() > 0 && Physics.CheckSphere(CheckGround.position, GroundRadius, (int)PlatformLM)){
            currentSpeed = RunSpeed;
        }
        else{
            currentSpeed = BaseSpeed;
        }

        float MoveForwardsBack = forwardsBack.ReadValue<float>() * currentSpeed;
        float MoveRightLeft = rightLeft.ReadValue<float>() * currentSpeed;
        Vector3 move = (transform.right * MoveRightLeft) + (transform.forward * MoveForwardsBack);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    public void PlayerJump(InputAction.CallbackContext obj)
    {
        OnGround = Physics.CheckSphere(CheckGround.position, GroundRadius, (int)PlatformLM);
        if (OnGround)
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * JumpStrength, ForceMode.Impulse);
        }
    }
    

}

