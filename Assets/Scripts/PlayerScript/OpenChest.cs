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
    private GameObject ChestInv;
    private GameObject Chest;
    public int ChestInvUsed;
    public int NewChestInvUsed;
    public GameObject ChestInventory;
    public GameObject CurrentWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        OpeningChest = input.OpenChest;
        Open = OpeningChest.Open;

        Camera = GameObject.Find("Player").transform.GetChild(0).gameObject;
        InventoryObject = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        ChestInv = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
        ChestInvUsed = 0;
        CurrentWeapon = GameObject.Find("Player").gameObject.GetComponent<QuickSwitch>().CurrentWeapon;

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
            CurrentWeapon = GameObject.Find("Player").gameObject.GetComponent<QuickSwitch>().CurrentWeapon;
            CurrentWeapon.SetActive(false);
            InventoryObject.SetActive(true);
            InventoryObject.transform.GetChild(0).gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = false;
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = false;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Player").transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Chest = Camera.GetComponent<CameraRaycast>().GetObject(PlayerChestRange);
            Chest.transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Open", true);
            if (Chest.transform.GetChild(0).gameObject.transform.childCount > 0){
                Chest.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.parent = ChestInventory.transform.GetChild(0).gameObject.transform;
                ChestInvUsed += 1;
            }
            Debug.Log("ChestInv2: " + ChestInvUsed);
        }
        else if(Camera.GetComponent<CameraRaycast>().GetObject(PlayerChestRange).tag == "Chest" && Open.triggered && Open.ReadValue<float>() > 0 && InventoryObject.activeSelf == true){
            Debug.Log("Here 2");
            InventoryObject.transform.GetChild(0).gameObject.SetActive(true);
            InventoryObject.SetActive(false);
            CurrentWeapon.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<Look>().enabled = true;
            Chest.transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("Open", false);
            GameObject.Find("Player").gameObject.GetComponent<Movement>().enabled = true;
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            if((ChestInventory.transform.GetChild(0).gameObject.transform.childCount > 0)){
                ChestInventory.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.parent = Chest.transform.GetChild(0).gameObject.transform;
                NewChestInvUsed -= 1;
            }
            ChestInvUsed = NewChestInvUsed; 
        }
        if (Camera.GetComponent<CameraRaycast>().GetObject(10).name == "Mimick")
        {
            Camera.GetComponent<CameraRaycast>().GetObject(10).GetComponent<Mimick>().Activate();
        }
    }
}
