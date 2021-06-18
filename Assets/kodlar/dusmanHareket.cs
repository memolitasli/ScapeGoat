using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    
    public Collider2D zeminCollider;
    public Rigidbody2D rb;
    public TextMeshProUGUI textDisplay;
    public string sentences;
    private int index;
    float sesOynatmaSuresi;
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
            //StartCoroutine(flip());
        }


        if (bodyCollider.IsTouchingLayers(karakterLayer))
        {
            //saldırı animasyonunu oynat
            anim.SetBool("temas", true);
        }



    }

    IEnumerator flip()
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
        
        yield return new WaitForSeconds(1f);
    }
    public void hasarAl(int hasar)
    {
        maxCan = maxCan - hasar;
        if (maxCan <= 0)
        {
            
            camShake.Instance.shakeCamera(5f, 0.1f);
            Destroy(this.gameObject);
            StartCoroutine(patlamaOynat());
            FindObjectOfType<muzikManager>().playSound("yaratikSesi");


        }
    }

    public void cumleOlustur()
    {
            textDisplay.text = "";
            StartCoroutine(Type());
        

    }
    IEnumerator Type()
    {

        textDisplay.enabled = true;

        textDisplay.text = sentences;
        yield return new WaitForSeconds(2f);
        textDisplay.text = "";
        textDisplay.enabled = false;

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
        if(col.tag == "dusman")
        {
            if (movingRight == true)
            {   //karakterin sprite'ini 180 derece çeviriyorum ve sol tarafa hareket ettiriyorum
                transform.Rotate(0, -180, 0);
                movingRight = false;
                rb.velocity = Vector2.right * 5;
            }
            else
            {
                //sol tarafta ens ona geldi ise
                transform.Rotate(0, 180, 0);
                movingRight = true;
                rb.velocity = Vector2.right * 5;
            }
        }
     

    }
   

}
