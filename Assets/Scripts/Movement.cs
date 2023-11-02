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
    [SerializeField] private LayerMask PlatformLM;
    private Collider PlayerCollider;



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
        if(Jump.triggered){
            rb.velocity = new Vector3(0, JumpStrength, 0);
        }
 
    }

    // private bool Grounded(){
    //     float HeightIncrease = 5f;
    //     Vector3 forward = transform.TransformDirection(Vector3.down) * 10;
    //     if (Physics.Raycast(PlayerCollider.bounds.center, Vector3.down, (PlayerCollider.bounds.extents.y + HeightIncrease), PlatformLM)){
    //         Debug.Log("We hit");
    //         return true;
    //     }
    //     else{
    //         Debug.Log("We no hit");
    //         return false;
    //     }
    // }
}

