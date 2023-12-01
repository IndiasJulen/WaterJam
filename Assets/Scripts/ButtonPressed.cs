using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SpriteRenderer[] solutionImages;

    public Dictionary<string, int> itemIndex = new Dictionary<string, int>();

    public int imageIndex;
    // Start is called before the first frame update
    void Start()
    {
        itemIndex.Add("straw-hat", 0);
        itemIndex.Add("slippers", 1);
        itemIndex.Add("sunglasses", 2);
        itemIndex.Add("lotion", 3);
        itemIndex.Add("purse", 4);
        itemIndex.Add("book", 5);
        itemIndex.Add("pool-float", 6);
        itemIndex.Add("scuba-dive", 7);
        itemIndex.Add("swimming-fins", 8);
        itemIndex.Add("towel", 9);
        itemIndex.Add("fridge", 10);
        itemIndex.Add("cube", 11);
        itemIndex.Add("beach-chair", 12);
        itemIndex.Add("table", 13);
        itemIndex.Add("paddle-ball", 14);
        itemIndex.Add("donut", 15);
        itemIndex.Add("radio", 16);
        itemIndex.Add("ball", 17);
        itemIndex.Add("shovel-rake", 18);
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
        imageIndex = itemIndex[BoardManager.instance.solutionImage.sprite.name.Split("-full")[0]];
        solutionImages[imageIndex].color = new Color(255f, 255f, 255f, 1f);
    }

    private void HideSolution()
    {
        solutionImages[imageIndex].color = new Color(255f, 255f, 255f, 0f);
    }
}
