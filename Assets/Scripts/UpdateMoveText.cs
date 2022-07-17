using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpdateMoveText : MonoBehaviour
{

    [SerializeField] private TMP_Text moveText;
    [SerializeField] private TMP_Text silverMoves;
    [SerializeField] private TMP_Text goldMoves;


    private GameObject environment;
    private GameObject medalImage;
    public GameObject currentMedal;
    [SerializeField] private bool fullText = false;

    public Sprite bronze;
    public Sprite silver;
    public Sprite gold;


    void Start() {
        environment = GameObject.FindGameObjectWithTag("environment");
        medalImage = GameObject.FindGameObjectWithTag("medal_level_tag");
        goldMoves.SetText(environment.GetComponent<Environment>().moves_gold.ToString());
        silverMoves.SetText(environment.GetComponent<Environment>().moves_silver.ToString());
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!fullText) {
            moveText.SetText("" + environment.GetComponent<Environment>().moveCounter);
        } else {
            moveText.SetText(environment.GetComponent<Environment>().moveCounter + " Moves");
        }
        if (medalImage != null) {
            if(PlayerStats.Levels[SceneManager.GetActiveScene().buildIndex - 2].stars == 1) {
                medalImage.GetComponent<Image>().sprite = bronze;
            } else if(PlayerStats.Levels[SceneManager.GetActiveScene().buildIndex - 2].stars == 2) {
                medalImage.GetComponent<Image>().sprite = silver;
            } else {
                medalImage.GetComponent<Image>().sprite = gold;
            }
        }

        if (environment.GetComponent<Environment>().moveCounter <= environment.GetComponent<Environment>().moves_gold) {
            currentMedal.GetComponent<Image>().sprite = gold;
        } else if (environment.GetComponent<Environment>().moveCounter <= environment.GetComponent<Environment>().moves_silver) {
            currentMedal.GetComponent<Image>().sprite = silver;
        } else {
            currentMedal.GetComponent<Image>().sprite = bronze;
        }
    }
}
