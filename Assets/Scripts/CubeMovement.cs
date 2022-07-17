using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{

    [SerializeField] private float rollSpeed = 3;
    [SerializeField] private float jumpSpeed = 3;
    [SerializeField] private GameObject cube;

    private Quaternion face1quat;
    private Rigidbody m_rigidbody;

    private bool _isMoving;

    private Vector3 lastMove;
    private GameObject environment;
    private bool isReset = false;
    private bool isJumping = false;

    Collider lastCollider = null;

    [SerializeField] private AudioSource moveSound;
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;
    [SerializeField] private AudioSource jumpSound;

    int getCorrectFaceValue() {
        
       if (vecIsEqual(cube.transform.up, Vector3.up)){
        return 2;
       }
       else if (vecIsEqual(-cube.transform.up, Vector3.up)){
        return 5;
       }
       else if (vecIsEqual(-cube.transform.right, Vector3.up)){
        return 6;
       }
       else if (vecIsEqual(cube.transform.right, Vector3.up)){
        return 1;
       }
       else if (vecIsEqual(cube.transform.forward, Vector3.up)){
        return 3;
       }
       else if (vecIsEqual(-cube.transform.forward, Vector3.up)){
        return 4;
       }
       return 0;
    }

    public bool vecIsEqual(Vector3 vecA, Vector3 vecB)
    {
        return 1 - Vector3.Dot(vecA, vecB) < 0.01f;
    }   

    void Start() {
        environment = GameObject.FindWithTag("environment");
    }

    void Update()
    {


        if (_isMoving || isReset) return;

       
        Vector3 tmp = transform.position;
        if (PlayerStats.canMove) {
            if (Input.GetKeyDown(KeyCode.D) && isMovableinDirection(Vector3.left)) {
                InitiateRoll(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.A)  && isMovableinDirection(Vector3.right)) {
                InitiateRoll(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.S)  && isMovableinDirection(Vector3.forward)) {
                InitiateRoll(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.W) && isMovableinDirection(Vector3.back)) {
                InitiateRoll(Vector3.back);
            }

            else if (Input.GetKeyDown(KeyCode.X)){
                printPlayerDetails();
            }
        }
      
    }

    bool isMovableinDirection(Vector3 dir) {
         // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        RaycastHit hit;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
          if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, layerMask)) // if (Physics.SphereCast(ray, radius, out hit,maxDistance))
        {
            return hit.distance > 6;
        }
        return true;
    }

    void printPlayerDetails() {
        foreach (var move in PlayerStats.Levels) {
            Debug.Log(move.levelIndex);
            Debug.Log(move.stars);
            Debug.Log(move.unlocked);
            Debug.Log(move.cleared);
            Debug.Log(move.numMoves);
        }
        Debug.Log(PlayerStats.CurrentLevel);
    }


     void InitiateRoll(Vector3 dir, bool noEnv = false) {
        if (!noEnv) {
            Move newMove = new Move(dir, "Roll");
            environment.GetComponent<Environment>().MakeMove(newMove);
        }
        lastMove = dir;
        Vector3 anchor = transform.position + (Vector3.down + dir) * 5f;
        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        StartCoroutine(Roll(anchor, axis));
     }

    public void InitiateReset(bool isRetry) {
        if (environment.GetComponent<Environment>().moveCounter > 10 || isRetry) {
            retry();
            return;
        }
        StartCoroutine(Reset());
    }

    public void retry () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Reset () {
        isReset = true;
        environment.GetComponent<Environment>().moveSet.Reverse();
        if (lastCollider != null) {
            char tileName = lastCollider.tag[lastCollider.tag.Length -1];
            int tileNum = tileName - '0';
            if (getCorrectFaceValue() == tileNum) {
                markFaceGreen(lastCollider);
            } else {
                markFaceRed(lastCollider);
            }
        }
        foreach (var move in environment.GetComponent<Environment>().moveSet) {
            if (move.moveType == "Jump") {
                InitiateJump(-move.moveDir, true);
                yield return new WaitForSeconds(1.2f);

            } else {
                InitiateRoll(-move.moveDir, true);
                yield return new WaitForSeconds(0.6f);

            }
        }
        environment.GetComponent<Environment>().moveSet = new List<Move>();
        environment.GetComponent<Environment>().moveCounter = 0;
        isReset = false;
    }



    private void InitiateJump(Vector3 dir, bool noEnv = false) {
        if (!isJumping) {
            if (!noEnv) {
                Move newMove = new Move(dir, "Jump");
                environment.GetComponent<Environment>().moveSet.Add(newMove);
            }
            Vector3 anchor = transform.position + (dir * 10f);
            Vector3 axis = Vector3.Cross(Vector3.up, dir);

            StartCoroutine(Jump(anchor, axis));
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;
        if (!isReset) {
            lastCollider = null;
        }

        moveSound.Play();

        for (int i = 0; i < (90 / rollSpeed); i++) {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        if (!isJumping){
            _isMoving = false;
        }
        Vector3 tmp = transform.position;
        tmp.y = 5f;
        tmp.x = roundToFive((float) tmp.x);
        tmp.z = roundToFive((float) tmp.z);

        transform.position = tmp;
        
    }

    private int roundToFive(float x) {
        return (int)(5 * Mathf.Round(x/5));
    }

    IEnumerator Jump(Vector3 anchor, Vector3 axis) {
        isJumping = true;
        jumpSound.Play();
        for (int i = 0; i < (180 / jumpSpeed); i++) {
            transform.RotateAround(anchor, axis, jumpSpeed);
            transform.RotateAround(transform.position,-axis,jumpSpeed/2);
            yield return new WaitForSeconds(0.01f);
            
        }
        isJumping = false;
        _isMoving = false;
        Vector3 tmp = transform.position;
        tmp.y = 5f;
        tmp.x = roundToFive((float) tmp.x);
        tmp.z = roundToFive((float) tmp.z);

        transform.position = tmp;

    }

    private void markFaceGreen(Collider other) {
        if (!isReset) {
            correctSound.Play();
        }
        other.gameObject.GetComponent<MarkTile>().triggerColorGreen(isReset, environment.GetComponent<Environment>().moveCounter, environment.GetComponent<Environment>().moves_gold, environment.GetComponent<Environment>().moves_silver);
    }

    private void markFaceRed(Collider other) {
        if (!isReset) {
            wrongSound.Play();
        }
        other.gameObject.GetComponent<MarkTile>().triggerColorRed(isReset);
    }

    private void resetCurrentFace() {

    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Spring") {
            InitiateJump(lastMove);
        }
        if (!isReset) {
            lastCollider = other;
        }
       
        char tileName = other.tag[other.tag.Length -1];
        int tileNum = tileName - '0';
        if (tileNum > 0 && tileNum < 7) {
            if (getCorrectFaceValue() == tileNum) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }      
    }
}
