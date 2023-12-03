using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public TMP_Text scoreText;
    public TMP_Text completedText;

    public string mainMenuScene;

    public static GameManager instance;

    private void Awake() {
        if (instance == null) instance = this;
    }


    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update() {
        SpawnPuzzle();
        CheckIsPuzzleSolved();
    }

    public void CheckChangeScene() {
        Time.timeScale = 0;
        SceneManager.LoadScene(mainMenuScene);
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
        //if (waiting || puzzleToSpawn == null || !BoardManager.instance.CheckSolution()) return;
        if (waiting || puzzleToSpawn == null) return;

        Debug.Log(waiting);

        if (puzzleToSpawn.gameObject.CompareTag("Level1")) {
            score += 20;
            StartCoroutine(WaitToSolve(score));
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level2")) {
            score += 50;
            StartCoroutine(WaitToSolve(score));
        }
        if (puzzleToSpawn.gameObject.CompareTag("Level3")) {
            score += 100;
            StartCoroutine(WaitToSolve(score));
        }
    }

    private IEnumerator WaitToSolve(int score) {
        completedText.color = new Color(completedText.color.r, completedText.color.g, completedText.color.b, 1f);
        waiting = true;
        scoreText.text = score.ToString();
        yield return new WaitForSeconds(0.7f);
        Destroy(clone);
        completedText.color = new Color(completedText.color.r, completedText.color.g, completedText.color.b, 0f);
        yield return new WaitForSeconds(0.5f);
        solving = false;
        waiting = false;
        puzzleToSpawn = null;
    }
}