using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public GameObject monster;

    void SpawnMonster() {
        GameObject monsterInstance = (GameObject) Instantiate(monster, new Vector3(-5,-0, 0), transform.rotation);
        monsterInstance.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
    }

    void Update()
    {
        
    }
}
