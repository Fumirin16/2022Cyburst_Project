//作成者地引翼
//プレイ画面（ビルドしたやつ）でBACKボタンかEscキー押したら終わる
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    void Update()
    {
        // BACKボタンかエスケープキー押したら終了
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}