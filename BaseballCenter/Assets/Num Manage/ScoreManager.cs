using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMesh scoreText3D; // 3Dテキスト用
    private int score = 0; // スコア

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            score = 0;
        }
        else
        {
            //Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // すでに scoreText3D が設定されているか確認
        if (scoreText3D == null)
        {
            CreateScoreText3D();
        }

        UpdateScoreUI();
    }

    // スコアを加算
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        // スコアをPlayerPrefsに保存
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // スコアの表示を更新
    private void UpdateScoreUI()
    {
        if (scoreText3D != null)
        {
            scoreText3D.text = "Score : " + score;
        }
        else
        {
            Debug.LogError("scoreText3D is null during UpdateScoreUI.");
        }
    }

    // ScoreText3D を新たに作成
    private void CreateScoreText3D()
    {
        GameObject textObj = GameObject.Find("ScoreText3D");

        if (textObj == null)
        {
            // 既にシーンに存在しない場合、新たに作成
            textObj = new GameObject("ScoreText3D");
            textObj.transform.position = new Vector3(-2, 2, 0); // 位置を調整
            scoreText3D = textObj.AddComponent<TextMesh>();
            scoreText3D.fontSize = 50;
            scoreText3D.color = Color.white;
        }
        else
        {
            scoreText3D = textObj.GetComponent<TextMesh>();
        }

        if (scoreText3D == null)
        {
            Debug.LogError("Failed to initialize scoreText3D!");
        }
    }

    // スコアをリセットする
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI(); // スコアをリセットした後、表示を更新

        // スコアをPlayerPrefsに保存
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // 現在のスコアを取得
    public int GetScore()
    {
        return score;
    }
}
