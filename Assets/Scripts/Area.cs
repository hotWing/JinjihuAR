using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Area : MonoBehaviour {

    public GameObject areaInfo;
    public GameObject particle;
    private Button btn;
    private Image img;
    private Text txt;
    public float defaultImgWidth = 152;
    public float defaultTextWidth = 148;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(showInfo);
        img = GetComponentInChildren<Image>();
        img.enabled = false;
        txt = GetComponentInChildren<Text>();
        txt.enabled = false;
        reset();
    }

	void showInfo() {
        AppManager.instance.hideOverlays();
        StartCoroutine(showInfoCor());
	}

    IEnumerator showInfoCor()
    {
        btn.enabled = false;
        particle.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        particle.SetActive(false);
        areaInfo.SetActive(true);
        btn.enabled = true;
        Vuforia.TrackerManager.Instance.GetTracker<Vuforia.ObjectTracker>().Stop();
    }

    public void expand()
    {
        StartCoroutine(expandImg());
    }
    IEnumerator expandImg()
    {
        // 展开图片
        float start = 0;
        float end = defaultImgWidth;
        float timeCost = 1f;
        float startTime = Time.time;
        float t = 0;
        RectTransform rectTrans = img.GetComponent<RectTransform>();
        float oldY = rectTrans.sizeDelta.y;
        while (t < 1 && AppManager.instance.inTrack)
        {
            t = (Time.time - startTime) / timeCost;
            rectTrans.sizeDelta = new Vector2(Mathf.Lerp(start, end, t), oldY);
            yield return null;
        }

        //展开字体
        start = 0;
        end = defaultTextWidth;
        timeCost = 1f;
        startTime = Time.time;
        t = 0;
        rectTrans = txt.GetComponent<RectTransform>();
        oldY = rectTrans.sizeDelta.y;
        while (t < 1 && AppManager.instance.inTrack)
        {
            t = (Time.time - startTime) / timeCost;
            rectTrans.sizeDelta = new Vector2(Mathf.Lerp(start, end, t), oldY);
            yield return null;
        }
    }

    public void reset()
    {
        RectTransform rectTrans = img.GetComponent<RectTransform>();
        float oldY = rectTrans.sizeDelta.y;
        rectTrans.sizeDelta = new Vector2(0, oldY);
        rectTrans = txt.GetComponent<RectTransform>();
        oldY = rectTrans.sizeDelta.y;
        rectTrans.sizeDelta = new Vector2(0, oldY);
    }
}
