using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour
{
    [SerializeField] public int vidaJugador = 100;

    // Update is called once per frame
    void Update()
    {
        if(vidaJugador <= 0)
        {
            Debug.Log("estas muerto");
        }
    }
}
