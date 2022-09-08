using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CambiarEscena1 : MonoBehaviour
{
  private bool pauseActive;
  public GameObject pauseMenu;
  [SerializeField] public GameObject mensajeFinal; 
  
  void Start()
  {
  
  }

  void Update()
  {
    if(Time.timeScale == 0)
    {
      TogglePause();
    }
  }

  private void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "Escalera 1")
    {
      Debug.Log("Estas Colisionando con la Escalera");
      SceneManager.LoadScene(2);
    }
        
    if (col.gameObject.tag == "Escalera 2")
    {
      SceneManager.LoadScene(3);
    }

    if (col.gameObject.tag == "Escalera 3")
    {
      pauseMenu.SetActive(true);
      mensajeFinal.SetActive(true);
      Time.timeScale = 0;
    }
  } 

  void TogglePause()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Time.timeScale = 1;
      SceneManager.LoadScene(0);
    }
  }
}