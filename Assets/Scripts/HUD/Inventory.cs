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
    private bool IsOpen = false;
    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        TheInventory = input.Inventory;
        OpenCloseInv = TheInventory.OpenCloseInventory;
        
        InventoryObject = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        InventoryObject.SetActive(false);
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
        if (OpenCloseInv.triggered && OpenCloseInv.ReadValue<float>() > 0 && !IsOpen){
            InventoryObject.SetActive(true);
            IsOpen = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = false;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = false;
        }
        else if(OpenCloseInv.triggered && OpenCloseInv.ReadValue<float>() > 0 && IsOpen){
            InventoryObject.SetActive(false);
            IsOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = true;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = true;
            
        }
    }
}
