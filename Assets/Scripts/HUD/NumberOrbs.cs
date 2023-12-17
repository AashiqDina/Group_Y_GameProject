using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOrbs : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Awake(){
        text.text = 0.ToString();
    }
    public void changeText(int NoOrbs)
    {
        text.text = NoOrbs.ToString(); 
    }
}
