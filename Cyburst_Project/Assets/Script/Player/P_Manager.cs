//�v���C���[�����E�ړ�
//�v���C���[������łA�j���[�V����
using UnityEngine;

public class P_Manager : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  ���E�ړ��X�s�[�h�̕ϐ�
    /// </summary>
    [Tooltip("���̃X�s�[�h�B������")]
    [SerializeField] float h_speed = 7.0f;

    /// <summary>
    ///  �t�F���X�ɓ���������SE���i�[
    /// </summary>
    [Tooltip("�t�F���X�̓�����������SE")]
    [SerializeField] AudioClip biribiriSE;

    /// <summary>
    ///  Animator�擾
    /// </summary>
    Animator animator;

    /// <summary>
    ///  CharacterController�擾
    /// </summary>
    CharacterController controller;

    /// <summary>
    ///  AudioSource�擾
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  �v���C���[�̍��W�擾
    /// </summary>
    Vector3 player_pos;

    /// <summary>
    ///  �v���C���[�����E�ړ�������W�擾
    /// </summary>
    Vector3 direction;

    /// <summary>
    ///  �v���C���[�̈ړ��ʎ擾
    /// </summary>
    float moveX;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        // �R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�X�e�B�b�N�A(A,D)�L�[�ō��E�ړ�����
        moveX = Input.GetAxis("Horizontal") * h_speed;

        //�o�C�N�̃A�j���[�V����
        animator.SetFloat("turn_Left", (moveX < 0f) ? moveX : 0f);
        animator.SetFloat("turn_Right", (0f < moveX) ? moveX : 0f);

        //�v���C���[���E�ړ�
        direction = new Vector3(moveX, 0, 0);
        controller.SimpleMove(direction);

        //�v���C���[�̍s���͈�
        player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -5.0f, 5.0f);
        transform.position = player_pos;

        //B�{�^���܂���L�L�[�ŉE�ł�
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.L )|| Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("toR_Hit");
        }
        //A�{�^���܂���K�L�[�ō��ł�
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("toL_Hit");
        }
        // ���ԂɂȂ�����v���C���[�͑O�ɐi��
        if (U_TimeCounter.IsTimeOver())
        {
            transform.position += transform.forward * 0.8f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �t�F���X�ɂ��������烉�C�t������
        if (other.gameObject.tag == "wall")
        {
            // �I�[�f�B�I���Đ�
            audioSource.PlayOneShot(biribiriSE);
            // ���C�t�����
            U_Life.instance.life_count--;
        }
    }

    /// <summary>
    /// ���[�V�������͂ق��̃��[�V�������͂����Ȃ�
    /// </summary>
    void OnAnimatorMove()
    {
        animator.ResetTrigger("toR_Hit");
        animator.ResetTrigger("toL_Hit");
    }
    #endregion ---Methods---
}