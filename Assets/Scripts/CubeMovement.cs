using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    [SerializeField] private float rollSpeed = 3;
    [SerializeField] private float jumpSpeed = 3;
    [SerializeField] private GameObject bottomFace;
    private bool _isMoving;

    void Update()
    {

        if (_isMoving) return;

        void InitiateRoll(Vector3 dir) {
            Vector3 anchor = transform.position + (Vector3.down + dir) * 5f;
            Vector3 axis = Vector3.Cross(Vector3.up, dir);

            StartCoroutine(Roll(anchor, axis));
        }

        void InitiateJump(Vector3 dir) {
            Vector3 anchor = transform.position + (dir * 10f);
            Vector3 axis = Vector3.Cross(Vector3.up, dir);

            StartCoroutine(Jump(anchor, axis));
        }


        if (Input.GetKeyDown(KeyCode.A)) InitiateRoll(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) InitiateRoll(Vector3.right);
        if (Input.GetKeyDown(KeyCode.W)) InitiateRoll(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.S)) InitiateRoll(Vector3.back);

        if (Input.GetKeyDown(KeyCode.J)) InitiateJump(Vector3.left);
        if (Input.GetKeyDown(KeyCode.L)) InitiateJump(Vector3.right);
        if (Input.GetKeyDown(KeyCode.I)) InitiateJump(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.K)) InitiateJump(Vector3.back);
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++) {
            transform.RotateAround(anchor, axis, rollSpeed);
            bottomFace.transform.RotateAround(transform.position, axis, -rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }

    IEnumerator Jump(Vector3 anchor, Vector3 axis) {
        _isMoving = true;

        for (int i = 0; i < (180 / jumpSpeed); i++) {
            transform.RotateAround(anchor, axis, jumpSpeed);
            transform.RotateAround(transform.position,-axis,jumpSpeed/2);
            bottomFace.transform.RotateAround(transform.position,-axis,jumpSpeed/2);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }
}
