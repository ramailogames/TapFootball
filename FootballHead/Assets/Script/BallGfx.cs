using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGfx : MonoBehaviour
{
    public float y;

    public bool rotate = false;

    void Update()
    {
        if (!rotate)
        {
            return;
        }
        transform.Rotate(new Vector3(0, 0, y)); //applying rotation
    }
}
