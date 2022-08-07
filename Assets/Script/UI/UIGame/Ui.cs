using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui : MonoBehaviour
{
    public Image barraVida;
    public Image barraStamina;
    public float vidaMaxima = 100f;
    public float staminaMaxima = 100f;
    private bool pauseActive;
    public GameObject pauseMenu;
    public GameObject mensajeIncial;


    // Start is called before the first frame update
    void Start()
    {
        BarraStamina();
        BarraSalud();
    }

    // Update is called once per frame
    void Update()
    {
        TogglePause();
    }

    void BarraSalud()
    {

        barraVida.fillAmount = MovJugador.playerLife / vidaMaxima;


    }
    void BarraStamina()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MovJugador.playerStamina--;
            barraStamina.fillAmount = MovJugador.playerStamina / staminaMaxima;
        }
        else
        {
            MovJugador.playerStamina++;
            barraStamina.fillAmount = MovJugador.playerStamina / staminaMaxima;
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

    void ToggleWeapons()
    {

    }
}

