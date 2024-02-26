using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_attack : MonoBehaviour
{
    private float rayLength;
    public static E_attack instance;
    public GameObject shot;
    [SerializeField] GameObject shot_pos;
    [SerializeField] Transform E_shot;
    [SerializeField] Transform player_pos;
    public Vector3 dir;
    Ray ray;

    public float start_time;
    public float count_time;

    //--------------------------------
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //--------------------------------
    // Start is called before the first frame update
    void Start()
    {
        rayLength = 7.0f;

        InvokeRepeating("Shot", start_time, count_time);//6ïbÇΩÇ¡ÇΩÇÁ10ïbÇ≤Ç∆
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        dir = ray.direction;
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

        this.transform.LookAt(player_pos.transform);//èÌÇ…ÉvÉåÉCÉÑÅ[Çå¸Ç≠
    }

    void Shot()
    {
        // Debug.Log(dir);
        Instantiate(shot, shot_pos.transform.position, Quaternion.identity, E_shot);
        // shot.transform.position = ;
    }
}
