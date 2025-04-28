using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMesh scoreText3D; // 3D�e�L�X�g�p
    private int score = 0; // �X�R�A

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
        // ���ł� scoreText3D ���ݒ肳��Ă��邩�m�F
        if (scoreText3D == null)
        {
            CreateScoreText3D();
        }

        UpdateScoreUI();
    }

    // �X�R�A�����Z
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        // �X�R�A��PlayerPrefs�ɕۑ�
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // �X�R�A�̕\�����X�V
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

    // ScoreText3D ��V���ɍ쐬
    private void CreateScoreText3D()
    {
        GameObject textObj = GameObject.Find("ScoreText3D");

        if (textObj == null)
        {
            // ���ɃV�[���ɑ��݂��Ȃ��ꍇ�A�V���ɍ쐬
            textObj = new GameObject("ScoreText3D");
            textObj.transform.position = new Vector3(-2, 2, 0); // �ʒu�𒲐�
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

    // �X�R�A�����Z�b�g����
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI(); // �X�R�A�����Z�b�g������A�\�����X�V

        // �X�R�A��PlayerPrefs�ɕۑ�
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // ���݂̃X�R�A���擾
    public int GetScore()
    {
        return score;
    }
}
