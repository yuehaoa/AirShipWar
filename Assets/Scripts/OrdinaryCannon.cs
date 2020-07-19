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
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // 因为是2D
        mousePosition.z = 0;
        // 子弹角度
        float fireAngle = Vector2.Angle(mousePosition - this.transform.position, Vector2.up);
        GameObject gameObject = Instantiate(bullet, transform.position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().velocity = ((mousePosition - transform.position).normalized * 30);
        gameObject.transform.eulerAngles = new Vector3(0, 0, fireAngle);
    }
}
