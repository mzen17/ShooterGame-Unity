using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEngine : MonoBehaviour
{
    public static RPGEngine Engine;
    // Start is called before the first frame update
    public void alert(string s)
    {
        UIManager.ui.UIRPG(s);
    }

    private void Awake() { 
    // If there is an instance, and it's not me, delete myself.
    
    if (Engine != null && Engine != this) 
    { 
        Destroy(this.gameObject); 
    } 
    else 
    { 
        Engine = this; 
    } 
}
}
