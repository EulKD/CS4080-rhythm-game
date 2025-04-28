using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    float m;
    GameObject needle;

    // Start is called before the first frame update
    void Start()
    {
        needle = transform.Find("Needle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        m = PlayerPrefs.GetInt("Meter");

        needle.transform.localPosition = new Vector3((m-25)/(25/3), 0, 0);
    }
}
