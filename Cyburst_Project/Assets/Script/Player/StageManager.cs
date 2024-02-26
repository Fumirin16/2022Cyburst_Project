//作成者地引翼
//ステージを動かす（スクロール）
//goal地点にきたら止まる
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// ステージのスピードを取得
    /// </summary>
    [Tooltip("ステージが移動するスピード")]
    [SerializeField] float speed; //speed m/s

    /// <summary>
    /// ステージのオブジェクト取得
    /// </summary>
    [Tooltip("ステージオブジェクト")]
    [SerializeField] GameObject obstacle; //speed m/s

    /// <summary>
    /// ステージを動かすbool値
    /// </summary>
    bool key = true;

    #endregion ---Fields---

    #region ---Methods---

    void Update()
    {
        // ステージ移動
        if (key == true)
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }

        // ゴール地点にいったら止まる
        if (U_TimeCounter.IsTimeOver())
        {
            key = false;
            obstacle.SetActive(false);
        }
    }
    #endregion ---Methods---
}