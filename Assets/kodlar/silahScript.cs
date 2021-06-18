using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahScript : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 50;
    public LineRenderer lineRenderer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(atesEt());
        }
    }
    IEnumerator atesEt()
    {

        FindObjectOfType<muzikManager>().playSound("atesEtmeSesi");

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            dusmanHareket dusman = hitInfo.transform.GetComponent<dusmanHareket>();
            if (dusman != null)
            {
                dusman.hasarAl(damage);
            }
            
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        //bir kare bekle
        yield return new WaitForSeconds(0.04f);

        lineRenderer.enabled = false;

    }
}
