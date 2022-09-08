using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}