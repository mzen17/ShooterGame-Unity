using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public int ID;

    public void clicked() {
        gameObject.transform.parent.gameObject.GetComponent<choice_switch>().setIndex(ID);
    }

    public void SetText(string s) {
        transform.GetChild(0).gameObject.GetComponent<Text>().text = s;
    }
}
