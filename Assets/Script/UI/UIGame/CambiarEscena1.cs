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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Escalera 1")
        {
            SceneManager.LoadScene(2);
        }
        
        if(collision.transform.tag == "Escalera 2")
        {
            SceneManager.LoadScene(3);
        }

       if(collision.transform.tag == "Escalera 3")
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
