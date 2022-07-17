using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelModal : MonoBehaviour
{

    [SerializeField] private GameObject CompletedLevelModal;

    // Start is called before the first frame update
    void Start()
    {
        CompletedLevelModal.SetActive(false);
    }

    public void ShowModal() {
        PlayerStats.canMove = false;
        CompletedLevelModal.SetActive(true);
    }

    public void HideModal() {
        PlayerStats.canMove = true;
        CompletedLevelModal.SetActive(false);
    }
}
