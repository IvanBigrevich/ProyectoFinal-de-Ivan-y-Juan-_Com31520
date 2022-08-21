using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoNuevo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animacionEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        animacionEnemigo = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        animacionEnemigo.SetBool("EnemigoMuerto", true);
        Destroy(gameObject, 3f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") 

        { 
            animacionEnemigo.SetTrigger("RecibiendoDaño");
            Debug.Log("Hola Trigger");
        }
    }
}
