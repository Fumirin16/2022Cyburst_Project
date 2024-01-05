//�쐬�Ғn����
//Stone�̃X�N���v�g
//Stone��Bat�ɓ���������Drone�ɓ���
//enemy�̃^�[�Q�b�g�I��
using UnityEngine;

public class E_StoneScript : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  �^�[�Q�b�g�I�u�W�F�N�g�擾
    /// </summary>
    [SerializeField] GameObject[] targetObject = new GameObject[targetNumber];

    /// <summary>
    ///  �^�[�Q�b�g�C���[�W�擾
    /// </summary>
    [SerializeField] GameObject[] targetImage = new GameObject[targetNumber];

    /// <summary>
    ///  �o���A�I�u�W�F�N�g�擾
    /// </summary>
    [SerializeField] GameObject barriar;

    /// <summary>
    ///  �e�����擾
    /// </summary>
    //[SerializeField] AudioClip bounceSE;

    /// <summary>
    ///  hit���擾
    /// </summary>
    //[SerializeField] AudioClip hitSE;

    /// <summary>
    ///  �R�[���Ɍ������Ă�����
    /// </summary>
    [SerializeField] float power = 90f;

    /// <summary>
    ///  �o���A�ɒe����
    /// </summary>
    [SerializeField] Vector3 bounce;

    /// <summary>
    ///  �o���A�G�̃����_���[�擾
    /// </summary>
    [SerializeField] Renderer enemyRenderer1;

    /// <summary>
    ///  �o���A�G�̃����_���[�擾
    /// </summary>
    [SerializeField] Renderer enemyRenderer2;

    /// <summary>
    ///  �^�[�Q�b�g�I�u�W�F�N�g�i�[
    /// </summary>
    GameObject target;

    /// <summary>
    ///  ���W�b�g�{�f�B�i�[
    /// </summary>
    Rigidbody rb;

    /// <summary>
    ///  �R�[�������_���[�擾
    /// </summary>
    Renderer KonRenderer;

    /// <summary>
    ///  enemy��I��ł�l�擾
    /// </summary>
    int enemySelect;

    /// <summary>
    ///  �R�[���ɓ�������������bool�l
    /// </summary>
    bool stoneHit = false;

    /// <summary>
    ///  �^�[�Q�b�g���擾
    /// </summary>
    static readonly int targetNumber = 5;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        KonRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        barriar.SetActive(false);

        // RB�{�^���܂��͉E���L�[
        if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            enemySelect++;
        }
        // LB�{�^���܂��͍����L�[
        if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            enemySelect--;
        }

        enemySelect = (enemySelect + targetNumber) % targetNumber;
        target = targetObject[enemySelect];

        //targetUI�̕\����\��
        for (int i = 0; i < targetNumber; i++)
        {
            targetImage[i].SetActive(i == enemySelect);
        }

        //�o���A�G����������o���A�\��
        if(enemyRenderer1.isVisible || enemyRenderer2.isVisible)
        {
            barriar.SetActive(true);
        }

        if (KonRenderer.isVisible)
        {
            if (stoneHit == true && target.activeSelf == true)
            {
                transform.LookAt(target.transform);
                rb.velocity = transform.forward.normalized * power;
            }
        }
        else if(transform.position.z < -5)
        {
            //���������ɂ�������폜
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bat":
                //Debug.Log("hit");
                stoneHit = true;
                //AudioSource.PlayClipAtPoint(hitSE, transform.position);
                break;

            case "Enemy":
                stoneHit = false;
                if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
                {
                    //AudioSource.PlayClipAtPoint(bounceSE, transform.position);
                    ////�o���A���������璵�˕Ԃ�
                    rb.AddForce(bounce, ForceMode.Impulse);
                }
                break;
        }
    }
    #endregion ---Methods---
}