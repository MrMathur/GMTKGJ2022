using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Die_Player")[0];
    }

    public void Reset() {
        player.GetComponent<CubeMovement>().InitiateReset();
    }
}
