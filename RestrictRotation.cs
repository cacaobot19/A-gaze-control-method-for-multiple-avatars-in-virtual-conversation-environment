using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictRotation : MonoBehaviour {
    public float eyeRotate = 100;
    float YmaxRotate = 15;//回転角の最大値//
    float YtmpRotate = 0;//現在の回転角//
    float YstartRotation;//最初のグローバルY座標//
    float XmaxRotate = 10;
    float XtmpRotate = 0;
    float XstartRotation;

    // Use this for initialization
    void Start () {
        YstartRotation = this.transform.rotation.eulerAngles.y;
        XstartRotation = this.transform.rotation.eulerAngles.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(eyeRotate, 0, 0) * Time.deltaTime);
            XtmpRotate += (eyeRotate * Time.deltaTime);
            if (XtmpRotate >= XmaxRotate)
            {
                this.transform.rotation = Quaternion.Euler(XstartRotation + 10, 0, 0);
                XtmpRotate = 10;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(new Vector3(-eyeRotate, 0, 0) * Time.deltaTime);
            XtmpRotate -= (eyeRotate * Time.deltaTime);
            if (XtmpRotate <= XmaxRotate * -1)
            {
                this.transform.rotation = Quaternion.Euler(XstartRotation - 10, 0, 0);
                XtmpRotate = -10;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, eyeRotate, 0) * Time.deltaTime);
            YtmpRotate += (eyeRotate * Time.deltaTime);
            if (YtmpRotate >= YmaxRotate)
            {
                this.transform.rotation = Quaternion.Euler(0, YstartRotation + 15, 0);
                YtmpRotate = 15;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, -eyeRotate, 0) * Time.deltaTime);
            YtmpRotate -= (eyeRotate * Time.deltaTime);
            if (YtmpRotate <= YmaxRotate * -1)
            {
                this.transform.rotation = Quaternion.Euler(0, YstartRotation - 15, 0);
                YtmpRotate = -15;
            }
        }
    }
}
