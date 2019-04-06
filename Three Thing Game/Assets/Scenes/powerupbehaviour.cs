using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class powerupbehaviour : MonoBehaviour
{

    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Power_Up_Cube")
        {
            Destroy(col.gameObject);
        }
    }

}
