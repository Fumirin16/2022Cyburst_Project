//�쐬�Ғn����
//�G��Stone�����������������i�G�ƃ{�[�����j
//�G�����̋����ۂ�
//�|������P�O�O�_
//player�Ƀ^�[�Q�b�g����������
using UnityEngine;

public class E_Maneger : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  player�̈ʒu�擾
    /// </summary>
    [Tooltip("Player�I�u�W�F�N�g")]
    [SerializeField] Transform player_pos;

    /// <summary>
    ///  �G�t�F�N�g�I�u�W�F�N�g�擾
    /// </summary>
    [Tooltip("�����G�t�F�N�g")]
    [SerializeField] GameObject particleObject;

    /// <summary>
    ///  Enemy�\���̃C���^�[�o��
    /// </summary>
    [Tooltip("�X�|�[���̊Ԋu����")]
    [SerializeField] float interval;

    /// <summary>
    ///  ���V����ϐ�0�`1�͈̔͂œG���Ƃɕς���
    /// </summary>
    [Tooltip("���V���鐔��")]
    [SerializeField] float floating = 0.1f;

    /// <summary>
    ///  X���W
    /// </summary>
    [Tooltip("X���W")]
    [SerializeField] float x;

    /// <summary>
    ///  Y���W
    /// </summary>
    [Tooltip("Y���W")]
    [SerializeField] float pos_y;

    /// <summary>
    ///  ������
    /// </summary>
    [Tooltip("������")]
    [SerializeField] AudioClip explosionSE;

    /// <summary>
    ///  �o���A�G�����_���[�擾
    /// </summary>
    [Tooltip("�o���A�G�I�u�W�F�N�g�A�^�b�`")]
    [SerializeField] Renderer enemyRenderer1;

    /// <summary>
    ///  �o���A�G�����_���[�擾
    /// </summary>
    [Tooltip("�o���A�G�I�u�W�F�N�g�A�^�b�`")]
    [SerializeField] Renderer enemyRenderer2;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [Tooltip("�o���A����e���Ƃ��̗�")]
    [SerializeField] Vector3 bounce;

    /// <summary>
    ///  �e�����擾
    /// </summary>
    [Tooltip("�o���A�e����")]
    [SerializeField] AudioClip bounceSE;

    /// <summary>
    ///  AudioSource�擾
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  UI�QScore�̎Q�ƕϐ�
    /// </summary>
    U_Score us;

    /// <summary>
    ///  player��Z�ʒu
    /// </summary>
    float pz;

    /// <summary>
    ///  �o�ߎ��Ԏ擾
    /// </summary>
    float time;

    /// <summary>
    ///  Score�̕ϐ�
    /// </summary>
    int scoreValue = 100;

    /// <summary>
    ///  ���V����Ƃ���Y���W
    /// </summary>
    float y;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        us = GameObject.Find("S_manage").GetComponent<U_Score>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //enemy���c�ɕ��V������
        time += Time.deltaTime;
        y = 0.5f * Mathf.PerlinNoise(time, floating);

        //�G�̈ʒu
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //�G���ォ��o��
        transform.position = Vector3.MoveTowards(transform.position,targetposition, 0.1f);

        //player�Ƀ^�[�Q�b�g����������
        transform.LookAt(player_pos);

        //�S�[���ɂ�������h���[����\��
        if (U_TimeCounter.IsTimeOver())
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
            {
                audioSource.PlayOneShot(bounceSE);
                return;
            }

            //�I�[�f�B�I���Đ�
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
            //Score�̒ǉ�
            us.AddScore(scoreValue);
            //�R�[���̏���
            Destroy(other.gameObject);
            //�G�t�F�N�g�̐���
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //�h���[���̔�\��
            gameObject.SetActive(false);
            //���b��Ƀh���[����\������
            Invoke(nameof(SpawnInterval), interval);
        }
    }

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    void SpawnInterval()
    {
        //�G�̕\��
        gameObject.SetActive(true);
        //�X�|�[���ʒu����ړ�
        this.transform.position = new Vector3(x, 7f + y, 10);
    }
    #endregion ---Methods---
}