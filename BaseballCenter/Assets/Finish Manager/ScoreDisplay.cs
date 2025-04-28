using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMesh resultScoreText;

    private void Start()
    {
        // PlayerPrefs����X�R�A��ǂݍ���
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        resultScoreText.text = finalScore.ToString();
    }
}
