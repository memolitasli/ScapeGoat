using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dayiScript : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string[] cumleler;
    public karakterHareket karakter;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "karakter")
        {
            karakter = col.GetComponent<karakterHareket>();
            StartCoroutine(cumleleriYaz());
            Collider2D cd = this.GetComponent<BoxCollider2D>();
            Destroy(cd);
           
        }
    }

    IEnumerator cumleleriYaz()
    {
        
        karakter.hareketEdebilirMi = false;
        for (int i = 0; i < cumleler.Length; i++)
        {
            yield return new WaitForSeconds(2f);
            txt.text = "";
            foreach(char c in cumleler[i].ToCharArray())
            {
                txt.text += c;
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        txt.text = "";
        karakter.hareketEdebilirMi = true;
    }
   
}
