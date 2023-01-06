using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

//ID 0 for MC
//ID 1 for MFL
//ID 2 for SMC

[System.Serializable]
class Character{
    public string name;
    public int HP;
    public int SPEED;
    public int DEF;
    public int ATK;
    public float CD;
}

[System.Serializable]
class CList{
    public Character[] Characters;
}

public class PlayerScript : AttackerUnit
{
    public string cname;
    public bool a;
    public int playerID;    


    //Load Stats
    public void setUpPlayer(int ID, bool status) {
        string path = Application.dataPath + "/JSON/GlobalDB.json";
        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            CList M = JsonUtility.FromJson<CList>(jsonString);

            setSPEED(M.Characters[ID].SPEED);
            setMaxHP(M.Characters[ID].HP);
            setHP(M.Characters[ID].HP);
            setATK(M.Characters[ID].ATK);
            setDEF(M.Characters[ID].DEF);
            a = status;
            cname = M.Characters[ID].name;
            playerID = ID;
        }else{
            Debug.Log("GlobalDB.json does not exist");
        }
    }


    //Change HP Bar on load
    public void LoadPlayer() {
        healthbar.setMaxHealth(getMaxHP());
        healthbar.setHealth(getHP());
    }

    //Updates
    private void Move() {
        if(GameController.running >= 1) {
        //Movement Controls

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directPos = new Vector2(transform.position.x, transform.position.y);

        transform.right = direction - directPos;
        //GetComponent<Rigidbody2D>().rotation = direction - directPos; //Rigid Body method

        
        Vector3 arrows = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //transform.position += (arrows*Time.deltaTime * getSPEED());
        GetComponent<Rigidbody2D>().AddForce(arrows*Time.deltaTime * getSPEED() * 4000);
        }
    }

    private void Attack() {
          //Combat Controls
        if (GameController.running == 2 && Input.GetMouseButtonDown(0))
            if (!EventSystem.current.IsPointerOverGameObject())
            Attack(gameObject);
    }

    void Update() {
        Move();
        Attack();
    }
}
