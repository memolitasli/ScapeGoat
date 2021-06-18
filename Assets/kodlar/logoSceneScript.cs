using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class logoSceneScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(suresay());
    }

    IEnumerator suresay()
    {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
}
