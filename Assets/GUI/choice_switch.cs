using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choice_switch : MonoBehaviour
{
    public int activeChoice = 0;
    public GameObject[] choices;
    int size = 0;

    public void Load(List<string> sets, int n){
        for(int i=0;i<n;i++) {
            if(i < n) {
                choices[i].SetActive(true);
                choices[i].GetComponent<Choice>().SetText(sets[i]);
            }else{
                choices[i].SetActive(false);
            }
        }
        size = n;
    }

    public void scrollDown() {
        activeChoice = (activeChoice + size - 1) % size;
        for(int i = 0; i<size;i++) {
                turnOn(i, i == activeChoice);
        }
    }

    public void scrollUp() {
        activeChoice = (activeChoice + 1) % size;
        for(int i = 0; i<size;i++) {
                turnOn(i, i == activeChoice);
        }
    }

    public void setIndex(int set) {
        activeChoice = set;
        for(int i = 0; i<size;i++) {
                turnOn(i, i == activeChoice);
        }
    }

    public void turnOn(int n, bool f) {
        if(f) {
            //make choice more visible
        }else{
            //make choice less visible
        }
    }

    public void Unload() {
        foreach(GameObject g in choices) {
            g.SetActive(false);
        }
        size = 0;

        gameObject.SetActive(false);
    }

    public int GetEnd() {
        Unload();
        return activeChoice;
    }
}
