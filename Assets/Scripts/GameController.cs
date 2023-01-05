using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] players;
    public GameObject activePlayer;
    public List<GameObject> inactivePlayers;
    public int currentIndex = 0;
    public Camera maincam;

    void Start() {
           for(int i=0; i<players.Length; i++) {
            if(i == currentIndex) {
                players[i].SetActive(true);
                activePlayer = players[i];
            }else{
                inactivePlayers.Add(players[i]);
                players[i].SetActive(false);

                }
            }

            switchToIndex(2);
            switchToIndex(1);
            switchToIndex(0);
    }


    public void switchToIndex(int index) {
        if(currentIndex != index) {
                players[currentIndex].SetActive(false);
                players[index].SetActive(true);
                players[index].transform.position = players[currentIndex].transform.position;
                players[index].transform.rotation = players[currentIndex].transform.rotation;
                players[index].GetComponent<PlayerScript>().LoadPlayer();
                activePlayer = players[currentIndex];

                inactivePlayers.Remove(players[index]);
                inactivePlayers.Add(players[currentIndex]);

                currentIndex = index;
            }
    }

    // Check Change
    void Update() {
        if(Input.GetKey("1")) {
            switchToIndex(0);

        }else if(Input.GetKey("2")) {
            switchToIndex(1);
        }else if(Input.GetKey("3")) {
            switchToIndex(2);
        }

        //Camera Movement
        Vector3 MainPos = players[currentIndex].transform.position;
        MainPos.z = -10f;
        
        maincam.transform.position = MainPos;
    }
}
