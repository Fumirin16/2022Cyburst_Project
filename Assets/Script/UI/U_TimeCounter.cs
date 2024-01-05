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
    /// クリアパネル取得
    /// </summary>
    [SerializeField] GameObject barriar;

    /// <summary>
    /// クリアパネル取得
    /// </summary>
    [SerializeField] GameObject laser;

    /// <summary>
    ///  左右移動スピードの変数
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
        //時間をカウントダウンする
        leftTime -= Time.deltaTime;

        minute = (int)leftTime / 60;
        seconds = leftTime - minute * 60;

        //時間を表示する
        timeText.text = minute.ToString("00") + "." + seconds.ToString("f2");

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
    ///  時間オーバー
    /// </summary>
    public static bool IsTimeOver()
    {
        return leftTime <= 0f;
    }

    /// <summary>
    ///  Text取得
    /// </summary>
    void GoClear()
    {
        SceneManager.LoadScene("Clear");
    }
    #endregion ---Methods---
}