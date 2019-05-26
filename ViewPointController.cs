using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPointController : MonoBehaviour
{
    public float Speed = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3(0, -Speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.P))
        {
            this.transform.position += new Vector3(0, 0, Speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            this.transform.position += new Vector3(0, 0, -Speed) * Time.deltaTime;
        }
    }
}
