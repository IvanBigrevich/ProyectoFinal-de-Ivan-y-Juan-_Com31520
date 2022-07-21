using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{   
    public GameObject jugador;
    private float enemySpeedRotation = 50f;
    private Vector3 posJugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        posJugador = jugador.transform.position;
        LookAtPlayer();
    }
    void LookAtPlayer()
    {     
        float distanciaVista = Vector3.Distance(transform.position, posJugador);
        if (distanciaVista <= 5)
        {
            Quaternion rot = Quaternion.LookRotation(posJugador - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, enemySpeedRotation * Time.deltaTime);
            Debug.Log("Te han detectado");
        }
        else if(distanciaVista <=10)
        {
            Debug.Log("Hay enemigos Cerca, debes hacer menos ruido para evitar ser detectado");
        }
    } 
}
