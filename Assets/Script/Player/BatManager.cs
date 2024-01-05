using UnityEngine;

public class BatManager : MonoBehaviour
{
    /// <summary>
    ///  hit音取得
    /// </summary>
    [SerializeField] AudioClip hit;

    /// <summary>
    ///  AudioSource取得
    /// </summary>
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Kon":
                audioSource.PlayOneShot(hit);
                break;
        }
    }
}