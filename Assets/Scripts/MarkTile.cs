using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MarkTile : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text final_text;
    public bool isCorrect = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void triggerColorRed() {
        final_text.color = Color.red;
        isCorrect = false;
    }
    public void triggerColorGreen() {
        final_text.color = Color.green;
        isCorrect = true;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("generic_tag");
        var allCorrect = true;
        foreach(GameObject obst in obstacles) {
            if(!obst.transform.GetChild(0).gameObject.GetComponent<MarkTile>().isCorrect){ 
                allCorrect = false;
            }
        }

        if (allCorrect) {
            SceneManager.LoadScene("Level 1");
        }


    }
}
