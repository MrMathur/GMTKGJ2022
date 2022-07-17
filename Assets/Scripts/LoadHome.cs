using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHome : MonoBehaviour
{
    public void loadHome() {
        SceneManager.LoadScene(0);
    }
}
