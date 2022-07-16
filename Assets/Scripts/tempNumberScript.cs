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
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject newFace = Instantiate(faces[0], bottomFace.transform.position, bottomFace.transform.rotation);
            newFace.transform.parent = transform;
            newFace.transform.localScale = bottomFace.transform.localScale;
        }
    }
}
