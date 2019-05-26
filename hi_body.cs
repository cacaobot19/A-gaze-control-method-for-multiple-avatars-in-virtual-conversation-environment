using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi_body : MonoBehaviour {
    GameObject Player;
    public static float Bx;
    public static float By;
    public static float DBx;
    public static float DBy;

    public static float GetBx()
    {
        return Bx;
    }

    public static float GetBy()
    {
        return By;
    }

    // Use this for initialization
    void Start () {
        this.Player = GameObject.Find("Linda");
    }
	
	// Update is called once per frame
	void Update () {
        float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;

        //degx,degyを取得
        float degx = target_directer.Getx();
        float degy = target_directer.Gety();

        //目の回転比
        float DEx = hi_eye.GetDEx();
        float DEy = hi_eye.GetDEy();
        //頭の回転比
        float DHx = hi_head.GetDHx();
        float DHy = hi_head.GetDHy();

        //体の回転角計算
        DBx = 1 - DEx - DHx;
        DBy = 1 - DEy - DHy;
        Bx = DBx * degx;
        By = DBy * degy;

        //回転速度の取得
        //float step = speedController.GetBv();
        float step = 2.5f;

        // 体の回転
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(By + Playerx, Bx + Playery, 0), step);
    }
}