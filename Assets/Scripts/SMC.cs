using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMC : PlayerScript
{
    // Start is called before the first frame update
    void Start()
    {
        playerID = 2;
        setUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        exist();
    }
}
