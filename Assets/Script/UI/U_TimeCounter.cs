using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class U_TimeCounter : MonoBehaviour
{
    #region ---Fields---

    /// <summary>
    ///  ��
    /// </summary>
    [SerializeField] int minute; 

    /// <summary>
    ///  �b
    /// </summary>
    [SerializeField] float seconds;

    /// <summary>
    /// ���Ԃ�\������Text�^�̕ϐ�
    /// </summary>
    [SerializeField] TextMeshProUGUI timeText; 

    /// <summary>
    /// �N���A�p�l���擾
    /// </summary>
    [SerializeField] GameObject clear;

    /// <summary>
    /// �N���A�p�l���擾
    /// </summary>
    [SerializeField] GameObject barriar;

    /// <summary>
    /// �N���A�p�l���擾
    /// </summary>
    [SerializeField] GameObject laser;

    /// <summary>
    ///  ���E�ړ��X�s�[�h�̕ϐ�
    /// </summary>
    static float leftTime;

    #endregion ---Fields---

    #region ---Methods---

    void Start()
    {
        leftTime = minute * 60 + seconds;
        clear.SetActive(false);
    }

    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        leftTime -= Time.deltaTime;

        minute = (int)leftTime / 60;
        seconds = leftTime - minute * 60;

        //���Ԃ�\������
        timeText.text = minute.ToString("00") + "." + seconds.ToString("f2");

        if(IsTimeOver())
        {
            timeText.text = "";
            clear.SetActive(true);
            barriar.SetActive(false);
            laser.SetActive(false);
            Invoke(nameof(GoClear), 5);
        }
    }

    /// <summary>
    ///  ���ԃI�[�o�[
    /// </summary>
    public static bool IsTimeOver()
    {
        return leftTime <= 0f;
    }

    /// <summary>
    ///  Text�擾
    /// </summary>
    void GoClear()
    {
        SceneManager.LoadScene("Clear");
    }
    #endregion ---Methods---
}