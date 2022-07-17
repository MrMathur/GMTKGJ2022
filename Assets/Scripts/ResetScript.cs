using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetScript : MonoBehaviour
{
    private GameObject player;
    private GameObject hud;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Die_Player");
        hud = GameObject.FindGameObjectWithTag("HUD");
    }

    public void Reset() {
        player.GetComponent<CubeMovement>().InitiateReset();
        hud.GetComponent<NextLevelModal>().HideModal();
    }

    public void ChooseLevel() {
        SceneManager.LoadScene(1);
    }
}
