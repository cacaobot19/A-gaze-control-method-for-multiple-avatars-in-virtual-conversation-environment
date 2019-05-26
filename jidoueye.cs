using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jidoueye : MonoBehaviour {
    GameObject ViewPoint;
    GameObject lefteye;
    GameObject Head;
    GameObject Body;
    float speed = 50f;

    // Use this for initialization
    void Start()
    {
        this.ViewPoint = GameObject.Find("ViewPoint");
        this.lefteye = GameObject.Find("Head/eye/lefteye");
        this.Head = GameObject.Find("Head");
        this.Body = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        float ViewX = this.ViewPoint.transform.position.x;
        float ViewY = this.ViewPoint.transform.position.y;
        float ViewZ = this.ViewPoint.transform.position.z;

        float centerX = this.Head.transform.position.x;
        float centerY = this.Head.transform.position.y + 0.1f;
        float centerZ = this.lefteye.transform.position.z;

        float lefteyeX = this.lefteye.transform.position.x;
        float lefteyeY = this.lefteye.transform.position.y;
        float lefteyeZ = this.lefteye.transform.position.z;

        float HeadX = this.Head.transform.position.x;
        float HeadY = this.Head.transform.position.y;
        float HeadZ = this.Head.transform.position.z;

        float BodyX = this.Body.transform.position.x;
        float BodyY = this.Body.transform.position.y;
        float BodyZ = this.Body.transform.position.z;

        //目標角度の計算
        float x = ViewX - centerX;
        float z = ViewZ - centerZ;
        float radx = Mathf.Atan2(x, z);
        float degx = radx * Mathf.Rad2Deg;
        float y = ViewY - centerY;
        float z2 = ViewZ - centerZ;
        float rady = Mathf.Atan2(y, z2);
        float degy = rady * Mathf.Rad2Deg;

        Debug.Log(degx);
        Debug.Log(degy);

        //目の回転位置計算
        //float ex = ViewX - lefteyeX;
        //float ez = ViewZ - lefteyeZ;
        //float radex = Mathf.Atan2(ex, ez);
        //float degex = radex * Mathf.Rad2Deg;
        //float ey = ViewY - lefteyeY;
        //float ez2 = ViewZ - lefteyeZ;
        //float radey = Mathf.Atan2(ey, ez2);
        //float degey = radey * Mathf.Rad2Deg;

        //頭の回転位置計算
        //float hx = ViewX - HeadX;
        //float hz = ViewZ - HeadZ;
        //float radhx = Mathf.Atan2(hx, hz);
        //float deghx = radhx * Mathf.Rad2Deg;
        //float hy = ViewY - HeadY;
        //float hz2 = ViewZ - HeadZ;
        //float radhy = Mathf.Atan2(hy, hz2);
        //float deghy = radhy * Mathf.Rad2Deg;

        //体の回転位置計算
        //float bx = ViewX - HeadX;
        //float bz = ViewZ - HeadZ;
        //float radbx = Mathf.Atan2(bx, bz);
        //float degbx = radbx * Mathf.Rad2Deg;
        //float by = ViewY - HeadY;
        //float bz2 = ViewZ - HeadZ;
        //float radby = Mathf.Atan2(by, bz2);
        //float degby = radby * Mathf.Rad2Deg;

        if (-165 < degx && degx < 0)
        {
            degx = -165;
        }
        if (degx < 165 && degx > 0)
        {
            degx = 165;
        }
        if (degy > -170 && degy < 0)
        {
            degy = -170;
        }
        if (degy < 170 && degy > 0)
        {
            degy = 170;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(degy, degx, 0), step);
    }
}