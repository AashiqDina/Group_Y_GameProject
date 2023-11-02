using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    PlayerInput Input;
    InputAction ForwardsBack;
    InputAction RightLeft;
    public Rigidbody rb;
    public float Speed;



    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<PlayerInput>();
        ForwardsBack = Input.actions.FindAction("MoveX");
        RightLeft = Input.actions.FindAction("MoveZ");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove(){
        float MoveForwardsBack = ForwardsBack.ReadValue<float>() * Speed;
        float MoveRightLeft = RightLeft.ReadValue<float>() * Speed;
        Vector3 move = (transform.right * MoveRightLeft) + (transform.forward * MoveForwardsBack);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}

