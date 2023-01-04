using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : Entity
{
    public GameObject bullet;

    // Start is called before the first frame update
    public void Fire() {
        GameObject bulletClone = (GameObject) Instantiate(bullet, transform.position + transform.right * 2f, transform.rotation);
        bulletClone.SetActive(true);
     }
    // Update is called once per frame
}
