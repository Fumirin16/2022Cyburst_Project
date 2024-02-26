using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Laser : MonoBehaviour
{
    private float time;
    Rigidbody rb;
    public GameObject player;
    Vector3 mass;
    // public float acc;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("attack", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //var force = acc * E_attack.instance.dir;
        //rb.AddForce(force, ForceMode.Acceleration);
        //rb.AddForce(force);
        //Destroy(gameObject, 10f);
    }

    void attack()
    {
        mass = E_attack.instance.dir;
        rb.AddForce(mass, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)//コライダー　他
    {
        if (other.gameObject.tag == "Player")//衝突したらそれはプレイヤーか判定
        {
            U_Life.instance.life_count--;//ライフ減らす
            Debug.Log("敵攻撃：当たった");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "shot")
        {
            Destroy(gameObject);//地面に触ったら
        }
    }
}
