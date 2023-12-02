using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour {
    public Transform point1, point2, point3;
    public GameObject[] puzzlesPrefab;
    public List<GameObject> aux;

    public GameObject puzzleToSpawn;

    GameObject clone;

    public bool solving = false;
    public bool waiting = false;

    public int score = 0;

    public int spawned = 0;

    public static GameManager instance;

    private void Awake() {
        if (instance == null) instance = this;
    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        SpawnPuzzle();
        //CheckIsPuzzleSolved();
    }

    public void SpawnPuzzle() {
        if (puzzlesPrefab.Length == aux.Count || solving) return;

        solving = true;

        bool exists = false;
        bool same;
        while (!exists) {
            same = false;
            int index = UnityEngine.Random.Range(0, puzzlesPrefab.Length);
            puzzleToSpawn = puzzlesPrefab[index];
            if (aux.Count == 0) break;
            for (int i = 0; i < aux.Count; i++) {
                if (aux[i] == puzzleToSpawn) {
                    same = true;
                    break;
                }
            }
            if (!same) exists = true;
        }

        Transform pointToSpawn;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) pointToSpawn = point1;
        else if (puzzleToSpawn.gameObject.CompareTag("Level2")) pointToSpawn = point2;
        else pointToSpawn = point3;

        clone = (GameObject)Instantiate(puzzleToSpawn, pointToSpawn.position, Quaternion.identity, pointToSpawn);

        aux.Add(puzzleToSpawn);
        spawned++;
    }

    public void CheckIsPuzzleSolved() {
        if (waiting || puzzlesPrefab.Length == aux.Count || !BoardManager.instance.CheckSolution()) return;

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) {
            StartCoroutine(WaitToSolve());
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level2")) {
            StartCoroutine(WaitToSolve());
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level3")) {
            StartCoroutine(WaitToSolve());
        }
    }

    private IEnumerator WaitToSolve() {
        waiting = true;
        yield return new WaitForSeconds(1f);
        Destroy(clone);
        solving = false;
        waiting = false;
    }
}