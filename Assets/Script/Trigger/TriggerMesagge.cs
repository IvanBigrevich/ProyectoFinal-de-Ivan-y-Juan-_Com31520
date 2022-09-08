using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TriggerMesagge : MonoBehaviour
{
    public GameObject mensaje;

    void Start()
    {

    }

    void Update()
    {

    }
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