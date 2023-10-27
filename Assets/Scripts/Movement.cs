using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    PlayerInput Input;
    InputAction Move;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<PlayerInput>();
        Move = Input.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove(){
        Vector2 toMove = Move.ReadValue<Vector2>();
        transform.position += new Vector3(toMove.x, 0, toMove.y) * Speed * Time.deltaTime;
    }
}

