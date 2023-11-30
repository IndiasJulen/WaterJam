using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPoint : MonoBehaviour
{
    public BoardPoint up, down, left, right;
    public bool occupied = false;
    // piece that is in this point
    public GameObject occupiedBy;
}
