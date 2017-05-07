using UnityEngine;
using UnityEngine.UI;
public class AppManager : MonoBehaviour {
    public Text test;
    private int areaHilightLayer;
	void Start () {
        InputController.OnClick += OnClick;
        areaHilightLayer = 8;

    }
	
	void OnClick(Vector2 clickPos) {
        //RaycastHit hit;
        //Ray ray = Camera.allCameras[0].ScreenPointToRay(clickPos);
        //test.text = "OnClick Fired!!";
        //if (Physics.Raycast(ray, out hit, 20000, 1 << areaHilightLayer))
        //{
        //    AreaHilight ah = hit.collider.GetComponent<AreaHilight>();
        //    ah.showInfo();
        //    test.text = "hit";
        //}
	}
}
