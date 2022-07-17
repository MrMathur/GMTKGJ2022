using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void ToggleState(GameObject gameobject) {
        if (gameobject.activeSelf) {
            gameobject.SetActive(false);
        } else {
            gameobject.SetActive(true);
        }

    }
}
