using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public ChunkScript ChunkLoader;
    public int currentIndex = 0;
    public Switch s;
    public int oldRun;
    public static int running{ get; private set;}
 
    void Start() {
        ChunkLoader.startScript();
        PlayerController.ps.setUpPlayers();
        

        running = 2;


        PlayerController.ps.AddPlayer(0);
        PlayerController.ps.AddPlayer(1);
        PlayerController.ps.AddPlayer(2);

    }

    public static void gameSet(int N) {
        if(N>=0 && N<=3) {
            running = N;
        }
    }


    // Check Change
    void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                int tempRun = running;
                gameSet((running == 0) ? oldRun : 0);
                oldRun = tempRun;

                if(running == 0) {
                    UIManager.ui.MainMenu(true);
                }else{
                    UIManager.ui.MainMenu(false);
                }
            }
           ChunkLoader.LoadChunk(PlayerController.ps.activeMember.transform.position.x, PlayerController.ps.activeMember.transform.position.y);
            PlayerController.ps.updateStatus();

            s.UpdateBar();
        }
    
}


