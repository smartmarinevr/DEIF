using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField]
    Transform gg, parent;


    [SerializeField]
    void Exit()
    {
        gg.parent = parent;
    }
    [SerializeField]
    Animator animator;
    public void Magic()
    {
        animator.enabled = true;
    }
}
