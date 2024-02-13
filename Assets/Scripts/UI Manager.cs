using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("ScoreText")]
    [SerializeField] TextMeshProUGUI _walletText;
    [SerializeField] TextMeshProUGUI _currentScoreScreenText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScreenScore(float screenScore)
    {
        _currentScoreScreenText.text = screenScore.ToString();
        TextAnimationUtil.Instance.GrowAndShrink(_currentScoreScreenText.transform);
    }
}
