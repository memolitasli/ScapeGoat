using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class karakterHareket : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public float moveInput;
    public Rigidbody2D rb;
    public bool sagaDonuk = true;
    private bool karakterYerdemi;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extrajumpDeger;
    public Animator animator;
    public canbari canbari;
    public int maxCan = 100;
    public GameObject karakterDialogManager;
    public GameObject[] triggers;
    public GameObject kapanisEfekti;
    private Animator kapanisEfektAnim;
    public GameObject patlamaEfekti;
   
    public bool hareketEdebilirMi = true;

    // startmetodu program çalışğı anda çalışır. Başlangıçta olacak olan değerleri atamak için kullanıyorum
    void Start()
    {
        extraJump = extrajumpDeger;
        canbari.setMaxHealth();
        kapanisEfektAnim = kapanisEfekti.GetComponent<Animator>();
        StartCoroutine(kapanisEfektiOynat());

    }

    IEnumerator kapanisEfektiOynat()
    {
        kapanisEfektAnim.SetBool("acikmi", true);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator kapanisEfektiKapanisOynat()
    {
        kapanisEfektAnim.SetBool("acikmi", false);
        yield return new WaitForSeconds(1f);
    }


    /*Update metodu karede bir kere çalışabilir. FixedUpdate metodu ise karede birden fazla çalışır. Bu nedenle hızlı çalışmasına gerek
     olmayan zıplama gibi eylemler için update metodu kullanılırken hareket eylemleri veya karakterin herhangi bir oyun nesnesi
    ile temas edip etmediğini kontrol etmek için fixedUpdate metodunu kullanıyorum*/
    void Update()
    {
        if(maxCan <= 0)
        {
            StartCoroutine(kapanisEfektiKapanisOynat());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // karakterim layer etiketi zemin olan nesnelerle temas halinde ise yapabileceği zıplama sayısını sabit bir değere eşitliyorum
        if (karakterYerdemi == true)
        {
            extraJump = extrajumpDeger;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && karakterYerdemi == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

    }
    private void FixedUpdate()
    {
        if (hareketEdebilirMi == true)
        {
            // groundCheck karakterin zemin ile temas edip etmediğini kontrol edebilmem için oluşturduğum bir oyun objesi, 
            //groundCheck objesinin bulunduğu konumda checkRadius değerinin boyutunda bir çember oluşturuyorum ve eğer bu çember whatIsground 
            //adındaki layerlara temas ediyor ise karakterYerdemi true oluyor
            karakterYerdemi = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            //moveInput adlı değişkene kullanıcıdan girilen inputu atıyorum sağ tarafa doğru ise 0 ile 1, sol tara ise 0 -1 arasında bir değer alıyor
            moveInput = Input.GetAxisRaw("Horizontal");
            //karakterin animasyonlarını kontrol edebilmek için animasyon adında bir parametrem var içerisindeki speed değerine kullanıcının girdiği 
            // input değerinini pozitif olarak yolluyorum ki sağ veya sola doğru hareket ettiği zaman yürüme animasyonu devreye girsin ancak sabit durduğu
            //zaman idle animasyonu çalışsın
            animator.SetFloat("speed", Mathf.Abs(moveInput));
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            // karakter hangi tarafa hareket ediyor görselini o tarafa döndürüyorum
            if (sagaDonuk == false && moveInput > 0)
            {
                karakterDondur();
            }
            else if (sagaDonuk == true && moveInput < 0)
            {
                karakterDondur();
            }
        }
    }
    void karakterDondur()
    {
        // karakterin harekte ettiği tarafa doğru görselini çeviren fonksiyon
        sagaDonuk = !sagaDonuk;
        if (sagaDonuk)
        {
            transform.Rotate(0, -180, 0);

        }
        else
        {
            transform.Rotate(0, 180, 0);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "yapiskanZemin")
        {
            speed = 2f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = 5f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.tag == "dialog")
        {
            int i = 0;
            for(i = 0; i < triggers.Length; i++)
            {
                if(col.gameObject == triggers[i])
                {
                    break;
                }
            }
            karakterDialog dialog = karakterDialogManager.GetComponent<karakterDialog>();
            dialog.cumleOlustur(i);
            Destroy(col.gameObject);
        }
        if(col.tag == "nextLevelTrigger")
        {
            StartCoroutine(kapanisEfektiKapanisOynat());
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

        if (col.tag == "dusman")
        {
            Debug.Log("Dusman ile Temas Gerceklesti");
            rb.velocity = Vector2.up * jumpforce;
            maxCan -= 40;
            canbari.setHealth(maxCan);


        }
        if(col.tag == "dususNoktasi")
        {

            StartCoroutine(dusuyoruz());
           
        }

        IEnumerator dusuyoruz()
        {

            string[] dususCumleleri = { "dis mihraklar ayagimizi kaydirmayi sonunda basardi...", "o son yemege bisey mi kattin sen ? ucuyor gibiyiz.", "yillarca bunun icin mi ugrastik biz" };
            karakterDialog dialog = karakterDialogManager.GetComponent<karakterDialog>();
            dialog.odCumleleriOlustur(dususCumleleri[Random.Range(0, dususCumleleri.Length)]);
            yield return new WaitForSeconds(2f);
            StartCoroutine(kapanisEfektiKapanisOynat());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(col.tag == "finito")
        {

            Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
            
            

            
        }

        if (col.tag == "siringa")
        {
            string[] cumlelistesi = { "ahhhh, harika geldi", "woah, tekrardan ergen gibi hissetmeye basladim", "beyaz ati surmeye basladik tekrardan hahaha", "tum dertlerim ucup gitmis gibi hissediyorum" };

            if (maxCan < 100)
            {
                int x = Random.Range(0, cumlelistesi.Length);
                karakterDialog dialog = karakterDialogManager.GetComponent<karakterDialog>();
                dialog.odCumleleriOlustur(cumlelistesi[x]);

                camShake.Instance.rotateCamera();
                maxCan += 40;
                Destroy(col.gameObject);
                canbari.setHealth(maxCan);
            }
            else
            {
                string[] odCumleleri = { "ogghhh ,ogghhh , bozuk mal galiba", "lemmy : aaahhh ,ahhhh kurtarin beni ,yardim edin", "dio : ahhh iste sonunda kontrolu ben ele gecirecegim" };
                int x = Random.Range(0, odCumleleri.Length);
                karakterDialog dialog = karakterDialogManager.GetComponent<karakterDialog>();
                dialog.odCumleleriOlustur(odCumleleri[x]);
                camShake.Instance.rotateCamera();
                Destroy(col.gameObject);
                maxCan = maxCan - 30;
                canbari.setHealth(maxCan);
            }

        }
        if(col.tag == "tuzak" || col.tag == "balta")
        {
            rb.velocity = Vector2.up * jumpforce;
            maxCan -= 40;
            canbari.setHealth(maxCan);  
        }
      
        if(col.tag == "oyunuDurdur")
        {
            Time.timeScale = 0f;
            //Dialog Yazdır...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(col.gameObject);
                Time.timeScale = 1f;
                
            }
        }
    }
}
