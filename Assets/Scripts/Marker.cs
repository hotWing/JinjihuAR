using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Marker : MonoBehaviour {

	void OnEnable () {
        StartCoroutine(expandImg());
	}


	void Update () {
        transform.Rotate(0, 0, 2);
    }

    IEnumerator expandImg()
    {
        // 展开图片
        float start = 700;
        float end = 0;
        float timeCost = 5f;
        float startTime = Time.time;
        float t = 0;
        while (t < 1)
        {
            t = (Time.time - startTime) / timeCost;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start, end, t), transform.position.z);
            yield return null;
        }
    }
    }
