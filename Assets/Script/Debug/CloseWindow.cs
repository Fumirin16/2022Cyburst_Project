//�쐬�Ғn����
//�v���C��ʁi�r���h������j��BACK�{�^����Esc�L�[��������I���
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    void Update()
    {
        // BACK�{�^�����G�X�P�[�v�L�[��������I��
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}