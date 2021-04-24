using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dioDialoglar : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public Sprite dialogGorsel;
    public Image img;
    private void Start()
    {
       // StartCoroutine(Type());
    }
    public void cumleOlustur()
    {  if (textDisplay.text == "")
        {
            StartCoroutine(Type());
        }
    }
    IEnumerator Type()
    {
        img.enabled = true;
        img.sprite = dialogGorsel;
        textDisplay.enabled = true;
        index = Random.Range(0, sentences.Length);
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        textDisplay.text = "";
        textDisplay.enabled = false;
        img.enabled = false;
    }

   
}
