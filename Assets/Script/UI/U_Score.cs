//Font��Score�\��
using UnityEngine;
using TMPro;

public class U_Score : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  Text�擾
    /// </summary>
    [SerializeField] TextMeshProUGUI ScoreText;

    /// <summary>
    ///  �X�R�A
    /// </summary>
    public static int score;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        ScoreText.text = "<sprite=" + 0 + ">";
    }

    /// <summary>
    ///  �X�R�A���Z
    /// </summary>
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = GetScoreText();
    }

    /// <summary>
    ///  �X�R�A�\��
    /// </summary>
    public static string GetScoreText()
    {
        string s = score.ToString();
        string rtnStr = "";

        // ��������ꕶ�����ϊ�
        for (int i = 0; i < s.Length; i++)
        {
            string convStr = "";

            convStr += s[i].ToString();            
            // �u<sprite=�yIndex��ID�z>�v�̌`�ɕϊ�
            rtnStr += "<sprite=" + convStr + ">";
        }
        return rtnStr;
    }
    #endregion ---Methods---
}