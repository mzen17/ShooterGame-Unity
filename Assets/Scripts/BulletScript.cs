using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : DamageParticle
{
    public float bulletSpeed = 20f;

    // Start range Timer
    void Start()
    {
        setRange(1);
        setDMG(3 + launcher.GetComponent<Entity>().getATK());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.GetComponent<Entity>() != null) {
            if(collision.gameObject.name != launcher.name)
            collision.gameObject.GetComponent<Entity>().TakeDamage(dmg);
        }
    }
    
    // Move until range timer is up
     void Update()
     {
        //transform.position += (transform.right * bulletSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed * Time.deltaTime * 700);
        timerCheck();
     }
     
 }

