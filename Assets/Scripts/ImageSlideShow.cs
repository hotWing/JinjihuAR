using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ImageSlideShow : MonoBehaviour, IDropHandler,IPointerExitHandler, IBeginDragHandler {

    // Use this for initialization
    public Text pageText;
    private int pageTotal;
    private ScrollRect scrollRect;
    private float interval;
    private float beginDragTime;
    private float beginDragScrollPos;
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
        pageTotal = transform.GetChild(0).GetChild(0).childCount;
        interval = (float)1 / (pageTotal - 1);

        pageText.text = "1 / " + pageTotal;
    }

    public void OnDrop(PointerEventData eventData)
    {
        endDrag();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        endDrag();
    }

    private IEnumerator snapToElement(int elemIndex)
    {
        scrollRect.enabled = false;

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

        pageText.text = (elemIndex + 1) + " / " + pageTotal;
        scrollRect.enabled = true;

    }

    private void endDrag()
    {
        float dragTime = Time.time - beginDragTime;
        float dragDist = scrollRect.horizontalNormalizedPosition - beginDragScrollPos;
        float dragSpeed = dragDist / dragTime;
        int elemIndex = 0;
        if (Math.Abs(dragSpeed) > 1.6 * interval)//快速拖动直接跳下一页
        {
            if(dragSpeed < 0)
                elemIndex = Mathf.FloorToInt(scrollRect.horizontalNormalizedPosition / interval);
            else if (dragSpeed > 0)
                elemIndex = Mathf.CeilToInt(scrollRect.horizontalNormalizedPosition / interval);
        }
        else
            elemIndex = Mathf.RoundToInt(scrollRect.horizontalNormalizedPosition / interval);

        StartCoroutine(snapToElement(elemIndex));

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDragTime = Time.time;
        beginDragScrollPos = scrollRect.horizontalNormalizedPosition;
    }

    public void OnDisable()
    {
        scrollRect.horizontalNormalizedPosition = 0;
    }
}
