using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private GameObject player;
    private GameObject hud;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Die_Player");
        hud = GameObject.FindGameObjectWithTag("HUD");
    }

    public void Reset() {
        Debug.Log("Clicked");
        player.GetComponent<CubeMovement>().InitiateReset();
        hud.GetComponent<NextLevelModal>().HideModal();
    }
}
