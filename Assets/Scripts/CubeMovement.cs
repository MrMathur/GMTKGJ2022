using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeMovement : MonoBehaviour
{

    [SerializeField] private float rollSpeed = 3;
    [SerializeField] private float jumpSpeed = 3;
    [SerializeField] private GameObject face1;
    [SerializeField] private GameObject face2;
    [SerializeField] private GameObject face3;
    [SerializeField] private GameObject face4;
    [SerializeField] private GameObject face5;
    [SerializeField] private GameObject face6;
    [SerializeField] private GameObject cube;

    private Quaternion face1quat;

    private bool _isMoving;

    private Vector3 lastMove;


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
        // Debug.Log(Vector3.Dot(vecA, vecB));
        return 1 - Vector3.Dot(vecA, vecB) < 0.01f;
    }   

    void Update()
    {

        if (_isMoving) return;

        void InitiateRoll(Vector3 dir) {
            lastMove = dir;
            Vector3 anchor = transform.position + (Vector3.down + dir) * 5f;
            Vector3 axis = Vector3.Cross(Vector3.up, dir);

            StartCoroutine(Roll(anchor, axis));
        }

        if (Input.GetKeyDown(KeyCode.A)) InitiateRoll(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) InitiateRoll(Vector3.right);
        if (Input.GetKeyDown(KeyCode.W)) InitiateRoll(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.S)) InitiateRoll(Vector3.back);
    }



    private void InitiateJump(Vector3 dir) {
        Vector3 anchor = transform.position + (dir * 10f);
        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        StartCoroutine(Jump(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++) {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
        
    }

    IEnumerator Jump(Vector3 anchor, Vector3 axis) {
        _isMoving = true;

        for (int i = 0; i < (180 / jumpSpeed); i++) {
            transform.RotateAround(anchor, axis, jumpSpeed);
            transform.RotateAround(transform.position,-axis,jumpSpeed/2);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }

    private void markFaceGreen(Collider other) {
        other.gameObject.GetComponent<MarkTile>().triggerColorGreen();
    }

    private void markFaceRed(Collider other) {
        Debug.Log(other.gameObject.GetComponent<MarkTile>());
        other.gameObject.GetComponent<MarkTile>().triggerColorRed();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Spring") {
            InitiateJump(lastMove);
        }
        else if (other.tag == "tile1"){
            if (getCorrectFaceValue() == 1) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
        else if (other.tag == "tile2"){
            if (getCorrectFaceValue() == 2) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
        else if (other.tag == "tile3"){
            if (getCorrectFaceValue() == 3) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
        else if (other.tag == "tile4"){
            if (getCorrectFaceValue() == 4) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
        else if (other.tag == "tile5"){
            if (getCorrectFaceValue() == 5) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
        else if (other.tag == "tile6"){
            if (getCorrectFaceValue() == 6) {
                markFaceGreen(other);
            } else {
                markFaceRed(other);
            }
        }
    }
}
