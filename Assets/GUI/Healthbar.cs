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
        FS.adjustColor();
    }

    public void setHealth(int setterValue) {
        GetComponent<Slider>().value = setterValue;        
        FS.adjustColor();
    }

    public float getValue() {
        return GetComponent<Slider>().value;
    }

    public float getMaxValue() {
        return GetComponent<Slider>().maxValue;
    }
}
