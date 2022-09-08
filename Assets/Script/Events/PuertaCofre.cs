using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCofre : MonoBehaviour
{
    public GameObject espada;
    public GameObject cofreArma;
    [SerializeField] public GameObject puertaAbierta; 
    [SerializeField] public GameObject puertaCerrada;
            
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
            Destroy(cofreArma);
            espada.SetActive(true);
            ActivarPuerta();
        }
    }

    public void ActivarPuerta()
    {
        puertaAbierta.SetActive(true);
        puertaCerrada.SetActive(false);
    }
}