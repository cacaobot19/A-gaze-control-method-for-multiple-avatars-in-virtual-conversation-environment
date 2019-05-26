using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;


public class jyoutai2Controller : MonoBehaviour
{
    GameObject linda02;
    public static float R;
    public static float L;

    public static float GetR()
    {
        return R;
    }

    public static float GetL()
    {
        return L;
    }

    public static float vol = 0;

    // Use this for initialization
    void Start()
    {
        linda02 = GameObject.Find("linda-02");
    }

    // Update is called once per frame
    void Update()
    {

        vol = Mic_Test.Geta();
        Debug.Log(vol);

        if (vol <= 0.5f)
        {
            R = 0.75f;
            L = 1.5f;
            //Debug.Log("Waiting");
            linda02.GetComponent<AIUEO>().enabled = false;
        }

        else if (vol > 0.5 && vol <= 1.5)
        {
            R = 0.9f;
            L = 2.0f;
            //Debug.Log("Listening");
            linda02.GetComponent<AIUEO>().enabled = false;
        }

        else if (vol > 1.5)
        {
            float t = Time.deltaTime;
            if(t < 0.5f)
            {
                t = 0;
                R = 0.9f;
                L = 2.0f;
            }
            if (t > 5.0f)
            {
                t = 0;
                R = 0.9f;
                L = 1.5f;
            }
            else
            {
                t = 0;
                R = 0.75f;
                L = 1.5f;
            }
            //Debug.Log("Utterance");
            linda02.GetComponent<AIUEO>().enabled = true;
        }
    }
}
