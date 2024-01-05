using UnityEngine;

public class BatManager : MonoBehaviour
{
    /// <summary>
    ///  hit‰¹Žæ“¾
    /// </summary>
    [SerializeField] AudioClip hit;

    /// <summary>
    ///  AudioSourceŽæ“¾
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