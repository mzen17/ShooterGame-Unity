using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : DamageParticle
{
    float movingDown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        setRange(0.2f);
        setDMG(5 + launcher.GetComponent<Entity>().getATK());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Entity>() != null) {
            if(collision.gameObject.name != launcher.name)
            collision.gameObject.GetComponent<Entity>().TakeDamage(dmg);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(launcher == null) {
            Destroy(gameObject);
        }else{
        transform.rotation = launcher.transform.rotation;
        transform.position = launcher.transform.position + launcher.transform.right*2f + transform.up * movingDown;
        movingDown-=Time.deltaTime*8.5f;
        timerCheck();
        }
    }
}
