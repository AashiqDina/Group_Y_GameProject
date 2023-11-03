using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    PlayerInput Input;
    InputAction ForwardsBack;
    InputAction RightLeft;
    InputAction Jump;
    public Rigidbody rb;
    public float Speed;
    public float JumpStrength;
     private Collider PlayerCollider;

    private bool OnGround = false;
     [SerializeField] private Transform CheckGround;
    [SerializeField] private float GroundRadius;
    [SerializeField] private LayerMask PlatformLM;




    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<PlayerInput>();
        ForwardsBack = Input.actions.FindAction("MoveX");
        RightLeft = Input.actions.FindAction("MoveZ");
        Jump = Input.actions.FindAction("Jump");
        PlayerCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
        
    }

    void PlayerMove(){
        float MoveForwardsBack = ForwardsBack.ReadValue<float>() * Speed;
        float MoveRightLeft = RightLeft.ReadValue<float>() * Speed;
        Vector3 move = (transform.right * MoveRightLeft) + (transform.forward * MoveForwardsBack);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        
    }

    void PlayerJump(){
        OnGround = Physics.CheckSphere(CheckGround.position, GroundRadius, (int) PlatformLM);
        Debug.Log("Can Jump:" + OnGround);
        if(Jump.triggered && OnGround){
            rb.velocity = new Vector3(0, JumpStrength, 0);
        }
 
    }

}

