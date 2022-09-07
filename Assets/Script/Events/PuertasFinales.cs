using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasFinales : MonoBehaviour
{

 
    [SerializeField] public GameObject puertaAbierta; 
    [SerializeField] public GameObject puertaCerrada;
    [SerializeField] public float vida;

        
    void Start()
    {
       
    }   
    void Update() 
    {
        vida = EnemigoFinal.vidaFinal;
        MuerteEnemigo();
    }

    public void MuerteEnemigo()
    {
        if (vida <= 0)  
        {
            ActivarPuerta();
        }
    }

    public void ActivarPuerta()
    {
        puertaAbierta.SetActive(true);
        puertaCerrada.SetActive(false);
    }

}