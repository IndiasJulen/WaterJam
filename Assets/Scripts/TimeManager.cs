using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling.Editor;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float countdown = 300;
    public TMP_Text timeText;

    public bool lastChange = false;

    public bool canChangeBar = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) {
            countdown -= Time.deltaTime;
            float min = Mathf.FloorToInt(countdown / 60);
            float sec = Mathf.FloorToInt(countdown % 60);
            timeText.text = min + ":" + sec;
        }
    }
}
