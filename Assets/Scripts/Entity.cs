using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    public Healthbar healthbar;
    int HP;
    int SPEED;
    int DEF;
    int ATK;

    // Update is called once per frame
    public int getSPEED() {
        return SPEED;
    }
    public void setSPEED(int s) {
        SPEED = s;
    }
    public int getHP() {
        return HP;
    }
    public void setHP(int h) {
        HP = h;
    }
    public int getATK() {
        return ATK;
    }
    public void setATK(int a) {
        ATK = a;
    }
    public int getDEF() {
        return DEF;
    }
    public void setDEF(int d) {
        DEF = d;
    }
    //Damage Function
    public void TakeDamage(int damage) {
        setHP(getHP()-damage);
        healthbar.setHealth(getHP());
    }
}
