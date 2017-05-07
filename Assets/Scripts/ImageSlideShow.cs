using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSlideShow : MonoBehaviour, IDropHandler {

    // Use this for initialization
    private ScrollRect scrollRect;

    void Start () {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(scrollRect.horizontalNormalizedPosition);
    }
}
