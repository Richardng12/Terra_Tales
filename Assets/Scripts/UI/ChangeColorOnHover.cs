using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Class that changes the text when you hover over it
    private Text myText;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    // Changees to gray on pointer enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.color = UnityEngine.Color.gray;
    }

    // changes text back to white when pointer exits
    public void OnPointerExit(PointerEventData eventData)
    {
        myText.color = UnityEngine.Color.white;
    }

    //Changes text to white
    public void MakeTextWhite()
    {
        myText.color = UnityEngine.Color.white;
    }

}