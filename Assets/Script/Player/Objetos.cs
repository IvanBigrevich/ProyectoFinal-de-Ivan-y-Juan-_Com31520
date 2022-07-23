using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    int objetoTocado = 0;
    int moneda = 0;
    int salud = 3; 


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        switch (objetoTocado)
        {
            case 0:
                moneda++;
                Debug.Log("Recolectaste 1 moneda");
                break;
            case 1:
                MovJugador.playerLife += 20;
                Debug.Log("Recuperaste Salud");                  
                break;
        }
    }
}
