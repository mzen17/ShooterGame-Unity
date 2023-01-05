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
class MonsterGroup{
        public Monster[] MonsterSet;
}

public class ChunkScript : MonoBehaviour
{
    public GameObject[] monster;

    void SpawnMonster(float x, float y, int typeNum) {
        GameObject monsterInstance = (GameObject) Instantiate(monster[typeNum], new Vector3(x, y, 0), transform.rotation);
        monsterInstance.SetActive(true);
    }

    // Start is called before the first frame update
    void Start() {
        string path = Application.dataPath + "/JSON/MonstersMapChunk1.json";
        if(File.Exists(path)) {
            string jsonString = File.ReadAllText(path); 
            MonsterGroup monsterset = JsonUtility.FromJson<MonsterGroup> (jsonString);
            foreach(Monster m in monsterset.MonsterSet){
             for(int i=0; i<m.monster_count;i++) {
                SpawnMonster(m.locationsX[i], m.locationsY[i], m.types[i]-1);
             }
             
         }
        }
    }

}
