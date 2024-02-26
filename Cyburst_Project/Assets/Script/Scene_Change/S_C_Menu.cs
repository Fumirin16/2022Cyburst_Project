//Menu�Ɉړ��B�X�y�[�X�L�[�������特������Ď��̃V�[���ɍs��
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_C_Menu : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    /// �X�^�[�g����SE
    /// </summary>
    [Tooltip("�X�^�[�g����SE")]
    [SerializeField] AudioClip startSE;

    /// <summary>
    /// FrameAnimator�擾
    /// </summary>
    [Tooltip("Frame�A�j���[�V����")]
    [SerializeField] Animator frame;

    /// <summary>
    /// AudioSource�擾
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    /// ���͈͂�x����������bool�l
    /// </summary>
    bool audioMode = true;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // A�{�^���܂��̓X�y�[�X�L�[������������audioMode��true��������
        if(Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space) && audioMode)
        {
            // SE����
            audioSource.PlayOneShot(startSE);
            // �A�j���[�V���������i�_�ł������Ȃ�����j
            frame.Play("Frame");
            // GoMenu�ɂ����܂�2�b�҂�
            Invoke(nameof(GoMenu), 2.0f);
            // audioMode��false�ɂ���2��ڂ̏����������Ȃ�
            audioMode = false;
        }
    }

    /// <summary>
    ///  Menu�V�[���ɑJ�ڂ���֐�
    /// </summary>
    void GoMenu()
    {
        //Menu�V�[���Ɉڍs
        SceneManager.LoadScene("Menu");
    }
    #endregion ---Methods---
}