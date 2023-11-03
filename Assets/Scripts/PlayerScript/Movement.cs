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
    public float Speed;
    public float JumpStrength;

    private bool OnGround = false;
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
        float MoveForwardsBack = forwardsBack.ReadValue<float>() * Speed;
        float MoveRightLeft = rightLeft.ReadValue<float>() * Speed;
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

