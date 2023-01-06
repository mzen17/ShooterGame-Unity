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
        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 1) {
            RectTransform c = control1.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team[0].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;
        }
        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 2) {
            RectTransform c = control2.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team[1].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;
        }
        if(PlayerController.ps.GetComponent<PlayerController>().team.Count >= 3) {
            RectTransform c = control3.GetComponent<RectTransform>(); //Get this canvasbase
            PlayerScript ps = PlayerController.ps.team[2].GetComponent<PlayerScript>();

            c.GetChild(0).gameObject.GetComponent<Image>().sprite = characterIcon[ps.playerID];
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setMaxHealth(ps.getMaxHP());
            c.GetChild(1).gameObject.GetComponent<Healthbar>().setHealth(ps.getHP());
            c.GetChild(2).gameObject.GetComponent<Text>().text = ps.cname;
        }
    }
}
