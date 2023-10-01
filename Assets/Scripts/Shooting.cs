using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float gunCd;
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0));
        {
            if(gunCd>0)
            {
                gunCd -= Time.deltaTime;
            }
            else if(gunCd<=0)
            {
                gunCd = 0.5f;
                Shoot();
            }
            
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode.Impulse);
    }
}
