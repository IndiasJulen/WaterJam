using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PuzzleType
{
    LEVEL1,
    LEVEL2,
    LEVEL3
}

public class BoardManager : MonoBehaviour
{
    public GameObject movablePiece;
    public SpriteRenderer solutionImage;

    public BoardPoint[] boardPoints;

    public int leftToSolution;

    public PuzzleType puzzleType = PuzzleType.LEVEL1;

    public static BoardManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {

    }


    /// <summary>
    /// Returns whether the given piece can be moved or not
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public bool CanMovePiece(GameObject piece)
    {
        return movablePiece.Equals(piece);
    }


    /// <summary>
    /// Checks if the current piece combination is the valid solution
    /// </summary>
    public bool CheckSolution()
    {
        int i = 0;
        bool solutionFound = true;
        while((i < boardPoints.Length - leftToSolution) && solutionFound)
        {
            if (!CheckPointHasCorrectPiece(boardPoints[i])) {
                solutionFound = false;
            }
            i++;
        }
        
        return solutionFound;
    }

    /// <summary>
    /// Checks if the given board point holds the correct piece of the solution
    /// </summary>
    private bool CheckPointHasCorrectPiece(BoardPoint point)
    {
        return point.occupiedBy != null && point.occupiedBy.name.Split('-')[1].Equals(point.name.Split('-')[1]);
    }    
}
