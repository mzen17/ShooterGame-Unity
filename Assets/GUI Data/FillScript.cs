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
            Debug.Log("LOW HP");
            GetComponent<Image>().sprite = lowHP;

        }else if(slide.value * 3 > slide.maxValue*2) {
            Debug.Log("HIGH HP");
            GetComponent<Image>().sprite = highHP;

        }else {
            Debug.Log("MEDIUM HP");
            GetComponent<Image>().sprite = mediumHP;

        }
    }
}
