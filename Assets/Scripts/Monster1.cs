using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonsterScript
{
    // Start is called before the first frame update
    void Start()
    {
        setUpMonster(0);
    }

    // Update is called once per frame
    void Update()
    {
        exist();
    }
}
