﻿using System.Collections;
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
        target = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        YstartRotation = target.transform.eulerAngles.y;
        XstartRotation = target.transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(XstartRotation, YstartRotation, 0);
    }
}
