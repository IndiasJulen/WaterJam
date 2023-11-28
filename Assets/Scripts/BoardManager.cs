using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject movablePiece;

    public static BoardManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
