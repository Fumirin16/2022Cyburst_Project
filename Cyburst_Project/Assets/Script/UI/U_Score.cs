//FontでScore表示
using UnityEngine;
using TMPro;

public class U_Score : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  Text取得
    /// </summary>
    [SerializeField] TextMeshProUGUI ScoreText;

    /// <summary>
    ///  スコア
    /// </summary>
    public static int score;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        ScoreText.text = "<sprite=" + 0 + ">";
    }

    /// <summary>
    ///  スコア加算
    /// </summary>
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = GetScoreText();
    }

    /// <summary>
    ///  スコア表示
    /// </summary>
    public static string GetScoreText()
    {
        string s = score.ToString();
        string rtnStr = "";

        // 文字列を一文字ずつ変換
        for (int i = 0; i < s.Length; i++)
        {
            string convStr = "";

            convStr += s[i].ToString();            
            // 「<sprite=【IndexのID】>」の形に変換
            rtnStr += "<sprite=" + convStr + ">";
        }
        return rtnStr;
    }
    #endregion ---Methods---
}