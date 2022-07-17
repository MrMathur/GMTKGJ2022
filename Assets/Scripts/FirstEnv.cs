using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstEnv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Levels == null) {
            PlayerStats.Levels = new List<LevelDetails>();
            PlayerStats.CurrentLevel = 1;
            for (int i=0; i< SceneManager.sceneCountInBuildSettings - 1; i++){
                bool unlocked = false;
                if (i==0){
                    unlocked = true;
                }
                LevelDetails x = new LevelDetails(i+1,0,0,unlocked, false);
                PlayerStats.Levels.Add(x);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
        }
    }
}
