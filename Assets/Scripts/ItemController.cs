using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour
{
    private bool dragging = false;
    public SpriteRenderer spriteRenderer;
    // offset that will be applied when dragging an item
    private Vector3 scaleOffset = new Vector3(1.5f, 1.5f, 1.5f);
    private float scaleTime = 0.3f;

    /// <summary>
    /// Method for assigning components
    /// </summary>
    [ContextMenu("FillComponents")]
    public void FillComponents()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateDragging();
    }

    public void EvaluateDragging()
    {
        if (dragging)
        {
            spriteRenderer.color = Color.yellow;
            //spriteRenderer.transform.localScale = Vector3.Scale(Vector3.one, scaleOffset);

            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).z + 2f);
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Rigth-clicke: " + transform.rotation.z);
                //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90f);
                transform.Rotate(new Vector3(0, 0, 90));
            }
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        spriteRenderer.color = Color.white;
        spriteRenderer.transform.localScale = Vector3.one;
        dragging = false;
    }
}
