using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCannon : Cannon
{
    public Text textOfBullet;
    public GameObject playerShip;
    float fireClock = 1;
    // Start is called before the first frame update
    new public void Start()
    {
        ammunitionQuantity = 25;
        base.Start();
        textOfBullet = GetComponentInChildren<Text>();
        textOfBullet.color = Color.yellow;
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        fireClock -= Time.deltaTime;
        if(OrdinaryCannon.isFired&&fireClock <= 0&& ammunitionQuantity>0 && playerShip.transform.childCount>0)
        {
            //Fire();
            GameObject bulletInstance = Instantiate(bullet, transform.position + new Vector3(-0.7F, 0, 0), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce((playerShip.transform.GetChild(0).gameObject.transform.position
                - transform.position).normalized * 50);
            ammunitionQuantity--;
            textOfBullet.text = "炮弹数量: " + ammunitionQuantity.ToString();
            fireClock = 1;
        }
    }

    public void Fire()
    {
        for (int i = 0; i < playerShip.transform.childCount&& ammunitionQuantity>0; i++)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + new Vector3(-0.7F, 0, 0), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce((playerShip.transform.GetChild(i).gameObject.transform.position 
                - transform.position).normalized * 50);
            ammunitionQuantity--;
            textOfBullet.text = "炮弹数量: " + ammunitionQuantity.ToString();
        }
    }
}
