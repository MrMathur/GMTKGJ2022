using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MarkTile : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text final_text;
    public bool isCorrect = false;
    private GameObject hud;
    private GameObject environment;
    private AudioSource envAudioSource;
    [SerializeField] private AudioSource bronzeTone;
    [SerializeField] private AudioSource silverTone;
    [SerializeField] private AudioSource goldTone;

    void Start() {
        hud = GameObject.FindGameObjectWithTag("HUD");
        environment = GameObject.FindGameObjectWithTag("environment");
        envAudioSource = environment.GetComponent<AudioSource>();
    }

    public void triggerColorRed(bool isReset) {
        if (!isReset) {
            final_text.color = Color.red;
            isCorrect = false;
        }
    }

    public void triggerColorGreen(bool isReset, int numMoves, int moves_gold, int moves_silver) {
        if (!isReset) {
            final_text.color = Color.green;
            isCorrect = true;
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("generic_tag");
            var allCorrect = true;
            foreach(GameObject obst in obstacles) {
                if(!obst.transform.GetChild(0).gameObject.GetComponent<MarkTile>().isCorrect){ 
                    allCorrect = false;
                }
            }

            if (allCorrect) {
                PlayerStats.CurrentLevel +=1;
                int stars = 1;
                if (numMoves <= moves_gold) {
                    stars = 3;
                } else if (numMoves <= moves_silver) {
                    stars = 2;
                } 
                PlayerStats.Levels[SceneManager.GetActiveScene().buildIndex - 2] = new LevelDetails(PlayerStats.CurrentLevel -1, stars, numMoves, true, true);
                PlayerStats.Levels[SceneManager.GetActiveScene().buildIndex - 1] = new LevelDetails(PlayerStats.CurrentLevel, 0, 0, true, false);
                hud.GetComponent<NextLevelModal>().ShowModal();
                envAudioSource.Pause();
                if (environment.GetComponent<Environment>().moveCounter <= environment.GetComponent<Environment>().moves_gold)
                {
                    goldTone.Play();
                }
                else if (environment.GetComponent<Environment>().moveCounter <= environment.GetComponent<Environment>().moves_silver)
                {
                    silverTone.Play();
                }
                else
                {
                    bronzeTone.Play();
                }



            }

        } else {
            final_text.color = Color.red;
            isCorrect = false;
        }
    }

    
}
