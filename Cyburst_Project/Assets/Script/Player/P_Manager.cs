//プレイヤーが左右移動
//プレイヤーが走る打つアニメーション
using UnityEngine;

public class P_Manager : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  左右移動スピードの変数
    /// </summary>
    [Tooltip("横のスピード。少数で")]
    [SerializeField] float h_speed = 7.0f;

    /// <summary>
    ///  フェンスに当たったのSEを格納
    /// </summary>
    [Tooltip("フェンスの当たった時のSE")]
    [SerializeField] AudioClip biribiriSE;

    /// <summary>
    ///  Animator取得
    /// </summary>
    Animator animator;

    /// <summary>
    ///  CharacterController取得
    /// </summary>
    CharacterController controller;

    /// <summary>
    ///  AudioSource取得
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  プレイヤーの座標取得
    /// </summary>
    Vector3 player_pos;

    /// <summary>
    ///  プレイヤーが左右移動する座標取得
    /// </summary>
    Vector3 direction;

    /// <summary>
    ///  プレイヤーの移動量取得
    /// </summary>
    float moveX;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // コンポーネント取得
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //スティック、(A,D)キーで左右移動する
        moveX = Input.GetAxis("Horizontal") * h_speed;

        //バイクのアニメーション
        animator.SetFloat("turn_Left", (moveX < 0f) ? moveX : 0f);
        animator.SetFloat("turn_Right", (0f < moveX) ? moveX : 0f);

        //プレイヤー左右移動
        direction = new Vector3(moveX, 0, 0);
        controller.SimpleMove(direction);

        //プレイヤーの行動範囲
        player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -5.0f, 5.0f);
        transform.position = player_pos;

        //BボタンまたはLキーで右打ち
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.L )|| Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("toR_Hit");
        }
        //AボタンまたはKキーで左打ち
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("toL_Hit");
        }
        // 時間になったらプレイヤーは前に進む
        if (U_TimeCounter.IsTimeOver())
        {
            transform.position += transform.forward * 0.8f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // フェンスにあたったらライフが減る
        if (other.gameObject.tag == "wall")
        {
            // オーディオを再生
            audioSource.PlayOneShot(biribiriSE);
            // ライフ一つ減る
            U_Life.instance.life_count--;
        }
    }

    /// <summary>
    /// モーション中はほかのモーション入力させない
    /// </summary>
    void OnAnimatorMove()
    {
        animator.ResetTrigger("toR_Hit");
        animator.ResetTrigger("toL_Hit");
    }
    #endregion ---Methods---
}