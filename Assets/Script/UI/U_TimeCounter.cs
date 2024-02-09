using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class U_TimeCounter : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  分
    /// </summary>
    [SerializeField] int minute; 

    /// <summary>
    ///  秒
    /// </summary>
    [SerializeField] float seconds;

    /// <summary>
    /// 時間を表示するText型の変数
    /// </summary>
    [SerializeField] TextMeshProUGUI timeText; 

    /// <summary>
    /// クリアパネル取得
    /// </summary>
    [SerializeField] GameObject clear;

    /// <summary>
    /// バリアオブジェクト取得
    /// </summary>
    [SerializeField] GameObject barriar;

    /// <summary>
    /// レーザーオブジェクト取得
    /// </summary>
    [SerializeField] GameObject laser;

    /// <summary>
    ///  経過時間
    /// </summary>
    static float leftTime;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        leftTime = minute * 60 + seconds;
        clear.SetActive(false);
    }

    void Update()
    {
        // 時間をカウントダウンする
        leftTime -= Time.deltaTime;

        // 分、秒を計算
        minute = (int)leftTime / 60;
        seconds = leftTime - minute * 60;

        // 時間を表示する
        timeText.text = minute.ToString("00") + "." + seconds.ToString("f2");

        // 時間になったら
        if(IsTimeOver())
        {
            timeText.text = "";
            clear.SetActive(true);
            barriar.SetActive(false);
            laser.SetActive(false);
            Invoke(nameof(GoClear), 5);
        }
    }

    /// <summary>
    ///  タイムアップになったら返す関数
    /// </summary>
    public static bool IsTimeOver()
    {
        return leftTime <= 0f;
    }

    /// <summary>
    ///  クリアシーン遷移関数
    /// </summary>
    void GoClear()
    {
        SceneManager.LoadScene("Clear");
    }
    #endregion ---Methods---
}