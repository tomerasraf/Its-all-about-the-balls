using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color[] hitColor;
    [SerializeField] float colorTimer;
    [SerializeField] TextMeshPro _scorePopupPrefab;

    private static float _scoreScreen = 0;

    TextMeshPro popupTextClone;

    int colorNumber = 0;
    float timer = 0;

    private void Update()
    {
        ColorResetTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int ballLayer = 6;

        if(collision.gameObject.layer == ballLayer)
        {
            ChangeColor();

            PegHitScore();
        }
    }

    private void ColorResetTimer()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            GetComponent<Renderer>().material.color = defaultColor;
            timer = colorTimer;
            colorNumber = 0;
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

    public void PegHitScore()
    {
        _scoreScreen++;
       popupTextClone = Instantiate(_scorePopupPrefab, transform.position, Quaternion.identity);
       TextAnimationUtil.Instance.PopUpScore(popupTextClone.transform, _scoreScreen);
    }

    
}
