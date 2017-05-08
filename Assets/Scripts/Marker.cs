using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

    public Area area;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void Update () {
        transform.Rotate(0, 0, 2);
    }

    public IEnumerator drop()
    {
        float start = 700;
        float end = 0;
        float timeCost = 2f;
        float startTime = Time.time;
        float t = 0;
        while (t < 1 && AppManager.instance.inTrack)
        {
            t = (Time.time - startTime) / timeCost;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start, end, t), transform.position.z);
            yield return null;
        }
        area.expand();

    }
}
