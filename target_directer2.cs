using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_directer2 : MonoBehaviour
{
    GameObject Player;
    GameObject lefteye;
    GameObject Head;
    GameObject Head1;
    GameObject eye;
    GameObject Head3;
    GameObject eye3;
    GameObject Chest;
    GameObject Uchest;
    GameObject Lhand;
    GameObject Rhand;
    GameObject up;
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
    void Start()
    {
        this.Player = GameObject.Find("linda-02");
        this.lefteye = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye");
        this.Head = GameObject.Find("linda-02/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        this.Head1 = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head");
        this.eye = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_C_Neck/J_Bip_C_Head/J_Adj_L_FaceEyeSet/J_Adj_L_FaceEye");
        this.eye3 = GameObject.Find("J_Adj_L_FaceEye2");
        this.Head3 = GameObject.Find("J_Bip_C_Head2");
        this.Chest = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest");
        //this.UChest = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest");
        this.Lhand = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_L_Shoulder/J_Bip_L_UpperArm");
        this.Rhand = GameObject.Find("Linda/Root/Global/Position/J_Bip_C_Hips/J_Bip_C_Spine/J_Bip_C_Chest/J_Bip_C_UpperChest/J_Bip_R_Shoulder/J_Bip_R_UpperArm");
        this.up = GameObject.Find("up");

    }

    // Update is called once per frame
    void Update()
    {
        //float Playerx = this.Player.transform.eulerAngles.x;
        float Playery = this.Player.transform.eulerAngles.y;
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
        float lindaX = this.Head1.transform.position.x;
        float lindaY = this.eye.transform.position.y;
        float lindaZ = this.eye.transform.position.z;

        //カメラの位置
        float CameraX = this.Head3.transform.position.x;
        float CameraY = this.eye3.transform.position.y;
        float CameraZ = this.eye3.transform.position.z;

        //上半身の位置
        float chestX = this.Chest.transform.position.x;
        float chestY = this.Chest.transform.position.y - 2.0f;
        float chestZ = this.Chest.transform.position.z;

        //float UchestX = this.Chest.transform.position.x;
       // float UchestY = this.Chest.transform.position.y;
        //float UchestZ = this.Chest.transform.position.z;

        //左手の位置
        float LhandX = this.Lhand.transform.position.x;
        float LhandY = this.lefteye.transform.position.y;
        float LhandZ = this.Lhand.transform.position.z;

        //右手の位置
        float RhandX = this.Rhand.transform.position.x;
        float RhandY = this.lefteye.transform.position.y;
        float RhandZ = this.Rhand.transform.position.z;

        //頭の上の位置
        float upX = this.up.transform.position.x;
        float upY = this.up.transform.position.y;
        float upZ = this.up.transform.position.z;
        //注視を外す
        delta2 += Time.deltaTime;
        float R = jyoutaiController.GetR();
        float L = jyoutaiController.GetL();
        //Debug.Log(delta2);
        if (delta2 >= (1.5f - R) * L)
        {
            delta2 = 0;
            float dice2 = Random.Range(0.1f, 1.0f);
            if (dice2 < 1 - R)
            {
                dx = Random.Range(-0.3f, 0.3f);
                dy = Random.Range(-0.1f, 0.1f);
                dhx = Random.Range(-0.3f, 0.3f);
                dhy = Random.Range(-0.1f, 0.1f);
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
        if (delta >= 1.5f)
        {
            delta = 0;
            
            //int D = target_directer.Getdice();
            if (Playery > -35)
            {
                x = CameraX - centerX;
                y = CameraY - centerY;
                z = CameraZ - centerZ;
                radx = Mathf.Atan(x / z);
                rady = Mathf.Atan(y / x);
                degx = radx * Mathf.Rad2Deg - Playery;
                degy = rady * Mathf.Rad2Deg;

            }
            else if (Playery <= -35)
            {
                dice = Random.Range(1, 10);
                if (dice > 0 && dice <= 10)
                {
                    x = lindaX - centerX;
                    y = lindaY - centerY;
                    z = lindaZ - centerZ;
                    radx = Mathf.Atan(x / z);
                    rady = Mathf.Atan(y / x);
                    degx = radx * Mathf.Rad2Deg - Playery;
                    degy = rady * Mathf.Rad2Deg;
                    if (degx > 0)
                    {
                        degx = -180 + degx;
                    }
                    //Debug.Log("linda");

                    int dice3 = Random.Range(1, 100);
                    if (dice3 < 6)
                    {
                        x = chestX - centerX;
                        y = chestY - centerY;
                        z = chestZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx > 0)
                        {
                            degx = -180 + degx;
                        }
                        if (degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("胸");
                    }
                   else if (dice3 >= 6 && dice3 < 11)
                    {
                        x = LhandX - centerX;
                        y = LhandY - centerY;
                        z = LhandZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx > 0)
                        {
                            degx = -180 + degx;
                        }
                        if (degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("左");
                    }
                    else if (dice3 >=11 && dice3 < 16)
                    {
                        x = RhandX - centerX;
                        y = RhandY - centerY;
                        z = RhandZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx > 0)
                        {
                            degx = -180 + degx;
                        }
                        if (degy < 0)
                        {
                            degy = -degy;
                        }
                        Debug.Log("右");
                    }
                    else if(dice3 >= 16 && dice3< 21)
                    {
                        x = upX - centerX;
                        y = upY - centerY;
                        z = upZ - centerZ;
                        radx = Mathf.Atan(x / z);
                        rady = Mathf.Atan(y / x);
                        degx = radx * Mathf.Rad2Deg - Playery;
                        degy = rady * Mathf.Rad2Deg;
                        if (degx > 0)
                        {
                            degx = -180 + degx;
                        }
                        
                        
                        Debug.Log("上");
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
                    //Debug.Log("Camera");
                }
            }
        }
    }
}