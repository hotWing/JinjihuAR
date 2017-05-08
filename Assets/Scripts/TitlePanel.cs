using UnityEngine;
using System;

public class TitlePanel : MonoBehaviour {

    public Action titleShowComplete;

    void titleShowFinish()
    {
        titleShowComplete();
    }
}
