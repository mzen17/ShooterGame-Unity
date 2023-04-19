using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticle : MonoBehaviour
{
    public float range=5f; //seconds
    public int dmg;
    public float TimeLaunched = 0f;
    public GameObject launcher;

    public void setSafe(GameObject l) {
        launcher = l;
    }

    public void setDMG(int damage) {
        dmg = damage;
    }

    public void setRange(float r) {
        range = r;
    }

    // Self destruct on collision to anything

    public void addATK(int bonusATK) {
        dmg += bonusATK;
    }

    public void timerCheck() {
        TimeLaunched += Time.deltaTime;

        if(TimeLaunched > range) {
            Destroy(gameObject);
        }
    }

}
