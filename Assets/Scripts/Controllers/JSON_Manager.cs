using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON_Manager : MonoBehaviour
{
    public static JSON_Manager JM;
    // Start is called before the first frame update
    void LoadJSONs()
    {
        
    }

        private void Awake() { 
        // If there is an instance, and it's not me, delete myself.

        if (JM != null && JM != this) { 
            Destroy(this.gameObject); 
        } else { 
            JM = this; 
        } 
}
}
