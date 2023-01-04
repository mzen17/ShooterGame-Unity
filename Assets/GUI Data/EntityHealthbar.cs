using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthbar : Healthbar
{
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.identity;

    }
}
