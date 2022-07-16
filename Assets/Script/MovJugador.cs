using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
        public float speed = 5f;
        public float speedRotation = 50f;
        private float MovHorizontal;
        private float MovVertical;
        public Animator animator;

        private void Start()
        {
        }

        void Update()
        {
            MoveSpeed();

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
    }  