using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private Input input;
    private Input.InventoryActions TheInventory;
    private InputAction OpenCloseInv;
    private GameObject InventoryObject;
    private GameObject Camera;
    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        TheInventory = input.Inventory;
        OpenCloseInv = TheInventory.OpenCloseInventory;
        
        InventoryObject = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        InventoryObject.SetActive(false);
        Camera = GameObject.Find("Player").transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInventory();
    }

    private void OnEnable()
    {
        TheInventory.Enable();
    }

    void UpdateInventory(){
        if (OpenCloseInv.triggered && OpenCloseInv.ReadValue<float>() > 0 && InventoryObject.activeSelf == false){
            InventoryObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = false;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = false;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);

        }
        else if(OpenCloseInv.triggered && OpenCloseInv.ReadValue<float>() > 0 && InventoryObject.activeSelf == true){
            InventoryObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = true;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = true;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
            if(Camera.GetComponent<CameraRaycast>().GetObject(100).tag == "Chest"){
                Camera.GetComponent<CameraRaycast>().GetObject(100).transform.GetChild(0).gameObject.SetActive(false);
            }
            InventoryObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
