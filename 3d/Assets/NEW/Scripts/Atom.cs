using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    [SerializeField]
    GameObject a, b, c;
    [SerializeField]
    float f=10;
    // Update is called once per frame
    void Update()
    {
        a.transform.Rotate(0, 0, 10 * Time.deltaTime * f);
        b.transform.Rotate(0, 10 * Time.deltaTime * f, 0);
        c.transform.Rotate(10 * Time.deltaTime * f, 0, 0);
    }
}
