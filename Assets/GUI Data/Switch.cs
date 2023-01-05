using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject controller;
    public Sprite[] characterIcon;

    public GameObject control1;
    public GameObject control2;


    // Update is called once per frame
    void Update()
    {
        

        if(controller.GetComponent<GameController>().inactivePlayers.Count >= 1) {
            control1.GetComponent<RectTransform>().GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[controller.GetComponent<GameController>().inactivePlayers[0].GetComponent<PlayerScript>().playerID];
            control1.GetComponent<RectTransform>().GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(controller.GetComponent<GameController>().inactivePlayers[0].GetComponent<PlayerScript>().getMaxHP());
            control1.GetComponent<RectTransform>().GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(controller.GetComponent<GameController>().inactivePlayers[0].GetComponent<PlayerScript>().getHP());

            if(controller.GetComponent<GameController>().inactivePlayers[0].GetComponent<PlayerScript>().playerID == 0) 
                control1.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "MC";
            else if(controller.GetComponent<GameController>().inactivePlayers[0].GetComponent<PlayerScript>().playerID == 1)
                control1.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "MFL";
            else
                control1.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "SMC";
        }

        if(controller.GetComponent<GameController>().inactivePlayers.Count >= 2) {
            control2.GetComponent<RectTransform>().GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[controller.GetComponent<GameController>().inactivePlayers[1].GetComponent<PlayerScript>().playerID];
            control2.GetComponent<RectTransform>().GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(controller.GetComponent<GameController>().inactivePlayers[1].GetComponent<PlayerScript>().getMaxHP());
            control2.GetComponent<RectTransform>().GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(controller.GetComponent<GameController>().inactivePlayers[1].GetComponent<PlayerScript>().getHP());

            if(controller.GetComponent<GameController>().inactivePlayers[1].GetComponent<PlayerScript>().playerID == 0) 
                control2.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "MC";
            else if(controller.GetComponent<GameController>().inactivePlayers[1].GetComponent<PlayerScript>().playerID == 1)
                control2.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "MFL";
            else
                control2.GetComponent<RectTransform>().GetChild(2).gameObject.GetComponent<Text>().text = "SMC";
        }
    }
}
