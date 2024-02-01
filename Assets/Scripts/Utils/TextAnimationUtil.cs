using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextAnimationUtil : MonoBehaviour
{
    public static TextAnimationUtil Instance;

    [SerializeField] Transform _scoreMagnet;

    [SerializeField] float _fadeDuration;


    private void Awake()
    {
        Instance = this;
    }

    public void PopUpScore(Transform text, float score)
    {
        text.DOMoveY(text.position.y + 0.5f, 0.3f).OnComplete(() => 
        {
            text?.GetComponent<TextMeshPro>().DOFade(0, 0.5f);
            text.DOMove(_scoreMagnet.position, 0.7f).OnComplete(() =>
            {
                text.DOKill();
                UIManager.Instance.AddScreenScore(score);
                Destroy(text.gameObject);
            });
        });
    }

    public void GrowAndShrink(Transform text)
    {
        text.DOScale(1.3f, 0.2f).OnComplete(() => 
        {
            text.DOScale(1, 0.2f);
        });
    }


}
