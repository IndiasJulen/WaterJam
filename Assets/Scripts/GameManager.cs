using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform point1, point2, point3;
    public GameObject prefab;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, point2.position, Quaternion.identity, point2);
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
            Debug.Log("Level 1 puzzle completed!");
        }
        if (BoardManager.instance.puzzleType == PuzzleType.LEVEL2)
        {
            Debug.Log("Level 2 puzzle completed!");
        }
        if (BoardManager.instance.puzzleType == PuzzleType.LEVEL3)
        {
            Debug.Log("Level 3 puzzle completed!");
        }
    }
}
