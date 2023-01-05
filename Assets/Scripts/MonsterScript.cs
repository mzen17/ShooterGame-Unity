using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
class monster{
    string name;
    public int HP;
    public int SPEED;
    public int DEF;
    public int ATK;
    public float CD;
    public float RAD;
}

[System.Serializable]
class MList{
    public monster[] MonsterTypes;
}





public class MonsterScript : AttackerUnit
{ 
    [SerializeField] private LayerMask Player;
    float coolDown;
    float timer;
    float range;
    Vector2 spawnLocation;

    //Setting up monster
     public void setUpMonster(int type) {
        string path = Application.dataPath + "/JSON/GlobalDB.json";
        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            MList M = JsonUtility.FromJson<MList>(jsonString);
            setSPEED(M.MonsterTypes[type].SPEED);
            setMaxHP(M.MonsterTypes[type].HP);
            setHP(M.MonsterTypes[type].HP);
            setATK(M.MonsterTypes[type].ATK);
            setDEF(M.MonsterTypes[type].DEF);
            range = M.MonsterTypes[type].RAD;
            coolDown = M.MonsterTypes[type].CD;
            spawnLocation = new Vector2(transform.position.x, transform.position.y);
        }
        healthbar.setMaxHealth(getMaxHP());
    }

    //Turns Entity to face player
    public void LookForBlood(float radius) {
        if(BloodScan(range)) {
            Vector2 directPos = new Vector2(transform.position.x, transform.position.y);
            Collider2D colliders = Physics2D.OverlapCircle(transform.position, radius, Player);   
            Vector2 direction = new Vector2(colliders.gameObject.GetComponent<Transform>().position.x,colliders.gameObject.GetComponent<Transform>().position.y);
            transform.right = direction - directPos;
        }
    }
    
    //Detect if player is there
    public bool BloodScan(float radius) {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, 7f, Player);
        if(colliders != null)
        {
            return true;
        }else{
            return false;
        }
    }

    //Calculations for the monster
    public void exist() {
        if(BloodScan(range)) {
            LookForBlood(range);

            //if(BloodScan(2f) == false) {
                GetComponent<Rigidbody2D>().AddForce(transform.right * getSPEED() * Time.deltaTime * 6000f);
                //transform.position += transform.right * getSPEED() * Time.deltaTime;
                Debug.Log(BloodScan(2f));
            //}

            if(timer <= 0) {
            Attack(gameObject);
            timer = coolDown;
        }else{
            timer -= Time.deltaTime;
        }
        }else if(coolDown > 0){
            timer -= Time.deltaTime;
        }
        if(getHP() < 0) {
            Destroy(gameObject);
        }
    }
}
