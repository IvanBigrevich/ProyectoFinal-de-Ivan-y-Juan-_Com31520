using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject camUno;
    public GameObject camDos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
    }

    void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }

        void ToggleCamera()
        {
            if (camUno.activeInHierarchy)
            {
                camUno.SetActive(false);
                camDos.SetActive(true);

            }
            else
            {
                camUno.SetActive(true);
                camDos.SetActive(false);
            }
        }

    }
}
