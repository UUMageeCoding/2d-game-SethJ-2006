using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void IWasClicked()
    {
        Debug.Log("Clicked");
    }

}
