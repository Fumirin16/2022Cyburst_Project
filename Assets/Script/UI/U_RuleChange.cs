using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class U_RuleChange : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// 決定音
    /// </summary>
    [Tooltip("決定音")]
    [SerializeField] AudioClip clickSE;

    /// <summary>
    /// 表示したい画像
    /// </summary>
    [Tooltip("ページ")]
    [SerializeField] Sprite[] m_Sprite;

    /// <summary>
    /// 表示させる画像取得
    /// </summary>
    Image m_Image;

    /// <summary>
    /// AudioSource取得
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// AudioSource取得
    /// </summary>
    int pushKey;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // コンポーネント取得
        m_Image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        int last = pushKey;

        // Bボタンまたは右矢印キー入力
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            pushKey++;
        }
        // Xボタンまたは左矢印キー入力
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            pushKey--;
        }

        // 0～3で制限
        pushKey = Math.Clamp(pushKey, 0, 3);

        // pshkeyがlastと違ったら画像変える
        if (pushKey != last)
        {
            m_Image.sprite = m_Sprite[pushKey];
        }
        if (pushKey == 3)
        {
            // AボタンまたはSpaceキーを入力
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(clickSE);
                Invoke(nameof(GoMenu), 0.2f);
            }
        }
    }

    /// <summary>
    /// Menuシーンに遷移する関数
    /// </summary>
    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion ---Methods---
}