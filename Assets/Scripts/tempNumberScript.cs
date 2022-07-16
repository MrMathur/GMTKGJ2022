using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempNumberScript : MonoBehaviour
{
    [SerializeField] GameObject[] faces = new GameObject[6];
    [SerializeField] GameObject bottomFace;

    // Update is called once per frame
    void Update()
    {
        void PrintDot(int index) {
            GameObject newFace = Instantiate(faces[index], bottomFace.transform.position, bottomFace.transform.rotation);
            newFace.transform.parent = transform;
            newFace.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))  PrintDot(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))  PrintDot(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))  PrintDot(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))  PrintDot(4);
        if (Input.GetKeyDown(KeyCode.Alpha5))  PrintDot(5);
        if (Input.GetKeyDown(KeyCode.Alpha6))  PrintDot(6);
    }
}
