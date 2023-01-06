using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController ps;


    //Global constant variables
    public SortedList<int, GameObject> team = new SortedList<int, GameObject>();
    public SortedList<int, GameObject> idleTeam = new SortedList<int, GameObject>();
    public GameObject activeMember {get; private set;}


    //Local variables required for managing controller
    private int currentIndex = 0;
    [SerializeField] private GameObject[] playerList;
    [SerializeField] private Camera maincam;


   private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (ps != null && ps != this) 
    { 
        Destroy(this.gameObject); 
    } 
    else 
    { 
        ps = this; 
    } 
}

    

    //Sets up all the players
    public void setUpPlayers() {
        for(int i=0; i<playerList.Length; i++) { //iterate through the list of players
            if(i == currentIndex) { //If it matches the current index, then set player active
                playerList[i].GetComponent<PlayerScript>().setUpPlayer(i, true);
                activeMember = playerList[i];
                


            }else{ //Otherwise, put player into idle
                idleTeam.Add(i, playerList[i]);
                playerList[i].GetComponent<PlayerScript>().setUpPlayer(i, false);
                }
            }
    }

    public void AddPlayerTeam(int ID) {
        if(!team.ContainsValue(playerList[ID]))
        team.Add(ID, playerList[ID]);
        playerList[ID].GetComponent<PlayerScript>().a = false;
    }

    public void removePlayer(int ID) {
        team.Remove(ID);
        playerList[ID].GetComponent<PlayerScript>().a = false;
    }

    public void changeToMain(int ID) {
        if(currentIndex != ID) {
        playerList[currentIndex].GetComponent<PlayerScript>().a = false;
        playerList[ID].GetComponent<PlayerScript>().a = true;
        
        activeMember = playerList[ID];

        }
    }

    public void updateStatus() {
        if(GameController.running == 2) { //If game is running

            if(Input.GetKeyDown("1")) { //1 swaps
                if(team.Count > 1)
                if(playerList[System.Array.IndexOf(playerList, idleTeam[0])].GetComponent<Entity>().getHP() > 0) {

                changeToMain(System.Array.IndexOf(playerList, idleTeam[0]));

                }
            }else if(Input.GetKeyDown("2")) {
                if(team.Count > 2)
                if(playerList[System.Array.IndexOf(playerList, idleTeam[1])].GetComponent<Entity>().getHP() > 0) {

                changeToMain(System.Array.IndexOf(playerList, idleTeam[1]));
                }
            }

        }

            if(playerList[currentIndex].GetComponent<Entity>().getHP() < 0) {
                if(idleTeam.Count > 0) {
                    int saved = 0;

                    for(int i=0;i<idleTeam.Count;i++) {

                    if(System.Array.IndexOf(playerList, idleTeam[i]) != -1 && saved == 0) {
                        if(playerList[System.Array.IndexOf(playerList, idleTeam[i])].GetComponent<Entity>().getHP() > 0) {
                            changeToMain(System.Array.IndexOf(playerList, idleTeam[i]));
                            saved = 1;
                        }
                    }
                    }
                }
            }

            //Camera Movement
            Vector3 MainPos = activeMember.transform.position;
            MainPos.z = -10f;
        
            maincam.transform.position = MainPos;
        
    }
}
