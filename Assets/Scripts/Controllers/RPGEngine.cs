using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEngine : MonoBehaviour
{
    public static RPGEngine Engine;
    public bool completed = true;
    public bool spaceHit = false;
    public string StartKey = "APEX";

    // Start is called before the first frame update
    public int alert(CTree conversation)
    {
        GameController.gameSet(1);
        UIManager.ui.changeToUI(1);
        completed = false;
   
        Conversation(conversation);

        if (completed) {
            GameController.gameSet(2);
            UIManager.ui.changeToUI(1);
            return UIManager.ui.responseValue;
        }
 
        return -1;
    }

    public void getResponse(List<message> responses) {
        Debug.Log(responses.Count);
        if (responses[0].id == 1)
            UIManager.ui.createChatOptions(responses);
        else
        {
            UIManager.ui.UIRPG(responses[0].s);
        }
    }

    void Update() {
        if(GameController.running == 1 && Input.GetKey(KeyCode.Space)) {
            spaceHit = true;
        }
    }

    public void Conversation(CTree conversation) { //Coroutine
        if (conversation.getValue(StartKey).Count > 0 && spaceHit == true)
        {
            spaceHit = false;
            StartKey = conversation.getValue(StartKey)[UIManager.ui.responseValue].s;//needs  a string
        }
        else if (conversation.getValue(StartKey).Count > 0 && spaceHit == false)
        {
            getResponse(conversation.getValue(StartKey));

        }
        else if (conversation.getValue(StartKey).Count <= 0) {
            completed = true;
        }

    }
    
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.

        if (Engine != null && Engine != this) { 
            Destroy(this.gameObject); 
        } else { 
            Engine = this; 
        } 
}
}
