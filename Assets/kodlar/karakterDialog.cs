using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class karakterDialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    public void cumleOlustur(int index)
    {
        if (textDisplay.text == "")
        {
            StartCoroutine(Type(index));
        }
    }
    IEnumerator Type(int index)
    {
      
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        textDisplay.text = "";

    }
}
