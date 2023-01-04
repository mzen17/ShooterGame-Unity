using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float bulletRange = 1; //seconds
    int bulletATK = 3;
    float TimeLaunched = 0f;

    // Start range Timer
    void Start()
    {
        TimeLaunched = 0f;

    }

    // Self destruct on collision to anything
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        //Check for a match with the specific tag on any GameObject that collides with your GameObject

        if (collision.gameObject.GetComponent<Entity>() != null) {
            collision.gameObject.GetComponent<Entity>().TakeDamage(bulletATK);

            if(collision.gameObject.GetComponent<Entity>() == null) {
                Debug.Log("Sht");
            }
        }
    }

    // Move until range timer is up
     void Update()
     {
        transform.position += (transform.right * bulletSpeed * Time.deltaTime);
        
        TimeLaunched += Time.deltaTime;



        if(TimeLaunched > bulletRange) {
            Destroy(gameObject);
        }
     }
     
 }

