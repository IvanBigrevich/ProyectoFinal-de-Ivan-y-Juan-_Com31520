using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
  
    public void Exit()
    {
        Application.Quit();
    }
}
