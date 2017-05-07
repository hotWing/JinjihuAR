using UnityEngine;
using UnityEngine.UI;
using System;

public class InputController : MonoBehaviour
{
    public static event Action<Vector2> OnClick;
    public static bool enabled1;
    public Text test;
    void Start()
    {
        enabled1 = true;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0) && enabled1)
        {
            OnClick(Input.mousePosition);
        }
#endif
#if (UNITY_IOS || UNITY_ANDROID)
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            OnClick(touch.position);
            
        }
#endif

    }
}