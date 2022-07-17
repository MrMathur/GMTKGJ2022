using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateMoveText : MonoBehaviour
{

    [SerializeField] private TMP_Text moveText;
    [SerializeField] private GameObject environment;
    [SerializeField] private bool fullText = false;
    

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
