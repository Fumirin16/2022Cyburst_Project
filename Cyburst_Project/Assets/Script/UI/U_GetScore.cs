//作成者地引翼
//最終スコア表示
using UnityEngine;
using TMPro;

public class U_GetScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = U_Score.GetScoreText();
    }
}