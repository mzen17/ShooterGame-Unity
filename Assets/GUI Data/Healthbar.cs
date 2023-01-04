using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public FillScript FS;


    public void setMaxHealth(int setterValue)
    {
        GetComponent<Slider>().maxValue = setterValue;
        GetComponent<Slider>().value = setterValue; 
        FS.adjustColor();
    }

    // Update is called once per frame
    public void setHealth(int setterValue) {
        GetComponent<Slider>().value = setterValue;        
        FS.adjustColor();
    }
}
