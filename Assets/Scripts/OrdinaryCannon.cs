using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrdinaryCannon : Cannon
{
    public GameObject text;
    public GameObject cannonCount;
    /*用来只执行一次text的内容*/
    public int count = 0;
    public int bulletCount = 10;
    private Vector3 direction = new Vector3(1, 0, 0);
     // Start is called before the first frame update
     void Start()
     {
    }

     // Update is called once per frame
     void Update()
     {
        text = GameObject.Find("textCube");
        cannonCount = GameObject.Find("cannonCount");
        if (Input.GetMouseButtonDown(0))
         {
            if (!EventSystem.current.IsPointerOverGameObject())
             {
                if (bulletCount > 0)
                {
                    Fire();
                    bulletCount--;
                    cannonCount.GetComponentInChildren<Text>().text = "炮弹数量: "+bulletCount.ToString();
                }
                else
                {
                    text.GetComponentInChildren<Text>().text = "你已经没有子弹了";
                }
                if (count == 0)
                {
                    text.GetComponentInChildren<Text>().text = "做的很好，你可以尝试击毁敌方飞船了";
                    count++;
                }
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
