using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillScript : MonoBehaviour
{
    public Sprite highHP;
    public Sprite mediumHP;
    public Sprite lowHP;
    public Slider slide;

    public void adjustColor() {
        if (slide.value * 3 < slide.maxValue) {
            GetComponent<Image>().sprite = lowHP;

        }else if(slide.value * 3 > slide.maxValue*2) {
            GetComponent<Image>().sprite = highHP;

        }else {
            GetComponent<Image>().sprite = mediumHP;

        }
    }
}
