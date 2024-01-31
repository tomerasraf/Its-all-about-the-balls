using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] Color[] hitColor;
    int i = 0;

    private void OnCollisionEnter(Collision collision)
    {
        int ballLayer = 6;

        if(collision.gameObject.layer == ballLayer)
        {
            i++;
            if(i > hitColor.Length - 1)
            {
                i = 0;
            }
                GetComponent<Renderer>().material.color = hitColor[i];
            
        }
    }
}
