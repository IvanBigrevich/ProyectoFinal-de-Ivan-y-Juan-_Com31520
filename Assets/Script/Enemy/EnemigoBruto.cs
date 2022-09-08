using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBruto : MonoBehaviour
{ 
   public static float vidaEnemigo = 100;
   public Animator ani;
   public GameObject target;
   float timeToAttack = 2f;
   bool canAttack; 
   public AudioSource sonidoMuerte;
   public AudioClip sonidoMuerteenemigo;
   public AudioClip sonidoChoque;
   public AudioClip sonidoDañoEnemy;
      
    void Start()
    {   
        ani = GetComponent<Animator>();
        target = GameObject.Find("Godwin");
    }

  
    void Update()
    {
        Comportamiento_Enemigo();
        EnemigoMuerto();
    }

    public void Comportamiento_Enemigo()
    {           
            if(Vector3.Distance(transform.position, target.transform.position) > 4 && Vector3.Distance(transform.position, target.transform.position) < 10)
            {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * 8 * Time.deltaTime);
            }
            else if(Vector3.Distance(transform.position, target.transform.position) <= 4)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                CanAttack();
                if(canAttack == true)
                {
                   ani.SetTrigger("attack1");
                   sonidoMuerte.PlayOneShot(sonidoChoque, 1f);
                }
            }
    }
    
    void CanAttack()
        {
            timeToAttack -= Time.deltaTime;
            if(timeToAttack <= 0)
            {
                canAttack = true;
                timeToAttack = 2f;
            }
            else
            {
                canAttack = false;
            }
        }
   
      private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("sword"))
        {
            ani.SetTrigger("recibeGolpe");
            sonidoMuerte.PlayOneShot(sonidoDañoEnemy, 0.5f);
            vidaEnemigo -= 15;
        }
    }

    void EnemigoMuerto()
    {
        if (vidaEnemigo <= 0)
        {
            sonidoMuerte.PlayOneShot(sonidoMuerteenemigo, 0.5f);
            ani.SetBool("enemigoMuerto", true);
            Destroy(gameObject, 2f);
        }
    }
}