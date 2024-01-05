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
    ///  �o���A�ɒe����
    /// </summary>
    [Tooltip("")]
    [SerializeField] float interval;//Enemy�\���̃C���^�[�o��

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] float floating = 0.1f; //���V����ϐ�0�`1�͈̔͂œG���Ƃɕς���

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] float x; //�G�̂����W�@-5,-3,0,3,5

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] float pos_y;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] AudioClip explosionSE;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] Renderer enemyRenderer1;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] Renderer enemyRenderer2;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] Vector3 bounce;

    /// <summary>
    ///  �e�����擾
    /// </summary>
    [SerializeField] AudioClip bounceSE;

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    AudioSource audioSource;

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    U_Score us;//UI�QScore

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    float pz;//player��Z�ʒu

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    float time;

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    float y;

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    int scoreValue = 100;//Score�̕ϐ�

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