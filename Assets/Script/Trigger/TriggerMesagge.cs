using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TriggerMesagge : MonoBehaviour
{
    public GameObject mensaje;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                mensaje.SetActive(true);
                Destroy(gameObject);
                Destroy(mensaje, 5f);
                
            }
    }
}

