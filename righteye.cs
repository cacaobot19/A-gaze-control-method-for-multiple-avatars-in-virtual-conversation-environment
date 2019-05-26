using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class righteye : MonoBehaviour
{
    Transform target;
    float XstartRotation;
    float YstartRotation;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("lefteye/kurome").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        YstartRotation = target.transform.rotation.eulerAngles.y;
        XstartRotation = target.transform.rotation.eulerAngles.x;
        transform.eulerAngles = new Vector3(XstartRotation, YstartRotation, 0);
    }
}
