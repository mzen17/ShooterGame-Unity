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
    public float SR;
    public float ATKR;
}

[System.Serializable]
class MList{
    public monster[] MonsterTypes;
}


public class MonsterScript : AttackerUnit { 
    [SerializeField] private LayerMask Player;
    float coolDown;
    int chunkID;
    float timer;
    float range;
    float atkrange;
    bool runnable;
    Vector2 spawnLocation;

    //Setting up monster
    public void setUpMonster(int type, int ChunkID) {
        string path = Application.dataPath + "/JSON/GlobalDB.json";
        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            MList M = JsonUtility.FromJson<MList>(jsonString);
            setSPEED(M.MonsterTypes[type].SPEED);
            setMaxHP(M.MonsterTypes[type].HP);
            setHP(M.MonsterTypes[type].HP);
            setATK(M.MonsterTypes[type].ATK);
            setDEF(M.MonsterTypes[type].DEF);
            atkrange = M.MonsterTypes[type].SR;

            range = M.MonsterTypes[type].RAD;
            coolDown = M.MonsterTypes[type].CD;
            spawnLocation = new Vector2(transform.position.x, transform.position.y);
            chunkID = ChunkID;
        }
        healthbar.setMaxHealth(getMaxHP());
        healthbar.setHealth(getHP());


        }

    //Turns Entity to face player
    public void LookForBlood(Vector2 location, float radius) {
 
            Vector2 directPos = new Vector2(transform.position.x, transform.position.y);
            Collider2D colliders = Physics2D.OverlapCircle(location, radius, Player);   
            if(colliders != null) {
                
            Vector2 direction = new Vector2(colliders.gameObject.GetComponent<Transform>().position.x,colliders.gameObject.GetComponent<Transform>().position.y);
            transform.right = direction - directPos;
            }else{
            }
        
        }
    
    //Detect if player is there
    public bool BloodScan(Vector2 point, float radius) {
        Collider2D colliders = Physics2D.OverlapCircle(point, radius, Player);
        if(colliders != null)
        {
            return true;
        }else{
            return false;
        }
    }

    
    //Calculations for the monster
    public void exist() {
        Vector2 locationNow = new Vector2(transform.position.x, transform.position.y);
        if(GameController.running == 2) { //If game is running
            if(ChunkScript.loadedChunks.IndexOf(ChunkScript.chunks[chunkID-1]) == -1 || getHP() <= 0) //if not in chunk or HP is smaller or equal to 0, destroy
                Destroy(gameObject);
            
        LookForBlood(locationNow, 0.8f*range + atkrange); 

        if(!BloodScan(locationNow, atkrange))
        if(BloodScan(spawnLocation, 0.8f * range + atkrange)) {
            dmgState(true);
                if(Vector2.Distance(spawnLocation, locationNow) < (range)) {
                    GetComponent<Rigidbody2D>().AddForce(transform.right * getSPEED() * Time.deltaTime * 10000f);
                }else if(Vector2.Distance(spawnLocation, locationNow) > (range) && Vector2.Distance(spawnLocation, locationNow) < Vector2.Distance(spawnLocation, locationNow + (Vector2) transform.right)) {
                }else{
                    GetComponent<Rigidbody2D>().AddForce(transform.right * getSPEED() * Time.deltaTime * 10000f);
                }

        } else if(!(BloodScan(spawnLocation, 0.8f*range + atkrange)) && Vector2.Distance(spawnLocation, locationNow) > 0.2f){
            dmgState(false);
            transform.right = spawnLocation - locationNow;
            GetComponent<Rigidbody2D>().AddForce(transform.right * getSPEED() * Time.deltaTime * 5000f);
        }else{
            healthbar.setHealth(getMaxHP());
            setHP(getMaxHP());
            dmgState(false);
        }

        
        
        
        if(timer <= 0 && BloodScan(locationNow, atkrange)) {
                Attack(gameObject);
                timer = coolDown;
                }else if(coolDown > 0){
                    timer -= Time.deltaTime;
        }
             }
            }
}
    


