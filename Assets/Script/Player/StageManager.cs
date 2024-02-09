//�쐬�Ғn����
//�X�e�[�W�𓮂����i�X�N���[���j
//goal�n�_�ɂ�����~�܂�
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// �X�e�[�W�̃X�s�[�h���擾
    /// </summary>
    [Tooltip("�X�e�[�W���ړ�����X�s�[�h")]
    [SerializeField] float speed; //speed m/s

    /// <summary>
    /// �X�e�[�W�̃I�u�W�F�N�g�擾
    /// </summary>
    [Tooltip("�X�e�[�W�I�u�W�F�N�g")]
    [SerializeField] GameObject obstacle; //speed m/s

    /// <summary>
    /// �X�e�[�W�𓮂���bool�l
    /// </summary>
    bool key = true;

    #endregion ---Fields---

    #region ---Methods---

    void Update()
    {
        // �X�e�[�W�ړ�
        if (key == true)
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }

        // �S�[���n�_�ɂ�������~�܂�
        if (U_TimeCounter.IsTimeOver())
        {
            key = false;
            obstacle.SetActive(false);
        }
    }
    #endregion ---Methods---
}