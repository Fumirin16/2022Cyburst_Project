// オブジェクト表示
using UnityEngine;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] GameObject button;

    public void SlideAnim()
    {
        button.SetActive(true);
    }
}
