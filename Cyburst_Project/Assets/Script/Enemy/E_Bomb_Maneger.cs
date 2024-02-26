using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bomb_Maneger : MonoBehaviour
{
    [SerializeField] GameObject Bombs_Respawn;
    public GameObject Bombs;
    GameObject Bombs_Clone;
    Vector3 B_position;

 //   bool a;

    // Start is called before the first frame update
    void Start()
    {
        B_position = Bombs_Respawn.transform.position;

        //StartCoroutine("CubeCount");

        Bombs_Clone = Instantiate(Bombs, B_position, Quaternion.identity);
        Bombs_Clone.name = "bomb_Clone";
       // Destroy(Bombs_Clone, 2);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
