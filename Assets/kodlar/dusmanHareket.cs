using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmanHareket : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    public Transform yerKontrol;
    public float mesafe;
    public Collider2D bodyCollider;
    public LayerMask zeminLayer;
    public LayerMask dusmanLayer;
    public LayerMask karakterLayer;
    public int maxCan = 100;
    public GameObject patlamaEfekti;
    public Animator anim;
    public Animator camAnim;
    public GameObject dialogManager;
    public Collider2D zeminCollider;

    private void Start()
    {
     
    }

    private void Update()
    {
        //Düşman karakterin konumunu değiştiriyorum 
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D yerBilgisi = Physics2D.Raycast(yerKontrol.position, Vector2.down, mesafe);
        if (yerBilgisi.collider == false)
        {
            //eğer karakter sağ tarafta platformun sonuna geldi ise
            if (movingRight == true)
            {   //karakterin sprite'ini 180 derece çeviriyorum ve sol tarafa hareket ettiriyorum
                transform.Rotate(0, -180, 0);
                movingRight = false;

            }
            else
            {
                //sol tarafta ens ona geldi ise
                transform.Rotate(0, 180, 0);
                movingRight = true;
            }
        }
        if (bodyCollider.IsTouchingLayers(zeminLayer))
        {
            if (movingRight == true)
            {   //karakterin sprite'ini 180 derece çeviriyorum ve sol tarafa hareket ettiriyorum
                transform.Rotate(0, -180, 0);
                movingRight = false;

            }
            else
            {
                //sol tarafta ens ona geldi ise
                transform.Rotate(0, 180, 0);
                movingRight = true;
            }
        }
        if (bodyCollider.IsTouchingLayers(dusmanLayer))
        {
            GameObject[] otherObject = GameObject.FindGameObjectsWithTag("dusman");
            foreach (GameObject obj in otherObject)
            {
                Physics2D.IgnoreCollision(obj.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
            }

            if (movingRight == true)
            {   //karakterin sprite'ini 180 derece çeviriyorum ve sol tarafa hareket ettiriyorum
                transform.Rotate(0, -180, 0);
                movingRight = false;

            }
            else
            {
                //sol tarafta ens ona geldi ise
                transform.Rotate(0, 180, 0);
                movingRight = true;
            }
        }
        if (bodyCollider.IsTouchingLayers(karakterLayer))
        {
            //saldırı animasyonunu oynat
            anim.SetBool("temas", true);
        }



    }
    public void hasarAl(int hasar)
    {
        maxCan = maxCan - hasar;
        if (maxCan <= 0)
        {
            dioDialoglar dio = dialogManager.GetComponent<dioDialoglar>();
            dio.cumleOlustur();
            Destroy(this.gameObject);
            StartCoroutine(patlamaOynat());

        }
    }

    IEnumerator patlamaOynat()
    {
        Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(patlamaEfekti.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "karakter")
        {
            anim.SetBool("temas", true);
        }
       

    }
   

}
