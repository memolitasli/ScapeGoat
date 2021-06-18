using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class btn_atlaScrpit : MonoBehaviour
{
    public int counter =-1;
    public TextMeshProUGUI txt;
    public string[] cumleler;
    public void btn_basildi()
    {
        counter++;
        StartCoroutine(btnTik(counter));
        
    }

    IEnumerator btnTik(int sayac)
    {
        if (sayac < 5)
        {
            switch (sayac)
            {
                case 1:

                    txt.text = cumleler[sayac];
                    yield return new WaitForSeconds(2f);
                    txt.text = "";
                    break;
                case 2:
                    txt.text = cumleler[sayac];
                    yield return new WaitForSeconds(2f);
                    txt.text = "";
                    break;
                case 3:
                    txt.text = cumleler[sayac];
                    yield return new WaitForSeconds(2f);
                    txt.text = "";
                    break;
                case 4:

                    txt.text = cumleler[sayac];
                    yield return new WaitForSeconds(2f);
                    txt.text = "";
                    break;
                case 5:
                    txt.text = "";
                    txt.text = cumleler[sayac];
                    yield return new WaitForSeconds(2f);
                    break;

            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }


    }
}
