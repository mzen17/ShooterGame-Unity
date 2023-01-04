using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : RangedUnit
{

    //Set Base Stats
    void Start() {
    setSPEED(6);
    setHP(100);
    setATK(10);
    setDEF(100);
    healthbar.setMaxHealth(getHP());
    }

    //Updates
    void Update() {
        //Movement Controls

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directPos = new Vector2(transform.position.x, transform.position.y);

        transform.right = direction - directPos;

        
        Vector3 arrows = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += (arrows*Time.deltaTime * getSPEED());

        //Combat Controls
        if (Input.GetButtonDown("Fire1"))
            Fire();


    }
}
