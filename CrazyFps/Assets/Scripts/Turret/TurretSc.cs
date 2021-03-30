using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSc : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRate = 1f;
    public float turnSpeed = 10f;
    public float range = 15f;
    public float bulletForce = 5f;

    [Header("Required Unity Components")]
    public Transform player;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;


    private Transform target;
    private float fireCountdown = 0f;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
     
        partToRotate.rotation = Quaternion.Euler(rotation.x,rotation.y, 0f);
        
        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    
    }

    void UpdateTarget()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,player.position);

        if (player != null && distanceToPlayer <= range)
        {
            target = player;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletGo.GetComponent<Rigidbody>().AddForce(bulletGo.transform.forward.normalized * bulletForce,ForceMode.Impulse);
        if(bulletGo != null)
        {
            Destroy(bulletGo, 5f);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
