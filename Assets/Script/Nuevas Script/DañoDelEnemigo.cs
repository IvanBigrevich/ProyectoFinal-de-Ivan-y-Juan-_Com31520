using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDelEnemigo : MonoBehaviour
{
    [SerializeField] private int dañoAlJugador = 25;
    [SerializeField] private GameObject Jugador;

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Jugador.GetComponent<DatosJugador>().vidaJugador -= dañoAlJugador;
        }
    }
}
