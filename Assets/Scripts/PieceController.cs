using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public BoardPoint currentPoint;
    public float moveSpeed = 2f;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePiece();
    }

    private void OnMouseDown()
    {
        // change between canMove states
        if (!BoardManager.instance.CanMovePiece(gameObject)) BoardManager.instance.movablePiece = gameObject;
    }

    /// <summary>
    /// Method for moving the piece and update the needed variables
    /// </summary>
    public void MovePiece()
    {
        if (!BoardManager.instance.CanMovePiece(gameObject)) return;
        
        if(moving) transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        // if we are close enough to the point we want to move, allow movement
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.005f)
        {
            Debug.Log("EEEE");
            if (Input.GetAxisRaw("Horizontal") > 0.5f && CheckPointState(currentPoint.right))
            {
                if (currentPoint.right != null) UpdateCurrentPoint(currentPoint.right);
            } 
            else if (Input.GetAxisRaw("Horizontal") < -0.5f && CheckPointState(currentPoint.left))
            {
                if (currentPoint.left != null) UpdateCurrentPoint(currentPoint.left);
            } 
            else if (Input.GetAxisRaw("Vertical") > 0.5f && CheckPointState(currentPoint.up))
            {
                if (currentPoint.up != null) UpdateCurrentPoint(currentPoint.up);
                
            } 
            else if (Input.GetAxisRaw("Vertical") < -0.5f && CheckPointState(currentPoint.down))
            {
                if (currentPoint.down != null) UpdateCurrentPoint(currentPoint.down);
                
            } 
        }

    }

    /// <summary>
    /// Returns true if the given point is not occupied and is not null
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private bool CheckPointState(BoardPoint point)
    {
        return point != null && !point.occupied;
    }

    private void UpdateCurrentPoint(BoardPoint nextPoint)
    {
        // set the current point as free to be occupied by any other piece
        currentPoint.occupied = false;
        // update the current point that the piece is in with the point it's going to travel to
        currentPoint = nextPoint;
        moving = true;
        // set the next point as occupied, currentPoint is now the new point to be occupied
        currentPoint.occupied = true;
    }
}
