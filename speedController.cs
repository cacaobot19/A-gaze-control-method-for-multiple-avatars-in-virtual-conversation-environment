using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedController : MonoBehaviour {
    GameObject Player;
    GameObject lefteye;
    GameObject Head;
    GameObject Body;
    double e = System.Math.E;
    double Ta = 0.5;
    double Tvor = 0.25;
    double Tsa = 0.025;
    double Th = 0.35;
    double Tb = 0.2;
    double Et;
    double Ht;
    double Bt;
    public static float Ev;
    public static float Hv;
    public static float Bv;

    public static float GetEv()
    {
        return Ev;
    }

    public static float GetHv()
    {
        return Hv;
    }

    public static float GetBv()
    {
        return Bv;
    }

    // Use this for initialization
    void Start () {
        this.lefteye = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye");
        this.Head = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        this.Body = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine");
        this.Player = GameObject.Find("Linda");
    }
	
	// Update is called once per frame
	void Update () {
        float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;

        //回転オフセット
        double E0x = lefteye.transform.eulerAngles.x;
        double E0y = lefteye.transform.eulerAngles.y;
        double E0 = System.Math.Pow(((E0x * E0x) + (E0y * E0y)), 1 / 2);
        double H0x = Head.transform.eulerAngles.x;
        double H0y = Head.transform.eulerAngles.y;
        double H0 = System.Math.Pow(((H0x * H0x) + (H0y * H0y)), 1 / 2);
        double B0x = Body.transform.eulerAngles.x;
        double B0y = Body.transform.eulerAngles.y;
        double B0 = System.Math.Pow(((B0x * B0x) + (B0y * B0y)), 1 / 2);

        //時間の取得
        double t = target_directer.Gett();

        //パラメータ
        double C1 = System.Math.Pow(e, Tvor - Ta);
        double C2 = System.Math.Pow(e, Ta - Tvor);
        double C3 = System.Math.Pow(e, -2 * t + Tvor + Ta);
        double C4 = System.Math.Pow(e, Tsa - Th);
        double C5 = System.Math.Pow(e, Th - Tsa);
        double C6 = System.Math.Pow(e, -2 * t + Tsa + Th);
        double C7 = System.Math.Pow(e, Tb - Ta);
        double C8 = System.Math.Pow(e, Ta - Tb);
        double C9 = System.Math.Pow(e, -2 * t + Tb + Ta);

        float dx = target_directer.Getdx();
        float dy = target_directer.Getdy();
        float dhx = target_directer.Getdhx();
        float dhy = target_directer.Getdhy();
        double EmaxX = hi_body.GetBx() + hi_eye.GetEx() + hi_head.GetHx() + Playerx + dx + dhx;
        double EmaxY = hi_body.GetBy() + hi_eye.GetEy() + hi_head.GetHy() + Playery + dy + dhy;
        double Emax = System.Math.Pow(((EmaxX * EmaxX) + (EmaxY * EmaxY)), 1 / 2);
        double Eta = Emax * 0.5;
        //目の回転時間
        if ( t >= 0 && t <= Tsa)
        {
            Et = E0 + ((Emax - E0) / Tsa) * t;
        }
        else if (t > Tsa && t <= Tvor)
        {
            Et = Emax;
        }
        else if (t > Tvor && t <= Ta)
        {
            Et = E0 + (Eta - Emax) * (((1 + C1) * (C2 - C3)) / ((C2 - C1) * (1 + C3)));
        }
 
        double Hthx = hi_body.GetBx() + hi_head.GetHx() + dhx + Playerx;
        double Hthy = hi_body.GetBy() + hi_head.GetHy() + dhy + Playery;
        double Hth = System.Math.Pow(((Hthx * Hthx) + (Hthy * Hthy)), 1 / 2);
        //頭の回転時間
        if (t >= 0 && t <= Tsa)
        {
            Ht = H0;
        }
        else if (t > Tsa && t <= Th)
        {
            Ht = H0 + (Hth - H0) * (((1 + C4) * (C5 - C6)) / ((C5 - C4) * (1 + C6)));
        }
        else if (t > Th && t <= Ta)
        {
            Ht = H0 + Hth;
        }

        double Btax = hi_body.GetBx() + Playerx;
        double Btay = hi_body.GetBy() + Playery;
        double Bta = System.Math.Pow(((Btax * Btax) + (Btay * Btay)), 1 / 2);
        //体の回転時間
        if (t >= 0 && t <= Tb)
        {
            Bt = B0;
        }
        else if (t > Tsa && t <= Th)
        {
            Bt = (Bta - B0) * (((1 + C7) * (C8 - C9)) / ((C8 - C7) * (1 + C9)));
        }

        //回転速度
        Ev = System.Convert.ToSingle(Emax / Et);
        Hv = System.Convert.ToSingle(Hth / Ht);
        Bv = System.Convert.ToSingle(Bta / Bt);
        //Debug.Log(Ev);
        //Debug.Log(Hv);
        //Debug.Log(Bv);

    }
}