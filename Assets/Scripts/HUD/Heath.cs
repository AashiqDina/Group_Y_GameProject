using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heath : MonoBehaviour
{
    private Slider slider;

    public void ChangeHealth(int hp)
    {
        slider.value = hp;
    }
    
}
