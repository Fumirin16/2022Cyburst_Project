//作成者地引翼
//バリア敵の挙動
using UnityEngine;

public class BE_Maneger : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  playerの位置取得
    /// </summary>
    [Tooltip("Playerオブジェクト")]
    [SerializeField] Transform player_pos;

    /// <summary>
    ///  エフェクトオブジェクト取得
    /// </summary>
    [Tooltip("爆発エフェクト")]
    [SerializeField] GameObject particleObject;

    /// <summary>
    ///  Enemy表示のインターバル
    /// </summary>
    [Tooltip("スポーンの間隔時間")]
    [SerializeField] float interval;

    /// <summary>
    ///  浮遊する変数0～1の範囲で敵ごとに変える
    /// </summary>
    [Tooltip("浮遊する数字")]
    [SerializeField] float floating = 0.1f;

    /// <summary>
    ///  X座標
    /// </summary>
    [Tooltip("X座標")]
    [SerializeField] float x;

    /// <summary>
    ///  Y座標
    /// </summary>
    [Tooltip("Y座標")]
    [SerializeField] float pos_y;

    /// <summary>
    ///  爆発音
    /// </summary>
    [Tooltip("爆発音")]
    [SerializeField] AudioClip explosionSE;

    /// <summary>
    ///  UI＿Scoreの参照変数
    /// </summary>
    U_Score us;

    /// <summary>
    ///  AudioSource取得
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  playerのZ位置
    /// </summary>
    float pz;

    /// <summary>
    ///  経過時間取得
    /// </summary>
    float time;

    /// <summary>
    ///  Scoreの変数
    /// </summary>
    int scoreValue = 100;

    /// <summary>
    ///  浮遊するときのY座標
    /// </summary>
    float y;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        us = GameObject.Find("S_manage").GetComponent<U_Score>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //enemyを縦に浮遊させる
        time += Time.deltaTime;
        y = 0.5f * Mathf.PerlinNoise(time, floating);

        //プレイヤーのｚポジを取得
        //pz = GameObject.Find("player").transform.position.z;

        //敵の位置
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //敵が上から出現
        transform.position = Vector3.MoveTowards(transform.position, targetposition, 0.1f);

        //playerにターゲットを向かせる
        transform.LookAt(player_pos);

        //ゴールにいったらドローン非表示
        if (U_TimeCounter.IsTimeOver())
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            //オーディオを再生
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
            //Scoreの追加
            us.AddScore(scoreValue);
            //コーンの消去
            Destroy(other.gameObject);
            //エフェクトの生成
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //ドローンの非表示
            gameObject.SetActive(false);
            //○秒後にドローンを表示する
            Invoke(nameof(SpawnInterval), interval);
        }
    }

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    void SpawnInterval()
    {
        //敵の表示
        gameObject.SetActive(true);
        //スポーン位置から移動
        this.transform.position = new Vector3(x, 7f + y, 10);
    }
    #endregion ---Methods---
}