using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform point1, point2, point3;
    public GameObject[] puzzlesPrefab;

    public int score = 0;
    

    // Start is called before the first frame update
    void Start()
    {   
        GameObject puzzleToSpawn = puzzlesPrefab[Random.Range(0, puzzlesPrefab.Length)];
        Transform pointToSpawn;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) pointToSpawn = point1;
        else if (puzzleToSpawn.gameObject.CompareTag("Level2")) pointToSpawn = point2;
        else pointToSpawn = point3;

        Instantiate(puzzleToSpawn, pointToSpawn.position, Quaternion.identity, pointToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsPuzzleSolved();
    }

    public void CheckIsPuzzleSolved()
    {
        if (!BoardManager.instance.CheckSolution()) return;

        if(BoardManager.instance.puzzleType == PuzzleType.LEVEL1)
        {
            //Debug.Log("Level 1 puzzle completed!");
        }
        if (BoardManager.instance.puzzleType == PuzzleType.LEVEL2)
        {
            //Debug.Log("Level 2 puzzle completed!");
        }
        if (BoardManager.instance.puzzleType == PuzzleType.LEVEL3)
        {
            //Debug.Log("Level 3 puzzle completed!");
        }
    }
}
