using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Move {
    //Variable declaration
    //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
    public Vector3 moveDir;
    public string moveType;
   
    //Constructor (not necessary, but helpful)
    public Move(Vector3 moveDir, string moveType) {
        this.moveType = moveType;
        this.moveDir = moveDir;
    }
}



public class Environment : MonoBehaviour
{
    public int moveCounter = 0;
    public List<Move> moveSet;
    void Start()
    {
        moveSet = new List<Move>();;
        moveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
