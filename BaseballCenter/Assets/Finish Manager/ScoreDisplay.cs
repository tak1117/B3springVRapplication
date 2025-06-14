using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMesh resultScoreText;

    private void Start()
    {
        // PlayerPrefsからスコアを読み込む
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        resultScoreText.text = finalScore.ToString();
    }
}
