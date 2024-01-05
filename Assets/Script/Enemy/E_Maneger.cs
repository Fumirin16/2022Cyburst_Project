//作成者地引翼
//敵とStoneが当たったら消える（敵とボールが）
//敵が一定の距離保つ
//倒したら１００点
//playerにターゲットを向かせる
using UnityEngine;

public class E_Maneger : MonoBehaviour
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
    ///  バリアに弾く力
    /// </summary>
    [Tooltip("")]
    [SerializeField] float interval;//Enemy表示のインターバル

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] float floating = 0.1f; //浮遊する変数0～1の範囲で敵ごとに変える

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] float x; //敵のｘ座標　-5,-3,0,3,5

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] float pos_y;

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] AudioClip explosionSE;

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] Renderer enemyRenderer1;

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] Renderer enemyRenderer2;

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] Vector3 bounce;

    /// <summary>
    ///  弾く音取得
    /// </summary>
    [SerializeField] AudioClip bounceSE;

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    U_Score us;//UI＿Score

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    float pz;//playerのZ位置

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    float time;

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    float y;

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    int scoreValue = 100;//Scoreの変数

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

        //敵の位置
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //敵が上から出現
        transform.position = Vector3.MoveTowards(transform.position,targetposition, 0.1f);

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
            if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
            {
                audioSource.PlayOneShot(bounceSE);
                return;
            }

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
    ///  リジットボディ格納
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