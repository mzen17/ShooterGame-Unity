using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : PlayerScript
{
    // Start is called before the first frame update
    void Start()
    {
        playerID = 0;
        setUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        exist();
    }
}
