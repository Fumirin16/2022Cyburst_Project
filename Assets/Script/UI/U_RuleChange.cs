using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class U_RuleChange : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// ���艹
    /// </summary>
    [Tooltip("���艹")]
    [SerializeField] AudioClip clickSE;

    /// <summary>
    /// �\���������摜
    /// </summary>
    [Tooltip("�y�[�W")]
    [SerializeField] Sprite[] m_Sprite;

    /// <summary>
    /// �\��������摜�擾
    /// </summary>
    Image m_Image;

    /// <summary>
    /// AudioSource�擾
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// AudioSource�擾
    /// </summary>
    int pushKey;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // �R���|�[�l���g�擾
        m_Image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        int last = pushKey;

        // B�{�^���܂��͉E���L�[����
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            pushKey++;
        }
        // X�{�^���܂��͍����L�[����
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            pushKey--;
        }

        // 0�`3�Ő���
        pushKey = Math.Clamp(pushKey, 0, 3);

        // pshkey��last�ƈ������摜�ς���
        if (pushKey != last)
        {
            m_Image.sprite = m_Sprite[pushKey];
        }
        if (pushKey == 3)
        {
            // A�{�^���܂���Space�L�[�����
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(clickSE);
                Invoke(nameof(GoMenu), 0.2f);
            }
        }
    }

    /// <summary>
    /// Menu�V�[���ɑJ�ڂ���֐�
    /// </summary>
    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion ---Methods---
}