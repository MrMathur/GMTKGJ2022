using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private GameObject player;
    private GameObject hud;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Die_Player")[0];
        hud = GameObject.FindGameObjectWithTag("HUD");
    }

    public void Reset() {
        player.GetComponent<CubeMovement>().InitiateReset();
        hud.GetComponent<NextLevelModal>().HideModal();
    }
}
