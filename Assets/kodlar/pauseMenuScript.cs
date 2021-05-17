using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                devamEt();
            }
            else
            {
                oyunuDurdur();
            }
        }

    }
    public void devamEt()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void oyunuDurdur()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void reloadBolum() {
        Debug.Log("Bolum Bastan Baslatiliyor");
        devamEt();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void oyunuKapat()
    {
        Time.timeScale = 1f;
        Debug.Log("Oyun Kapatıldı"); 
        Application.Quit();
    }

}
