using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Sprite[] characterIcon;

    public GameObject control1;
    public GameObject control2;
    public GameObject control3;

    // Update is called once per frame
    public void UpdateBar() {
        Color32 dead = new Color32(0,0,0,255);
        Color32 alive = new Color32(255,255,255,255);

        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 1) {
            RectTransform c = control1.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team.Values[0].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;

            //Check Alive

            //Check Active

            if(ps.getHP() <= 0) {
                c.GetChild(0).gameObject.GetComponent<Image>().color = dead;
            }else {
                c.GetChild(0).gameObject.GetComponent<Image>().color = alive;
            }
        }
        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 2) {
            RectTransform c = control2.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team.Values[1].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;

            if(ps.getHP() < 0) {
                c.GetChild(0).gameObject.GetComponent<Image>().color = dead;
            }else {
                c.GetChild(0).gameObject.GetComponent<Image>().color = alive;
            }
        }
        
        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 3) {
            RectTransform c = control3.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team.Values[2].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;
        if(ps.getHP() < 0) {
                c.GetChild(0).gameObject.GetComponent<Image>().color = dead;
            }else {
                c.GetChild(0).gameObject.GetComponent<Image>().color = alive;
            }
        
        
        }
    }
}
