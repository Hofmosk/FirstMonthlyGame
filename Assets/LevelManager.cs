using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    
    void Update()
    {
        
    }
     public void ChangeScene(string scenename)
     {
        SceneManager.LoadScene(scenename);
     }

     public void QuitGame()
     {
         Application.Quit();
     }
}
