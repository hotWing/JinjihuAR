using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float angleX = Vector3.Angle(Camera.main.transform.forward, Vector3.down);
       //float angleY = Vector3.Angle(Camera.main.transform.forward, Vector3.forward);
        //text.text = (Camera.main.transform.rotation.eulerAngles.y).ToString();
        //if(angleX <= 30)
        //{
        //    //Vector3 vector = Quaternion.Euler(0, -45, 0) * vector;
        //    transform.eulerAngles = new Vector3(50, 0, 0);
        //}
           
        //else
        //    transform.eulerAngles = new Vector3(50, 0, 0);

        transform.Rotate(0, 2, 0);

    }

}
