using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bomb_Area : MonoBehaviour
{
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Bombs_Area;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)//すり抜け中ずっと呼ばれる
    {
        if (other.tag == "Player")
        {
            Debug.Log("In!");
            if(E_Bomb_Count.instance.bomb_judge)//カウントがゼロならば
            {
                //U_Life.instance.life_count--;

                  Destroy(Bomb);
                  Destroy(Bombs_Area);
            }


        }
    }

    //void OnTriggerExit(Collider other)//範囲内から出た時
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Out!");
    //    }
    //}

}
