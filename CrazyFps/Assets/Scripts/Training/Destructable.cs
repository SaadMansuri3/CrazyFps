using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    public GameObject destroyedVersion;
    public GameObject healthPack;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerWeapon")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(healthPack, transform.position + transform.forward * 1  ,Quaternion.identity);
        }
            
    }

}
