using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ImageSlideShow : MonoBehaviour, IDropHandler,IPointerExitHandler {

    // Use this for initialization
    private ScrollRect scrollRect;
    private float interval;
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
        interval = (float)1 / (transform.GetChild(0).GetChild(0).childCount -1);
    }

    public void OnDrop(PointerEventData eventData)
    {
        int elemIndex = Mathf.RoundToInt(scrollRect.horizontalNormalizedPosition / interval);
        StartCoroutine(snapToElement(elemIndex));
    }

    private IEnumerator snapToElement(int elemIndex)
    {
        float startPos = scrollRect.horizontalNormalizedPosition;
        float endPos = interval * elemIndex;
        float timeCost = 0.3f;
        float startTime = Time.time;
        float t = 0;

        while (t < 1)
        {
            t = (Time.time - startTime) / timeCost;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPos, endPos, t);
            yield return null;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        int elemIndex = Mathf.RoundToInt(scrollRect.horizontalNormalizedPosition / interval);
        StartCoroutine(snapToElement(elemIndex));
    }
}
