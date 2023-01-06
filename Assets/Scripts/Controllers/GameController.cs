using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public ChunkScript ChunkLoader;
    public GameObject mainMenuCanvas;
    public int currentIndex = 0;
    public Switch s;
    public int oldRun;
    public static int running{ get; private set;}
 
    void Start() {
        ChunkLoader.startScript();
        PlayerController.ps.setUpPlayers();
        

        running = 2;

        ChunkLoader.LoadChunk(PlayerController.ps.activeMember.transform.position.x, PlayerController.ps.activeMember.transform.position.x);
        mainMenuCanvas.SetActive(false);
    }

    public void gameSet(int N) {
        if(N>=0 && N<=2) {
            running = N;
        }
    }


    // Check Change
    void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                int tempRun = running;
                gameSet((running == 0) ? oldRun : 0);
                oldRun = tempRun;
                Debug.Log("RUN: " + running);

                if(running == 0) {
                    mainMenuCanvas.SetActive(true);
                }else{
                    mainMenuCanvas.SetActive(false);
                }
            }

            PlayerController.ps.updateStatus();

            s.UpdateBar();
        }
    
}


