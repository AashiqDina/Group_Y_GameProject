using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSwitch : MonoBehaviour
{
    private Input input;
    private Input.QuickSwitchActions ToQuickSwitch;
    private InputAction One;
    private InputAction Two;
    private InputAction Three;
    private InputAction Four;
    private InputAction Five;
    private InputAction Six;
    public GameObject CurrentWeapon;
    private GameObject tempObject;

    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        ToQuickSwitch = input.QuickSwitch;
        One = ToQuickSwitch.SwitchOne;
        Two = ToQuickSwitch.SwitchTwo;
        Three = ToQuickSwitch.SwitchThree;
        Four = ToQuickSwitch.SwitchFour;
        Five = ToQuickSwitch.SwitchFive;
        Six = ToQuickSwitch.SwitchSix;
        CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeapons();
    }

        private void OnEnable()
    {
        ToQuickSwitch.Enable();
    }

    private void UpdateWeapons(){
        if (One.triggered && One.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsOne").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
                
            }
        if (Two.triggered && Two.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsOne").transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
               if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
        }
        if (Three.triggered && Three.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsOne").transform.GetChild(5).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
        }
        if (Four.triggered && Four.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsTwo").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
            }
        if (Five.triggered && Five.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsTwo").transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
            }   
        if (Six.triggered && Six.ReadValue<float>() > 0){
                CurrentWeapon.SetActive(false);
                tempObject = GameObject.Find("InventorySlotsTwo").transform.GetChild(5).gameObject.transform.GetChild(0).gameObject;
                if(tempObject.GetComponent<InvItem>().Item == "Sword"){
                    GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Gun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "LaserGun"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                }
                else if(tempObject.GetComponent<InvItem>().Item == "Wand"){
                    GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Hammer"){
                    GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(2).gameObject;
                }
                if(tempObject.GetComponent<InvItem>().Item == "Dagger"){
                    GameObject.Find("Player").transform.GetChild(3).gameObject.SetActive(true);
                    CurrentWeapon = GameObject.Find("Player").transform.GetChild(3).gameObject;
                }
            }
        
    }
}
