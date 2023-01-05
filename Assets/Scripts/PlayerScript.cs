using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

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
    public int playerID;
    public string cname;

    //Load Stats
    public void setUpPlayer() {
        string path = Application.dataPath + "/JSON/GlobalDB.json";
        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            CList M = JsonUtility.FromJson<CList>(jsonString);
            setSPEED(M.Characters[playerID].SPEED);
            setMaxHP(M.Characters[playerID].HP);
            setHP(M.Characters[playerID].HP);
            setATK(M.Characters[playerID].ATK);
            setDEF(M.Characters[playerID].DEF);
            cname = M.Characters[playerID].name;
            healthbar.setMaxHealth(getHP());
        }else{
            Debug.Log("GlobalDB.json does not exist");
        }
    }

    public void LoadPlayer() {
        healthbar.setMaxHealth(getMaxHP());
        healthbar.setHealth(getHP());
    }

    //Updates
    public void exist() {
        //Movement Controls

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directPos = new Vector2(transform.position.x, transform.position.y);

        transform.right = direction - directPos;
        //GetComponent<Rigidbody2D>().rotation = direction - directPos; //Rigid Body method

        
        Vector3 arrows = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //transform.position += (arrows*Time.deltaTime * getSPEED());
        GetComponent<Rigidbody2D>().AddForce(arrows*Time.deltaTime * getSPEED() * 4000);

        //Combat Controls
        if (Input.GetMouseButtonDown(0))
            if (!EventSystem.current.IsPointerOverGameObject())
            Attack(gameObject);


    }
}
