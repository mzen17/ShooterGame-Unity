using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;

    public GameObject[] GUIs;
    
    public int GUI_Index = -1;
    public int prevIndex = -1;
    public Image icon;
    public Text description;

    // Start is called before the first frame update
    public void UIRPG(string message)
    {
        GUI_Index = 1;
        changeToUI(GUI_Index);
        description.text = message;
        GameController.gameSet(1);
    }

    public void MainMenu(bool on) {
        Debug.Log("PREV IND IN ATTEMPT: " + prevIndex);
        if(on) {
            changeToUI(0);
        }else {
            if(prevIndex >= 0){
                Debug.Log("PASS0");
                changeToUI(prevIndex);
            }else {
                Debug.Log("PASS1");
                changeToUI(-1);
            }
        }
    }

    public void changeToUI(int index) {
        prevIndex = GUI_Index;
        Debug.Log("PI: " + prevIndex);
        if(index >= 0) {
        Debug.Log("switched");
        for(int i=0;i<GUIs.Length;i++) {
            if(i != index) {
                GUIs[i].SetActive(false);
            }else{
                GUIs[i].SetActive(true);
            }
        }
        GUI_Index = index;
     }else{
                Debug.Log("denied");

        for(int i=0;i<GUIs.Length;i++) {
                GUIs[i].SetActive(false);
        
            }
            GUI_Index = -1;
        }
    
    
    }
    
    

    public void Update() {
        if((GameController.running == 1 && Input.GetKeyDown(KeyCode.F)) && GUI_Index == 1) {
            changeToUI(-1);
            GameController.gameSet(2);
        }
    }

    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
    
        if (ui != null && ui != this) { 
        Destroy(this.gameObject); 
        } 
        else { 
        ui = this; 
        } 
    }
}
