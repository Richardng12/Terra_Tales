using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Text myText;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.color = UnityEngine.Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.color = UnityEngine.Color.white;
    }

    public void MakeTextWhite()
    {
        myText.color = UnityEngine.Color.white;
        Debug.Log("as;dak;dkad");
    }

}