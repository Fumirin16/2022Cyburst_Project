using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class E_Bomb_Count : MonoBehaviour
{
   // public TextMeshProUGUI TimeText; デバック用

    public float total_Time;
    int seconds;
    public bool bomb_judge = false;

    //インスタンスがエラー出ないようにする定型文----
    public static E_Bomb_Count instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //----------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //デバック用
        //  TimeText = GameObject.Find("Timer_debug").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb_judge==false)
        {
            if (total_Time > 1.0f)//カウントが1以上
            {
                total_Time -= Time.deltaTime;
                seconds = (int)total_Time;
               // TimeText.text = "Timer :" + seconds;
            }
            else//カウントが0.9以下になったとき
            {
                //bomb_judge = true;
                //Debug.Log("true");
            }
        }
    }
}
