using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    PlayerInput Input;
    InputAction ToLookX;
    InputAction ToLookY;
    public float Sensitivity;
    private float xRotate;
    private float yRotate;

    public Transform body;


    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<PlayerInput>();
        ToLookX = Input.actions.FindAction("MouseX_Axis");
        ToLookY = Input.actions.FindAction("MouseY_Axis");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        ToLook();
    }

    void ToLook(){
        float ReadLookX = ToLookX.ReadValue<float>();
        float ReadLookY = ToLookY.ReadValue<float>();
        float MouseX_Axis = ReadLookX * Sensitivity * Time.deltaTime;
        float MouseY_Axis = ReadLookY * Sensitivity * Time.deltaTime;

        xRotate -= MouseY_Axis;
        xRotate = Mathf.Clamp(xRotate,-90f,90f);
        yRotate += MouseX_Axis;

        transform.localRotation = Quaternion.Euler(xRotate, 0f, z:0f);
        body.Rotate(Vector3.up * MouseX_Axis);



    }
}
