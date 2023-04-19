using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Monster Parsing Data
[System.Serializable]
class Monster{
    public int monster_count;
    public List<int> types;
    public List<float> locationsX;
    public List<float> locationsY;
}

[System.Serializable]
class ChunkList{
        public Chunk[] Chunks;
}

[System.Serializable]
class Chunk{
    public int ID;
    public float b1X;
    public float b1Y;
    public float b2X;
    public float b2Y;
    public Monster[] MonsterSet;
}

public class ChunkScript : MonoBehaviour {
    public int renderDistance = 0;

    public GameObject[] monster;
    public GameObject[] cl;

    public static List<GameObject> chunks = new List<GameObject>();
    public static List<GameObject> loadedChunks = new List<GameObject>();

    private ChunkList chunkList;

    //Spawn a monster with an ID of ID, at position (x,y), with type of typenum
    void SpawnMonster(int ID, float x, float y, int typeNum) {

        GameObject monsterInstance = (GameObject) Instantiate(monster[typeNum], new Vector3(x, y, 0), transform.rotation);
        monsterInstance.SetActive(true);
        monsterInstance.GetComponent<MonsterScript>().setUpMonster(typeNum, ID);
    }

    //Loading Monsters of Chunk ID with monster set MonsterSet
    void LoadMonsters(int ID, Monster[] monsterset) {
        foreach(Monster m in monsterset){
            for(int i=0; i<m.monster_count;i++) {
                SpawnMonster(ID, m.locationsX[i], m.locationsY[i], m.types[i]-1);
            }
             
         }
    }


    //Set Up Script
    public void startScript() {
        for(int i=0;i<cl.Length;i++) {
            chunks.Add(cl[i]);
        }

        string path = Application.dataPath + "/JSON/ChunkData.json";

        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path);

        chunkList = JsonUtility.FromJson<ChunkList> (jsonString);
        }
    }    

    public List<int> LoadChunk(float xPos, float yPos) {
        List<int> chunksloaded = new List<int>();
            foreach(Chunk c in chunkList.Chunks){
                if((c.b1X - renderDistance < xPos && c.b2X + renderDistance > xPos && c.b1Y - renderDistance< yPos && c.b2Y + renderDistance > yPos)) {
                    if(!loadedChunks.Contains(chunks[c.ID-1])) {
                    chunks[c.ID-1].SetActive(true);
                    loadedChunks.Add(chunks[c.ID-1]);
                    LoadMonsters(c.ID, c.MonsterSet);
                    }

                }else{
                    loadedChunks.Remove(chunks[c.ID-1]);
                    chunks[c.ID-1].SetActive(false);
                }       
         }
        return chunksloaded;
    }
    
    

    public void ManageChunks(float x, float y) {
        LoadChunk(x,y);
        
        }
}

