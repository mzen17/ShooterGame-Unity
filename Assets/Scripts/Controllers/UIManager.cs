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
    public choice_switch cs;
    public Text description;
    public bool waitingForResponse = false;
    public bool recievedResponse = false;
    public int responseValue = 0;

    public void UIRPG(string message) { //Change to 
        GUI_Index = 1;
        changeToUI(GUI_Index);
        description.text = message;
        GameController.gameSet(1);
    }

    public void MainMenu(bool on) {
        if(on) {
            changeToUI(0);
        }else {
            if(prevIndex >= 0){
                changeToUI(prevIndex);
            }else {
                changeToUI(-1);
            }
        }
    }

    public void changeToUI(int index) {
        prevIndex = GUI_Index;
        if(index >= 0) {
        for(int i=0;i<GUIs.Length;i++) {
            if(i != index) {
                GUIs[i].SetActive(false);
            }else{
                GUIs[i].SetActive(true);
            }
        }
        GUI_Index = index;
     }else{
        for(int i=0;i<GUIs.Length;i++) {
                GUIs[i].SetActive(false);
        
            }
            GUI_Index = -1;
        }
    
    
    }

    public void createChatOptions(List<message> requests) {
        recievedResponse = false;
        waitingForResponse = true;
        GUIs[1].SetActive(true);
        List<string> messages = new List<string>();
        int s = 0;

        foreach(message m in requests) {
            messages.Add(m.s);
            s++;
        }

        cs.Load(messages, s);
        Debug.Log(string.Join(",", messages));

        if(Input.GetKeyDown(KeyCode.Space)) {
            recievedResponse = true;
            waitingForResponse = false;
            responseValue = cs.GetEnd();

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
