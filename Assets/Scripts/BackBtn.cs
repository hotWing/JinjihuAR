using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackBtn : MonoBehaviour {

	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(btnOnClick);
	}
	
	void btnOnClick () {
        AppManager.instance.startTracking();

        transform.parent.parent.gameObject.SetActive(false);
	}
}
