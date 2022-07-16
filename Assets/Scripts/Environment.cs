using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PlayerStats
{
    public static List<LevelDetails> Levels { get; set; }
    public static int CurrentLevel { get; set; }

}

public struct LevelDetails {
    public int stars;
    public bool unlocked;
    public int numMoves;
    public bool cleared;
    public int levelIndex;

    //Constructor (not necessary, but helpful)
    public LevelDetails(int levelIndex, int stars, int numMoves, bool unlocked, bool cleared) {
        this.stars = stars;
        this.unlocked = unlocked;
        this.numMoves = numMoves;
        this.cleared = cleared;
        this.levelIndex = levelIndex;
    }
}

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
    public int moves_gold = 5;
    public int moves_silver = 10;
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
