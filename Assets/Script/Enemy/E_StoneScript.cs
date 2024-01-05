//作成者地引翼
//Stoneのスクリプト
//StoneがBatに当たったらDroneに動く
//enemyのターゲット選択
using UnityEngine;

public class E_StoneScript : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  ターゲットオブジェクト取得
    /// </summary>
    [SerializeField] GameObject[] targetObject = new GameObject[targetNumber];

    /// <summary>
    ///  ターゲットイメージ取得
    /// </summary>
    [SerializeField] GameObject[] targetImage = new GameObject[targetNumber];

    /// <summary>
    ///  バリアオブジェクト取得
    /// </summary>
    [SerializeField] GameObject barriar;

    /// <summary>
    ///  弾く音取得
    /// </summary>
    //[SerializeField] AudioClip bounceSE;

    /// <summary>
    ///  hit音取得
    /// </summary>
    //[SerializeField] AudioClip hitSE;

    /// <summary>
    ///  コーンに向かっていく力
    /// </summary>
    [SerializeField] float power = 90f;

    /// <summary>
    ///  バリアに弾く力
    /// </summary>
    [SerializeField] Vector3 bounce;

    /// <summary>
    ///  バリア敵のレンダラー取得
    /// </summary>
    [SerializeField] Renderer enemyRenderer1;

    /// <summary>
    ///  バリア敵のレンダラー取得
    /// </summary>
    [SerializeField] Renderer enemyRenderer2;

    /// <summary>
    ///  ターゲットオブジェクト格納
    /// </summary>
    GameObject target;

    /// <summary>
    ///  リジットボディ格納
    /// </summary>
    Rigidbody rb;

    /// <summary>
    ///  コーンレンダラー取得
    /// </summary>
    Renderer KonRenderer;

    /// <summary>
    ///  enemyを選んでる値取得
    /// </summary>
    int enemySelect;

    /// <summary>
    ///  コーンに当たったか判定bool値
    /// </summary>
    bool stoneHit = false;

    /// <summary>
    ///  ターゲット数取得
    /// </summary>
    static readonly int targetNumber = 5;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        KonRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        barriar.SetActive(false);

        // RBボタンまたは右矢印キー
        if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            enemySelect++;
        }
        // LBボタンまたは左矢印キー
        if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            enemySelect--;
        }

        enemySelect = (enemySelect + targetNumber) % targetNumber;
        target = targetObject[enemySelect];

        //targetUIの表示非表示
        for (int i = 0; i < targetNumber; i++)
        {
            targetImage[i].SetActive(i == enemySelect);
        }

        //バリア敵が見えたらバリア表示
        if(enemyRenderer1.isVisible || enemyRenderer2.isVisible)
        {
            barriar.SetActive(true);
        }

        if (KonRenderer.isVisible)
        {
            if (stoneHit == true && target.activeSelf == true)
            {
                transform.LookAt(target.transform);
                rb.velocity = transform.forward.normalized * power;
            }
        }
        else if(transform.position.z < -5)
        {
            //自分より後ろにいったら削除
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bat":
                //Debug.Log("hit");
                stoneHit = true;
                //AudioSource.PlayClipAtPoint(hitSE, transform.position);
                break;

            case "Enemy":
                stoneHit = false;
                if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
                {
                    //AudioSource.PlayClipAtPoint(bounceSE, transform.position);
                    ////バリアがあったら跳ね返る
                    rb.AddForce(bounce, ForceMode.Impulse);
                }
                break;
        }
    }
    #endregion ---Methods---
}