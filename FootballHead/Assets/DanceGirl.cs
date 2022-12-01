using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceGirl : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

   

    public void Dance()
    {
        anim.SetTrigger("dance");
    }

}
