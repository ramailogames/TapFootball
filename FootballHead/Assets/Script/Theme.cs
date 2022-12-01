using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerCS.instance.Play("theme");
    }

   
}
