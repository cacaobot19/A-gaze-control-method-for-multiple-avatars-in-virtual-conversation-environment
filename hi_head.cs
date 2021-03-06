﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi_head : MonoBehaviour
{
    GameObject Player;
    public static float Hx;
    public static float Hy;
    public static float DHx;
    public static float DHy;
    public float beta = 1.0f;

    public static float GetHx()
    {
        return Hx;
    }

    public static float GetHy()
    {
        return Hy;
    }

    public static float GetDHx()
    {
        return DHx;
    }

    public static float GetDHy()
    {
        return DHy;
    }

    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.Find("Linda");
    }

    // Update is called once per frame
    void Update()
    {
        float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;

        //degx,degyを取得
        float degx = target_directer.Getx();
        float degy = target_directer.Gety();

        //目の回転比
        float DEx = hi_eye.GetDEx();
        float DEy = hi_eye.GetDEy();

        //頭の回転角度の計算
        if (degx > 0 && degx <= 50)
        {

            DHx = beta * (1 - DEx);
            Hx = DHx * degx;
        }
        else if (degx < 0 && degx >= -50)
        {
            DHx = beta * (1 - DEx);
            Hx = DHx * degx;
        }
        else if (degx <= 130 && degx > 50)
        {
            DHx = beta * (1 - (((degx - 50) / 2) / 80));
            Hx = DHx * degx;
        }
        else if (degx >= -130 && degx < -50)
        {
            DHx = beta * (1 - (((-degx - 50) / 2) / 80));
            Hx = DHx * degx;
        }
        else
        {
            DHx = 0;
            Hx = 0;
        }

        DHy = beta * (1 - DEy);
        if (degy >= 0)
        {
            Hy = DHy * degy;
        }
        else
        {
            Hy = DHy * degy;
        }

        //回転速度の取得
        //float step = speedController.GetHv();
        float t = target_directer.Gett();
        float step = 0;
        if (t < 0.18f)
        {
            step = 1.5f;
        }
        else if (t >= 0.18f && t < 0.35f)
        {
            step = 2.5f;
        }
        else if (t >= 0.35f && t < 0.5f)
        {
            step = 0.5f;
        }

        //体の回転角
        float Bx = hi_body.GetBx();
        float By = hi_body.GetBy();

        //目を外す
        float dhx = target_directer.Getdhx();
        float dhy = target_directer.Getdhy();
        //Debug.Log(dhx);
        //頭の回転
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(By + Hy + dhy + Playerx, Bx + Hx + dhx + Playery, 0), step);
    }
}