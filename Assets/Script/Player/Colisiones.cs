using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisionaste con " + collision.transform.name);
        switch (collision.transform.name)
        {
            case "Vida":
                MovJugador.playerLife += 20;
                Debug.Log("Recuperaste Salud");
                Debug.Log("Tu salud es de " + MovJugador.playerLife);

                break;
            case "Arma":
                Debug.Log("Recogiste un Arma, puedas seleccionarla en el inventario");
                break;
            case "Brick":
                Debug.Log("Recogiste un Ladrillo");
                break;
        }
    }

}
