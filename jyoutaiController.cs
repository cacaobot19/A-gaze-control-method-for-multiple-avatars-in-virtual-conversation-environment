using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jyoutaiController : MonoBehaviour {
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
    void Start () {

    }

	// Update is called once per frame
	void Update () {

        vol = Mic_Test.Geta();
        //Debug.Log(vol);

        if (vol < 2.0f)
        {
            R = 0.5f;
            L = 1.0f;
            //Debug.Log("Waiting");
        }

        else if (vol > 3 && vol < 10)
        {
            R = 0.75f;
            L = 1.5f;
            //Debug.Log("Listening");
        }

        else if (vol > 15)
        {
            R = 0.75f;
            L = 1.0f;
            //Debug.Log("Utterance");
        }
    }
}
