using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class finitoScript : MonoBehaviour
{
    public GameObject kapanmaEfekti;
    public TextMeshProUGUI text;
    public string[] cumleler;
    private Animator anim;
    
    IEnumerator cumleYaz()
    {
        for (int i = 0; i < cumleler.Length; i++)
        {
            text.text = "";
            foreach(char c in cumleler[i].ToCharArray())
            {
                text.text += c;
                yield return new WaitForSeconds(0.08f);
            }
            yield return new WaitForSeconds(3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "karakter")
        {
           // StartCoroutine(cumleYaz());
            
            anim.SetBool("acikmi", false);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
