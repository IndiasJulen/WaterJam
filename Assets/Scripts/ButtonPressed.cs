using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool buttonPressed;
    public SpriteRenderer solutionImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void IPointerDownHandler.OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData) {
        ShowSolution();
    }

    void IPointerUpHandler.OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData) { 
        HideSolution();
    }

    private void ShowSolution()
    { 
        solutionImage.color = new Color(255f, 255f, 255f, 1f);
    }

    private void HideSolution()
    {
        solutionImage.color = new Color(255f, 255f, 255f, 0f);
    }
}
