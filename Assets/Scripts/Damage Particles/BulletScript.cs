using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : DamageParticle
{
    public float bulletSpeed = 20f;

    //Start range Timer and set damage
    void Start() {
        setRange(1);
        setDMG(3 + launcher.GetComponent<Entity>().getATK());
    }

    //When crash
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Entity>() != null) {
            if(collision.gameObject.name != launcher.name) {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Entity>().TakeDamage(dmg);
            }
        }else if(collision.gameObject.tag == "Obstacle (Stationary)") {
            Destroy(gameObject);
        }
    }
    
    // Move until range timer is up
     void Update() {
        if(GameController.running == 2) {
        //transform.position += (transform.right * bulletSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed * Time.deltaTime * 700);
        timerCheck();
     }
     
     
 }

}