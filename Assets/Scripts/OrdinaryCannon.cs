using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrdinaryCannon : MonoBehaviour
{
    public GameObject bullet;
    private Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("123");
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        GameObject gameObject = Instantiate(bullet, transform.position+ direction, Quaternion.identity);
        gameObject.GetComponent<OrdinaryBullet>();
    }
}
