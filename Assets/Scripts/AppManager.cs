using UnityEngine;
using UnityEngine.UI;
public class AppManager : MonoBehaviour {

    public GameObject[] MarkerObjs;
    public GameObject[] AreaHilightObjs;
	public static AppManager instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void hideOverlays()
    {
        foreach (GameObject go in MarkerObjs)
            go.SetActive(false);

        foreach (GameObject go in AreaHilightObjs)
        {
            go.GetComponentInChildren<Image>().enabled = false;
            go.GetComponentInChildren<Text>().enabled = false;
        }
    }

    public void showOverlays()
    {
        foreach (GameObject go in MarkerObjs)
            go.SetActive(true);

        foreach (GameObject go in AreaHilightObjs)
        {
            go.GetComponentInChildren<Image>().enabled = true;
            go.GetComponentInChildren<Text>().enabled = true;
        }
    }
}
