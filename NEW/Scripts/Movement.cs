using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform a;
    public GameObject c;
    // Start is called before the first frame update
    void Start()
    {
        OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.High;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (a.position.x > 2 && a.position.z < -2)
            c.SetActive(true);
        else
            c.SetActive(false);
    }
}
