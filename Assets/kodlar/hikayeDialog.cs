using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class hikayeDialog : MonoBehaviour
{
    public string[] yazi;
    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        StartCoroutine(yaz());
    }

    IEnumerator sesOynat()
    {
        
        yield return new WaitForSeconds(1f); 
    }

    IEnumerator yaz()
    {
       
        textDisplay.enabled = true;
        for(int i = 0; i < yazi.Length; i++)
        {
            textDisplay.text = "";
            foreach(char letter in yazi[i].ToCharArray())
            {

               
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);
        if(SceneManager.GetActiveScene().buildIndex != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
