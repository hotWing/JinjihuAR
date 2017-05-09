using UnityEngine;
using UnityEngine.UI;
public class AppManager : MonoBehaviour {

    public GameObject[] MarkerObjs;
    public GameObject[] AreaHilightObjs;
    public TitlePanel titlePanel;
	public static AppManager instance;
    private bool titleShowPlayed;
    public bool inTrack;
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        titleShowPlayed = false;

        titlePanel.titleShowComplete = titleShowComplete;
    }

    public void hideOverlays()
    {
        foreach (GameObject go in MarkerObjs)
            go.GetComponent<Renderer>().enabled = false;

        foreach (GameObject go in AreaHilightObjs)
        {
            go.GetComponentInChildren<Image>().enabled = false;
            go.GetComponentInChildren<Text>().enabled = false;
        }
    }

    public void showOverlays()
    {
        foreach (GameObject go in MarkerObjs)
        {
            go.GetComponent<Renderer>().enabled = true;
        }

        foreach (GameObject go in AreaHilightObjs)
        {
            go.GetComponentInChildren<Image>().enabled = true;
            go.GetComponentInChildren<Text>().enabled = true;
            go.GetComponentInChildren<Area>().reset();
        }
    }

    public void dropMarkers()
    {
        foreach (GameObject go in MarkerObjs)
        {
            StartCoroutine(go.GetComponent<Marker>().drop());
        }
            
    }

    public void titleShow()
    {
        if (!titleShowPlayed)
        {
            titlePanel.gameObject.SetActive(true);
            titleShowPlayed = true;
        }
        else
            titleShowComplete();
    }

    private void titleShowComplete()
    {
        if(inTrack)
        {
            showOverlays();
            titlePanel.gameObject.SetActive(false);
            dropMarkers();
        }
    }

    public void startTracking()
    {
        Vuforia.TrackerManager.Instance.GetTracker<Vuforia.ObjectTracker>().Start();
    }
}
