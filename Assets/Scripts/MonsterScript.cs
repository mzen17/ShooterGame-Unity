using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : RangedUnit
{ 
    [SerializeField] private LayerMask Player;
    float coolDown;

    // Start is called before the first frame update
    void Start() {
    setSPEED(2);
    setHP(100);
    setATK(10);
    setDEF(100);
    coolDown = 0;
    }

    Vector2 LookForBlood(int radius) {
        Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.position, 7f, Player);   
            return new Vector2(colliders[0].gameObject.GetComponent<Transform>().position.x,colliders[0].gameObject.GetComponent<Transform>().position.y);
    }
    
    bool BloodScan(int radius) {
         Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.position, 7f, Player);
        if(colliders.Length > 0)
        {
            return true;
        }else{
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        Vector2 directPos = new Vector2(transform.position.x, transform.position.y);

        if(BloodScan(7)) {
        Vector2 direction = LookForBlood(7);

        transform.right = direction - directPos;
        transform.position += transform.right * getSPEED() * Time.deltaTime;
        if(coolDown <= 0) {
        Fire();
        coolDown = 3;
        }else{
            coolDown -= Time.deltaTime;
        }
        }else if(coolDown > 0){
            coolDown -= Time.deltaTime;
        }
        if(getHP() < 0) {
            Destroy(gameObject);
        }
    }
}
