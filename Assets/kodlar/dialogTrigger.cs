using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrigger : MonoBehaviour
{
    public GameObject dialogmanager;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "karakter")
        {
            dioDialoglar dialog = dialogmanager.GetComponent<dioDialoglar>();
            dialog.cumleOlustur();
        }
    }
}
