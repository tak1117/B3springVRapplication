using UnityEngine;

public class CountManager : MonoBehaviour
{
    public static CountManager Instance { get; private set; }

    [SerializeField] private TextMesh countText3D; // 3Dテキスト用
    private int count = 20; // 残り球数

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    private void Start()
    {
        // count をゲーム開始時に必ず 20 に初期化
        count = 20;

        // countText3D をチェックして、null の場合は新しく作成
        if (countText3D == null)
        {
            CreateCountText3D();
        }

        UpdateCountText();
    }

    // countText3D が null の場合に新しく作成
    private void CreateCountText3D()
    {
        // すでにシーンに存在している "CountText3D" を探す
        GameObject textObj = GameObject.Find("CountText3D");

        if (textObj == null)
        {
            // 存在しない場合は新規に作成
            textObj = new GameObject("CountText3D");
            textObj.transform.position = new Vector3(2, 2, 0); // 位置を調整
            countText3D = textObj.AddComponent<TextMesh>();
            countText3D.fontSize = 50;
            countText3D.color = Color.yellow;
        }
        else
        {
            countText3D = textObj.GetComponent<TextMesh>();
        }

        if (countText3D == null)
        {
            Debug.LogError("Failed to initialize countText3D!");
        }
    }

    // カウントを減らすメソッド
    public void DecreaseCount()
    {
        count--;
        UpdateCountText();
    }

    // count のみをリセットする
    public void ResetCount()
    {
        count = 20;
        UpdateCountText();
    }

    // テキストを更新
    private void UpdateCountText()
    {
        // countText3D が null の場合、新しく作成
        if (countText3D == null)
        {
            CreateCountText3D();
        }

        countText3D.text = "Pitches : " + count;
    }
}
