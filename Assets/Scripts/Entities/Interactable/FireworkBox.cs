using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
class CM{
    public C[] ConversationMap;
}

[System.Serializable]
class C{
    public string Object;
    public string Description;
    public string[] Conversation;
    public string[] ChainID;
    public int[] IDs;
    public string[] EndKeys;
}

public class FireworkBox : MonoBehaviour
{
    CTree conversation = new CTree();
    public bool interacting = false;
    // Start is called before the first frame update
    void obtainData() {
        string path = Application.dataPath + "/JSON/ConversationDB.json";

        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            CM M = JsonUtility.FromJson<CM>(jsonString);

            foreach(C c in M.ConversationMap) {
                
                if(c.Object == "Firework Box") {
                    for(int i=0;i<c.Conversation.Length;i++) {
                        conversation.insert(c.ChainID[i], c.Conversation[i], c.IDs[i]);
                    }

                    foreach(string key in c.EndKeys) {
                        conversation.AddEndResult(key);
                    }
                }

            }

        }else{
            Debug.Log("ConversationDB.json does not exist");
        }
    }

    void Interact() {
        int response = RPGEngine.Engine.alert(conversation);
        if (response > 0) { 
        //stuff
        }
    }

    void Start() {
        obtainData();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            interacting = true;
            Interact();
        }
    
    }

}
