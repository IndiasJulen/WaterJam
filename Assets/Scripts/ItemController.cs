using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 moveOffset;
    public SpriteRenderer spriteRenderer;
    // offset that will be applied when dragging an item
    private float scaleOffset = 1.003f;
    public float scaleTime = 0.05f;
    private bool scaling = false;

    public float rotationAngle = 90f;

    public float xLimit = 1.8f;
    public float yLimit = 1.0f;

    public float gizmoSize = 1.3f;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateDragging();
    }

    //private void OnDrawGizmos() {
    //    Gizmos.DrawWireCube(transform.position, new Vector3(gizmoSize, gizmoSize, 0f));
    //}

    public void EvaluateDragging()
    {
        if (dragging)
        {
            spriteRenderer.color = Color.yellow;

            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + moveOffset;

            if (Input.GetMouseButtonDown(1))
            {
                // rotate 90 degrees clock-wise
                transform.Rotate(new Vector3(0, 0, -rotationAngle));
            }
        }
    }

    /// <summary>
    /// Coroutine for scaling the sprite scale over time
    /// </summary>
    /// <returns></returns>
    //private IEnumerator ScaleItemOnDrag()
    //{
    //    scaling = true;
    //    float counter = scaleTime;
    //    while(counter > 0)
    //    {
    //        spriteRenderer.transform.localScale = new Vector3(spriteRenderer.transform.localScale.x * scaleOffset,
    //                                                          spriteRenderer.transform.localScale.y * scaleOffset,
    //                                                          spriteRenderer.transform.localScale.z * scaleOffset);
    //        counter -= Time.deltaTime;
    //        yield return null;
    //    }
    //    scaling = false;
    //}

    private void OnMouseDown()
    {
        Debug.Log("A");
        // offset for the mouse to stay in the position where the player clicks
        moveOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (!scaling) StartCoroutine(ScaleItemOnDrag());
        dragging = true;
    }

    private void OnMouseUp()
    {
        // if the item is placed beyond the camera limits, place it in the center (for the moment)
        if (Mathf.Abs(transform.position.x) > xLimit || Mathf.Abs(transform.position.y) > yLimit) transform.position = Vector3.zero;
        
        spriteRenderer.color = Color.white;
        //spriteRenderer.transform.localScale = Vector3.one;
        dragging = false;
    }
}
