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

    //public void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    public void OnCollisionEnter(Collision col)
    {
        //GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        var x = col.gameObject.GetComponentInChildren<ShipComponent>();
        if (x == null) return;
        x.Damage(30);
        //Destroy(effect, 1);
        Destroy(gameObject);
    }
}
