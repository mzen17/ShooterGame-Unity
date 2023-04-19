using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerUnit : Entity
{
    public GameObject particle;

    // Start is called before the first frame update
    public void Attack(GameObject launcher) {
        GameObject particleClone = (GameObject) Instantiate(particle, transform.position + transform.right * 1.6f, transform.rotation);
        particleClone.SetActive(true);
        particleClone.GetComponent<DamageParticle>().setSafe(launcher);
     }
    // Update is called once per frame
}
