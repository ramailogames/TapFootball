using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("load", 3f);
    }

    void load()
    {
        FindObjectOfType<SceneLoader>().LoadScene("MainMenu");
    }

}
