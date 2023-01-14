using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    public Healthbar healthbar;
    public int HP;
    int maxHP;
    int SPEED;
    int DEF;
    int ATK;
    bool canTakeDamage = true;

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
    public int getMaxHP() {
        return maxHP;
    }
    public void setMaxHP(int mH) {
        maxHP = mH;
    }
    //Damage Function
    public void dmgState(bool state) {
        canTakeDamage = state;
    }
    public void TakeDamage(int damage) {
        //transform.position += -1 * transform.right * 2f;
        if(canTakeDamage) {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.right * 10f;
        setHP(getHP()-damage);
        healthbar.setHealth(getHP());
        }
    }
}
