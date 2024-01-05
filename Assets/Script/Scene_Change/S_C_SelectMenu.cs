//Menu����Main�ARule�V�[���Ɉړ�
//button�I��
//�쐬�Ғn����
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class S_C_SelectMenu : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  ���艹�������ϐ�
    /// </summary>
    [Tooltip("���艹")]
    [SerializeField] AudioClip clickSE;

    /// <summary>
    ///  ���̃V�[���ɂ����܂ł̊Ԋu����
    /// </summary>
    [Tooltip("���̃V�[���ɂ����܂ł̊Ԋu����")]
    [SerializeField] float invokeTime = 0.2f;

    /// <summary>
    ///  �{�^���I�u�W�F�N�g�擾
    /// </summary>
    [Tooltip("�����̃{�^��")]
    [SerializeField] Button leftButton;

    /// <summary>
    ///  �{�^���I�u�W�F�N�g�擾
    /// </summary>
    [Tooltip("�E���̃{�^��")]
    [SerializeField] Button rightButton;

    /// <summary>
    /// AudioSource�擾
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  �ǂ̃{�^���I��ł邩�𔻒�
    /// </summary>
    int select;

    /// <summary>
    ///  �X�e�B�b�N�Ő��l�擾�����l������
    /// </summary>
    float axis;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // AudioSource�擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ���X�e�B�b�N�̐��l�擾
        axis = Input.GetAxis("Horizontal");

        // ���L�[���͂܂���axis�̒l
        if (Input.GetKeyDown(KeyCode.RightArrow) || axis > 0)
        {
            select++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || axis < 0)
        {
            select--;
        }

        // 0��1�ɒl�𐧌�����
        select = Math.Clamp(select, 0, 1);

        // A�{�^���܂��̓X�y�[�X�L�[����
        bool is_press = (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space));

        switch (select)
        {
            //�@���{�^����I������Ƃ�
            case 0:
                leftButton.Select();
                // ����{�^�����������Ƃ��̃V�[���̖��O��Menu��������
                if (is_press�@&& SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickMainBotton), invokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickTitleBotton), invokeTime);
                }
                break;
            // �E�{�^���I������Ƃ�
            case 1:
                rightButton.Select();
                // ����{�^�����������Ƃ��̃V�[���̖��O��Menu��������
                if (is_press && SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickRuleBotton), invokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(clickSE);
                    Invoke(nameof(onClickExitBotton), invokeTime);
                }
                break;
        }
    }
    void onClickRuleBotton()
    {
        //���[����ʂɍs��
        SceneManager.LoadScene("Rule");
    }
    void onClickMainBotton()
    {
        //���C����ʂɍs��
        SceneManager.LoadScene("Main");
    }
    void onClickTitleBotton()
    {
        //�^�C�g����ʂɍs��
        SceneManager.LoadScene("Title");
    }
    void onClickExitBotton()
    {
        //�Q�[���I��
        Application.Quit();
    }
    #endregion ---Methods---
}