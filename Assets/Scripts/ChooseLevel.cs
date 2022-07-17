using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text m_TextComponent;
    public Sprite unknownMedal; // I attched these from editor
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    public Color green;


    void Start()
    {
        GameObject[] clearText = GameObject.FindGameObjectsWithTag("clear_level_text");
        GameObject[] moveText = GameObject.FindGameObjectsWithTag("moves_level_text");
        GameObject[] medalImages = GameObject.FindGameObjectsWithTag("medal_image");
        GameObject[] playButtons = GameObject.FindGameObjectsWithTag("play_button");




        int i = 0;
        foreach (var level in PlayerStats.Levels) {
            if (level.stars == 0) {
                medalImages[i].GetComponent<Image>().sprite = unknownMedal;
            } else if(level.stars == 1) {
                medalImages[i].GetComponent<Image>().sprite = bronzeMedal;
            } else if(level.stars ==2) {
                medalImages[i].GetComponent<Image>().sprite = silverMedal;
            } else {
                medalImages[i].GetComponent<Image>().sprite = goldMedal;

            }
            if (!level.unlocked) {
                playButtons[i].SetActive(false);
            }
            if (PlayerStats.CurrentLevel == i+1) {
                Debug.Log(green);
                playButtons[i].GetComponent<Image>().color = green;
            }

            if (!level.cleared) {
                clearText[i].SetActive(false);
                moveText[i].SetActive(false);
            } else {
                clearText[i].SetActive(true);
                moveText[i].SetActive(true);
                m_TextComponent = moveText[i].GetComponent<TMP_Text>();
 
                // Change the text on the text component.
                m_TextComponent.text = level.numMoves.ToString()+ " moves";
            }
            i+=1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
