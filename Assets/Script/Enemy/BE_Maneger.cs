//�쐬�Ғn����
//�o���A�G�̋���
using UnityEngine;

public class BE_Maneger : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] Transform player_pos;//player�̈ʒu

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] GameObject particleObject;//effect�̃I�u�W�F�N�g

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
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
    U_Score us;//UI�QScore

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    AudioSource audioSource;//UI�QScore

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    float pz;//player��Z�ʒu

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    float time;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    int scoreValue = 100;//Score�̕ϐ�

    /// <summary>
    ///  �o���A�ɒe����
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

        //�v���C���[�̂��|�W���擾
        //pz = GameObject.Find("player").transform.position.z;

        //�G�̈ʒu
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //�G���ォ��o��
        transform.position = Vector3.MoveTowards(transform.position, targetposition, 0.1f);

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
    ///  �o���A�ɒe����
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