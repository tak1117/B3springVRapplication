using UnityEngine;

public class ResultScoreDisplay : MonoBehaviour
{
    private TextMesh resultScoreText3D;

    private void Start()
    {
        // リザルト用のテキストオブジェクトを作成
        GameObject textObj = new GameObject("ResultScoreText3D");
        textObj.transform.position = new Vector3(0, 1, -16);  // 位置を調整

        // 回転設定
        textObj.transform.rotation = Quaternion.Euler(90, 0, 0); 

        // TextMeshを追加
        resultScoreText3D = textObj.AddComponent<TextMesh>();
        resultScoreText3D.fontSize = 100;
        resultScoreText3D.color = Color.yellow;

        // アンカー設定（中央揃え）
        resultScoreText3D.anchor = TextAnchor.UpperCenter;

        // スコアを即時に反映
        UpdateResultScore();
    }

    private void UpdateResultScore()
    {
        int finalScore = ScoreManager.Instance.GetScore();
        resultScoreText3D.text = finalScore.ToString();
    }
}
