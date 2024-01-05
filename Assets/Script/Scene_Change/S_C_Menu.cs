//Menuに移動。スペースキー押したら音が流れて次のシーンに行く
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_C_Menu : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// スタート時のSE
    /// </summary>
    [Tooltip("スタート時のSE")]
    [SerializeField] AudioClip startSE;

    /// <summary>
    /// FrameAnimator取得
    /// </summary>
    [Tooltip("Frameアニメーション")]
    [SerializeField] Animator frame;

    /// <summary>
    /// AudioSource取得
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// 入力は一度だけさせるbool値
    /// </summary>
    bool audioMode = true;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Aボタンまたはスペースキーを押したかつaudioModeがtrueだったら
        if(Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) && audioMode)
        {
            // SE流す
            audioSource.PlayOneShot(startSE);
            // アニメーション流す（点滅が速くなったやつ）
            frame.Play("Frame");
            // GoMenuにいくまで2秒待つ
            Invoke(nameof(GoMenu), 2.0f);
            // audioModeをfalseにして2回目の処理をさせない
            audioMode = false;
        }
    }

    /// <summary>
    ///  Menuシーンに遷移する関数
    /// </summary>
    void GoMenu()
    {
        //Menuシーンに移行
        SceneManager.LoadScene("Menu");
    }
    #endregion ---Methods---
}