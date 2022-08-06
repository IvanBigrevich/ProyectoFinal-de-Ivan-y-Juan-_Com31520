using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
    //Variables//

    public static float playerLife = 20f;
    public static float playerStamina = 100f;
    public float speed = 10f;
    public float speedRotation = 200f;
    private float MovHorizontal;
    private float MovVertical;
    public Animator animator;
    public Vector3 posInicial;

    private void Start()
    {
        posInicial = transform.position;
        Debug.Log("Tu salud es de " + playerLife);
    }

    void Update()
    {
        MoveSpeed();
        Respawn();
    }
    void MoveSpeed()
    {
        MovHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, 0, MovVertical) * speed * Time.deltaTime);
        MovVertical = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0, MovHorizontal, 0) * speedRotation * Time.deltaTime);

        if (MovVertical != 0)
        {
            animator.SetBool("isRun", true);

        }
        else
        {
            animator.SetBool("isRun", false);
        }

    }

    void Respawn()
    {
        if (playerLife <= 0)
        {   
            transform.position = posInicial;
            playerLife = 100f;
        }
    }

} 