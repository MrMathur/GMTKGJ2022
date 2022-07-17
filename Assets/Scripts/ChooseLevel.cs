using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text m_TextComponent;
    public Sprite unknownMedal; // test attched these from editor
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    public Color green;
    private int test;
    [SerializeField] GameObject[] clearText;
    [SerializeField] GameObject[] moveText;
    [SerializeField] GameObject[] medalImages;
    [SerializeField] GameObject[] playButtons;

    void Start()
    {
        // GameObject[] clearText = GameObject.FindGameObjectsWithTag("clear_level_text");
        // GameObject[] moveText = GameObject.FindGameObjectsWithTag("moves_level_text");
        // GameObject[] medalImages = GameObject.FindGameObjectsWithTag("medal_image");
        // GameObject[] playButtons = GameObject.FindGameObjectsWithTag("play_button");


        test = 0;
        foreach (var level in PlayerStats.Levels) {
            if (level.stars == 0) {
                medalImages[test].GetComponent<Image>().sprite = unknownMedal;
            } else if(level.stars == 1) {
                medalImages[test].GetComponent<Image>().sprite = bronzeMedal;
            } else if(level.stars ==2) {
                medalImages[test].GetComponent<Image>().sprite = silverMedal;
            } else {
                medalImages[test].GetComponent<Image>().sprite = goldMedal;

            }
            if (!level.unlocked) {
                playButtons[test].SetActive(false);
            }
            if (PlayerStats.CurrentLevel == test + 1) {
                playButtons[test].GetComponent<Image>().color = green;
            }

            if (!level.cleared) {
                clearText[test].SetActive(false);
                moveText[test].SetActive(false);
            } else {
                clearText[test].SetActive(true);
                moveText[test].SetActive(true);
                m_TextComponent = moveText[test].GetComponent<TMP_Text>();
 
                // Change the text on the text component.
                m_TextComponent.text = level.numMoves.ToString()+ " moves";
            }
            test+=1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
