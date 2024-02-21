using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSelectUI : MonoBehaviour
{
    [SerializeField] GameObject[] droneObject;

    [SerializeField] GameObject[] droneSelectImage;

    int presentSelectNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // RB�{�^���܂��͉E���L�[
        if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            presentSelectNumber++;
        }
        // LB�{�^���܂��͍����L�[
        if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            presentSelectNumber--;
        }

        presentSelectNumber = (presentSelectNumber + droneObject.Length) % droneObject.Length;

        for (int i = 0; i < droneObject.Length; i++)
        {
            droneSelectImage[i].SetActive(i == presentSelectNumber);
        }


    }
}
