using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi_eye2 : MonoBehaviour {

    GameObject Player;
    public static float Ex;
    public static float Ey;
    public static float DEx;
    public static float DEy;
    public float alpha = 1.0f;

    public static float GetDEx()
    {
        return DEx;
    }

    public static float GetDEy()
    {
        return DEy;
    }

    public static float GetEx()
    {
        return Ex;
    }

    public static float GetEy()
    {
        return Ey;
    }

    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.Find("linda-02");
    }
	
	// Update is called once per frame
	void Update()
    {
        float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;
        if (Playery >= 180)
        {
            Playery = Playery - 360;
        }

        //degx,degyを取得
        float degx = target_directer2.Getx();
        float degy = target_directer2.Gety();

        //目の回転角度の計算
        if (degx > 0 && degx <= 15)
        {
            DEx = alpha;
            Ex = DEx * degx;
        }
        else if (degx < 0 && degx >= -15)
        {
            DEx = alpha;
            Ex = DEx * degx;
        }
        else if (degx <= 30 && degx > 15)
        {
            DEx = alpha * ((30 - degx) / 15);
            Ex = DEx * degx;
        }
        else if (degx >= -30 && degx < -15)
        {
            DEx = alpha * ((30 + degx) / 15);
            Ex = DEx * degx;
        }
        else
        {
            DEx = 0;
            Ex = 0;
        }

        if (degy > 0 && degy <= 10)
        {
            DEy = alpha;
            Ey = DEy * degy;
        }
        else if (degy < 0 && degy >= -10)
        {
            DEy = alpha;
            Ey = DEy * degy;
        }
        else if (degy <= 20 && degy > 10)
        {
            DEy = alpha * ((20 - degy) / 10);
            Ey = DEy * degy;
        }
        else if (degy >= -20 && degy < -10)
        {
            DEy = alpha * ((20 + degy) / 10);
            Ey = DEy * degy;
        }
        else
        {
            DEy = 0;
            Ey = 0;
        }

        //頭の回転角
        float Hx = hi_head2.GetHx();
        float Hy = hi_head2.GetHy();

        //体の回転角
        float Bx = hi_body2.GetBx();
        float By = hi_body2.GetBy();

        //目を外す
        float dx = target_directer2.Getdx();
        float dy = target_directer2.Getdy();
        float dhx = target_directer2.Getdhx();
        float dhy = target_directer2.Getdhy();

        //回転速度の取得
        //float step = speed2Controller.GetEv();
        float step = 0.15f;

        //目の回転
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(By + Hy + Ey + dy + dhy + Playerx, Bx + Hx + Ex + dx + dhx + Playery, 0), step);
    }
}