using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_directer : MonoBehaviour {
    GameObject Player;
    GameObject lefteye;
    GameObject Head;
    GameObject Head2;
    GameObject eye2;
    GameObject Head3;
    GameObject eye3;
    GameObject Chest;
    GameObject Lhand;
    GameObject Rhand;
    public static float delta = 0;
    float delta2 = 0;
    public static int dice;
    float x;
    float y;
    float z;
    float radx;
    public static float degx;
    float rady;
    public static float degy;
    public static float dx;
    public static float dy;
    public static float dhx;
    public static float dhy;

    public static float Getx()
    {
        return degx;
    }

    public static float Gety()
    {
        return degy;
    }

    public static float Getdx()
    {
        return dx;
    }

    public static float Getdy()
    {
        return dy;
    }

    public static float Getdhx()
    {
        return dhx;
    }

    public static float Getdhy()
    {
        return dhy;
    }

    public static float Gett()
    {
        return delta;
    }

    public static int Getdice()
    {
        return dice;
    }

    // Use this for initialization
    void Start () {
        this.Player = GameObject.Find("Linda");
        this.lefteye = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye");
        this.Head = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        this.Head2 = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        this.eye2 = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye");
        this.eye3 = GameObject.Find("J_Adj_L_FaceEye2");
        this.Head3 = GameObject.Find("J_Bip_C_Head2");
        this.Chest = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest");
        this.Lhand = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_L_Shoulder/J_Bip_L_UpperArm/J_Bip_L_LowerArm/J_Bip_L_Hand");
        this.Rhand = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_R_Shoulder/J_Bip_R_UpperArm/J_Bip_R_LowerArm/J_Bip_R_Hand");
    }
	
	// Update is called once per frame
	void Update () {
        //float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;
        //Debug.Log(Playery);
        if (Playery >= 180)
        {
            Playery = Playery - 360;
        }
        //Debug.Log(Playery);
        //視点基準の位置
        float centerX = this.Head.transform.position.x;
        float centerY = this.lefteye.transform.position.y;
        float centerZ = this.lefteye.transform.position.z;

        //二人目の顔の位置
        float linda2X = this.Head2.transform.position.x;
        float linda2Y = this.eye2.transform.position.y;
        float linda2Z = this.eye2.transform.position.z;

        //カメラの位置
        float CameraX = this.Head3.transform.position.x;
        float CameraY = this.eye3.transform.position.y;
        float CameraZ = this.eye3.transform.position.z;

        //上半身の位置
        float chestX = this.Chest.transform.position.x;
        float chestY = this.Chest.transform.position.y;
        float chestZ = this.Chest.transform.position.z;

        //左手の位置
        float LhandX = this.Lhand.transform.position.x;
        float LhandY = this.Lhand.transform.position.y;
        float LhandZ = this.Lhand.transform.position.z;

        //右手の位置
        float RhandX = this.Rhand.transform.position.x;
        float RhandY = this.Rhand.transform.position.y;
        float RhandZ = this.Rhand.transform.position.z;

        //注視を外す
        delta2 += Time.deltaTime;
        float R = jyoutaiController.GetR();
        float L = jyoutaiController.GetL();
        //Debug.Log(delta2);
        if (delta2 >= (1 - R) * L)
        {
            delta2 = 0;
            float dice2 = Random.Range(0.1f, 1.0f);
            if (dice2 < 1 - R)
            {
                dx = Random.Range(-1, 1);
                dy = Random.Range(-0.5f, 0.5f);
                dhx = Random.Range(-1, 1);
                dhy = Random.Range(-0.5f, 0.5f);
            }
            else
            {
                dx = 0;
                dy = 0;
                dhx = 0;
                dhy = 0;
            }
        }

        //ターゲットの選択
        delta += Time.deltaTime;
        if (delta >= 1.0)
        {
            delta = 0;
            dice = Random.Range(1, 10);
            int D = target_directer2.Getdice();
            if(Playery < 75)
            {
                x = CameraX - centerX;
                y = CameraY - centerY;
                z = CameraZ - centerZ;
                radx = Mathf.Atan(x / z);
                rady = Mathf.Atan(y / x);
                degx = radx * Mathf.Rad2Deg - Playery;
                degy = rady * Mathf.Rad2Deg;
               
            }
            else if(Playery >= 75)
            {
                if ((D >= 1 && D <= 2) || (dice > 0 && dice <= 8))
                {
                    x = linda2X - centerX;
                    y = linda2Y - centerY;
                    z = linda2Z - centerZ;
                    radx = Mathf.Atan(x / z);
                    rady = Mathf.Atan(y / x);
                    degx = radx * Mathf.Rad2Deg - Playery;
                    degy = rady * Mathf.Rad2Deg;
                    if (degx < 0)
                    {
                        degx = 180 + degx;
                    }
                    Debug.Log("linda2");

                    int dice3 = Random.Range(1, 10);
                    if(dice3 < 2)
                    {
                        x = chestX - centerX;
                        y = chestY - centerY;
                        z = chestZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx < 0)
                        {
                            degx = 180 + degx;
                        }
                        if(degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("上半身");
                    }
                    else if(dice3 >= 2 && dice3 < 4)
                    {
                        x = LhandX - centerX;
                        y = LhandY - centerY;
                        z = LhandZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx < 0)
                        {
                            degx = 180 + degx;
                        }
                        if (degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("左手");
                    }
                    else if(dice3 >= 4 && dice3 < 6)
                    {
                        x = RhandX - centerX;
                        y = RhandY - centerY;
                        z = RhandZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx < 0)
                        {
                            degx = 180 + degx;
                        }
                        if (degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("右手");
                    }
                }
                else
                {
                    x = CameraX - centerX;
                    y = CameraY - centerY;
                    z = CameraZ - centerZ;
                    radx = Mathf.Atan(x / z);
                    rady = Mathf.Atan(y / x);
                    degx = radx * Mathf.Rad2Deg - Playery;
                    degy = rady * Mathf.Rad2Deg;
                    Debug.Log("Camera");
                }
            }    
        }
    }
}