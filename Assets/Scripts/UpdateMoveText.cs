using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateMoveText : MonoBehaviour
{

    [SerializeField] private TMP_Text moveText;
    private GameObject environment;
    [SerializeField] private bool fullText = false;

    void Start() {
        environment = GameObject.FindGameObjectWithTag("environment");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!fullText) {
            moveText.SetText("" + environment.GetComponent<Environment>().moveCounter);
        } else {
            moveText.SetText(environment.GetComponent<Environment>().moveCounter + " Moves");
        }
    }
}
