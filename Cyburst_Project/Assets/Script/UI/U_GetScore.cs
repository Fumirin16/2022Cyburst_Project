//�쐬�Ғn����
//�ŏI�X�R�A�\��
using UnityEngine;
using TMPro;

public class U_GetScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = U_Score.GetScoreText();
    }
}