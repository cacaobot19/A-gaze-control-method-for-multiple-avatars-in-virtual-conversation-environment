using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listeningeye : MonoBehaviour {
    float L = 1.5f;
    float delta = 0;
    float R = 7.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.L)
        {
            this.delta = 0;
            int dice = Random.Range(1, 10);
            if (dice <= this.R)
            {
                transform.rotation = Quaternion.identity;
            }
            else
            {
                float x = Random.Range(-10, 10);
                float y = Random.Range(-15, 15);
                transform.eulerAngles = new Vector3(x, y, 0);
            }
        }
    }
}
