using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasteNumberToBottom : MonoBehaviour
{

    [SerializeField] private int faceValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<tempNumberScript>().PrintDot(faceValue);
    }
}
