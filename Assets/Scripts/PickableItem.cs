using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class PickableItem : MonoBehaviour
{
    public Enums.ItemName itemName = Enums.ItemName.BEACH_CHAIR;
    public SpriteRenderer image;

    private float scale = 0.6f;

    public PickableItem[] itemsToSpawn;

    private void Start() {
        image = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown() {
        Vector3 scaleToSpawn = transform.localScale;
        Destroy(gameObject);
        PickableItem newItem = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
        Instantiate(newItem, transform.position, transform.localRotation);
    }
}
