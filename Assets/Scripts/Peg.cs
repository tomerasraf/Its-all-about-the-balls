using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color[] hitColor;
    [SerializeField] float colorTimer;

    int colorNumber = 0;
    float timer = 0;

    private void OnCollisionEnter(Collision collision)
    {
        int ballLayer = 6;

        if(collision.gameObject.layer == ballLayer)
        {
            ChangeColor();
        }
    }

    private void Update()
    {
        ColorResetTimer();
    }

    private void ColorResetTimer()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            GetComponent<Renderer>().material.color = defaultColor;
            timer = colorTimer;
        }
    }

    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = hitColor[colorNumber];
        timer = colorTimer;
        colorNumber++;
        if (colorNumber > hitColor.Length - 1)
        {
            colorNumber = 0;
        }
       
    }
}
