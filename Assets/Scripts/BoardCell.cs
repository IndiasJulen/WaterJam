using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    // if the cell is free to place an item/item cell or not
    public bool free = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //&&
        //    Mathf.Abs(collision.gameObject.transform.position.x - transform.position.x) < 0.1f &&
        //    Mathf.Abs(collision.gameObject.transform.position.y - transform.position.y) < 0.1f
        Debug.Log("EEE");
        if (collision.CompareTag("ItemCell")) {
            Debug.Log("Cell entered");
            free = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("ItemCell")) {
            Debug.Log("Cell left");
            free = true;
        }
    }
}
