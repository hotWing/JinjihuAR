using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour {

    public GameObject areaInfo;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(showInfo);
    }

	void showInfo() {
        areaInfo.SetActive(true);
	}
}
