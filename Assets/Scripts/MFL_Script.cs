using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFL_Script : PlayerScript
{
    // Start is called before the first frame update
    void Start()
    {
        playerID = 1;
        setUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        exist();
    }
}
