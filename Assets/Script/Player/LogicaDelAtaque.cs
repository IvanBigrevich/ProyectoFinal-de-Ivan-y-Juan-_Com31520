﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDelAtaque : MonoBehaviour
{
    public Animator jugadorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            jugadorAnim.SetBool("Ataque", true);

        }else
        {
            jugadorAnim.SetBool("Ataque", false);
        }
    }

    public void Ataca()
    {

    }

    public void DejaDeAtacar()
    {
        
    }
}