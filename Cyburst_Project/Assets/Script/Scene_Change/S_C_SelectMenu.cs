//MenuからMain、Ruleシーンに移動
//button選択
//作成者地引翼
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class S_C_SelectMenu : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  決定音をいれる変数
    /// </summary>
    [Tooltip("決定音")]
    [SerializeField] AudioClip clickSE;

    /// <summary>
    ///  次のシーンにいくまでの間隔時間
    /// </summary>
    [Tooltip("次のシーンにいくまでの間隔時間")]
    [SerializeField] float invokeTime = 0.2f;

    /// <summary>
    ///  ボタンオブジェクト取得
    /// </summary>
    [Tooltip("左側のボタン")]
    [SerializeField] Button leftButton;

    /// <summary>
    ///  ボタンオブジェクト取得
    /// </summary>
    [Tooltip("右側のボタン")]
    [SerializeField] Button rightButton;

    /// <summary>
    /// AudioSource取得
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  どのボタン選んでるかを判定
    /// </summary>
    int select;

    /// <summary>
    ///  スティックで数値取得した値を入れる
    /// </summary>
    float axis;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // AudioSource取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 左スティックの数値取得
        axis = Input.GetAxis("Horizontal");

        // 矢印キー入力またはaxisの値
        if (Input.GetKeyDown(KeyCode.RightArrow) || axis > 0)
        {
            select++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || axis < 0)
        {
            select--;
        }

        // 0か1に値を制限する
        select = Math.Clamp(select, 0, 1);

        // Aボタンまたはスペースキー入力
        bool is_press = (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space));

        switch (select)
        {
            //　左ボタンを選択するとき
            case 0:
                leftButton.Select();
                // 決定ボタンを押したときのシーンの名前がMenuだったら
                if (is_press　&& SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickMainBotton), invokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickTitleBotton), invokeTime);
                }
                break;
            // 右ボタン選択するとき
            case 1:
                rightButton.Select();
                // 決定ボタンを押したときのシーンの名前がMenuだったら
                if (is_press && SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickRuleBotton), invokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickExitBotton), invokeTime);
                }
                break;
        }
    }
    void onClickRuleBotton()
    {
        //ルール画面に行く
        SceneManager.LoadScene("Rule");
    }
    void onClickMainBotton()
    {
        //メイン画面に行く
        SceneManager.LoadScene("Main");
    }
    void onClickTitleBotton()
    {
        //タイトル画面に行く
        SceneManager.LoadScene("Title");
    }
    void onClickExitBotton()
    {
        //ゲーム終了
        Application.Quit();
    }
    #endregion ---Methods---
}