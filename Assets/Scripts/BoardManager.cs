using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public GameObject movablePiece;
    public SpriteRenderer solutionImage;

    public BoardPoint[] boardPoints;

    public static BoardManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        if (CheckSolution()) StartCoroutine(PuzzleCompleted());
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
        while((i < boardPoints.Length - 1) && solutionFound)
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

    /// <summary>
    /// Method for executing some tasks related to the completion of the puzzle after one second
    /// </summary>
    /// <returns></returns>
    private IEnumerator PuzzleCompleted() 
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Puzzle completed!!");    
    }
}
