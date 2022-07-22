using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aciertoObjeto : MonoBehaviour
{

    public float range = 50f;
    public Transform spawnPoint;
    public GameObject efecto;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            LanzarObjeto();
        }
    }

    void LanzarObjeto()
    {
        RaycastHit impacto;

        if(Physics.Raycast(spawnPoint.position,spawnPoint.forward,out impacto, range))
        {
            if (impacto.transform.name == "Enemy")
            {
                GameObject copiaImpacto = Instantiate(efecto, impacto.point, Quaternion.LookRotation(impacto.normal));
                Debug.Log("esto");
            }
        }
    }
}


        
    
