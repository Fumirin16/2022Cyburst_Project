using UnityEngine;

public class BatManager : MonoBehaviour
{
    /// <summary>
    ///  hit���擾
    /// </summary>
    [SerializeField] AudioClip hit;

    /// <summary>
    ///  AudioSource�擾
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