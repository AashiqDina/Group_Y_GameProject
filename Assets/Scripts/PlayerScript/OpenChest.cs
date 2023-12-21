using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenChest : MonoBehaviour
{
    private Input input;
    private Input.OpenChestActions OpeningChest;
    private InputAction Open;
    public float PlayerChestRange;
    private GameObject Camera;
    private GameObject InventoryObject;
    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        OpeningChest = input.OpenChest;
        Open = OpeningChest.Open;

        Camera = GameObject.Find("Player").transform.GetChild(0).gameObject;
        InventoryObject = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        OpeningTheChest();
    }

    private void OnEnable()
    {
        OpeningChest.Enable();
    }

    void OpeningTheChest(){
        if(Camera.GetComponent<CameraRaycast>().GetObject(PlayerChestRange).tag == "Chest" && Open.triggered && Open.ReadValue<float>() > 0 && InventoryObject.activeSelf == false){
            InventoryObject.SetActive(true);
            InventoryObject.transform.GetChild(0).gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = false;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = false;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
        }
        else if(Camera.GetComponent<CameraRaycast>().GetObject(PlayerChestRange).tag == "Chest" && Open.triggered && Open.ReadValue<float>() > 0 && InventoryObject.activeSelf == true){
            InventoryObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = true;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = true;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        }
    }
}
