using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class btnTextileri : MonoBehaviour
{
    public string[] yazilar;
    int sayac = 0;  
    public TextMeshProUGUI txt;
    public void tiklandi()
    {
        sayac++;
        if(sayac >= yazilar.Length)
        {
            sayac = 0;
        }
        txt.text = yazilar[sayac];
    }
}
