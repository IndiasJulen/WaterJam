using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public Transform point1, point2, point3;
    public GameObject[] puzzlesPrefab;
    public List<GameObject> aux;

    public GameObject puzzleToSpawn;

    GameObject clone;

    public bool solving = false;
    public bool waiting = false;

    public int score = 0;
    

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPuzzle();
        CheckIsPuzzleSolved();
    }

    public void SpawnPuzzle()
    {
        if (puzzlesPrefab.Length == aux.Count || solving) return;

        solving = true;

        Debug.Log("Spawning puzzle");

        int index = Random.Range(0, puzzlesPrefab.Length);

        puzzleToSpawn = puzzlesPrefab[index];
        Transform pointToSpawn;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) pointToSpawn = point1;
        else if (puzzleToSpawn.gameObject.CompareTag("Level2")) pointToSpawn = point2;
        else pointToSpawn = point3;

        clone = (GameObject)Instantiate(puzzleToSpawn, pointToSpawn.position, Quaternion.identity, pointToSpawn);

        aux.Add(puzzleToSpawn);
        Debug.Log("Puzzle spawned");
    }

    public void CheckIsPuzzleSolved()
    {
        if (waiting || puzzlesPrefab.Length == aux.Count || !BoardManager.instance.CheckSolution()) return;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) 
        {
            StartCoroutine(WaitToSolve());
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level2")) 
        {
            StartCoroutine(WaitToSolve());
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level3")) 
        {
            StartCoroutine(WaitToSolve());
        }
    }

    private IEnumerator WaitToSolve()
    {
        waiting = true;
        yield return new WaitForSeconds(1f);
        Destroy(clone);
        Debug.Log("Puzzle removed");
        solving = false;
        waiting = false;
    }
}
