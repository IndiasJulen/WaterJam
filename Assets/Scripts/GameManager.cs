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

        int index = Random.Range(0, puzzlesPrefab.Length);

        puzzleToSpawn = puzzlesPrefab[index];
        Transform pointToSpawn;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) pointToSpawn = point1;
        else if (puzzleToSpawn.gameObject.CompareTag("Level2")) pointToSpawn = point2;
        else pointToSpawn = point3;

        clone = (GameObject)Instantiate(puzzleToSpawn, pointToSpawn.position, Quaternion.identity, pointToSpawn);

        solving = true;

        aux.Add(puzzleToSpawn);
    }

    public void CheckIsPuzzleSolved()
    {
        if (puzzlesPrefab.Length == aux.Count || !BoardManager.instance.CheckSolution()) return;

        if (!solving) {
            Debug.Log(aux.Count + " : " + puzzleToSpawn);
            Debug.Log(solving);
        }

        //Debug.Log("ARRAY------------");
        //for(int i = 0; i < aux.Count; i++) {
        //    Debug.Log(aux[i]);
        //}

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
        yield return new WaitForSeconds(3f);
        Destroy(clone);
        Debug.Log("A");
        solving = false;
        Debug.Log("B");
    }
}
