using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarkTile : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text final_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void triggerColorRed() {
        final_text.color = Color.red;
    }
    public void triggerColorGreen() {
        final_text.color = Color.green;
    }
}
