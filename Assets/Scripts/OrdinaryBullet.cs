using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinaryBullet : Bullet
{
    public GameObject explosionEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        if(gameObject)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        col.gameObject.GetComponentInChildren<ShipComponent>().Damage(30);
        //Destroy(effect, 1);
        Destroy(gameObject);
    }
}
