using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima = 100f;
    private bool pauseActive;
    public GameObject pauseMenu;
    public GameObject mensajeIncial;
   
    void Start()
    {
        
    }
    
    void Update()
    {
        BarraSalud();
        TogglePause();
    }

    public void BarraSalud()
    {
        vidaActual = NuevoMovientoJugador.playerLife;
        if(Time.timeScale != 0)
        {
           barraVida.fillAmount = vidaActual / vidaMaxima;
        }
    }
 
    void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pauseActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseActive = true;
    }
}