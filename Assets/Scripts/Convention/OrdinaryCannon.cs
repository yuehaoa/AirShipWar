using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrdinaryCannon : Cannon
{
    public Text textOfBullet;
    static public bool isFired = false;

    public GameObject cannonCount;
    /*用来只执行一次text的内容*/
    public int count = 0;
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        textOfBullet = GetComponentInChildren<Text>();
        textOfBullet.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //cannonCount = GameObject.Find("cannonCount");
        // 按下鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            // 按在屏幕上，没有按在物体上
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (ammunitionQuantity > 0)
                {
                    Fire();
                }
                //else
                //{
                //    textOfBullet.text = "你已经没有子弹了";
                //}
                //if (count == 0)
                //{
                //    textOfBullet.text = "做的很好，你可以尝试击毁敌方飞船了";
                //    count++;
                //}
            }
        }
    }

    public void Fire()
    {
        if (isFired == false)
            isFired = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        // 子弹角度
        GameObject gameObject = Instantiate(bullet, transform.position + new Vector3(0.7F, 0, 0), Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().AddForce((mousePosition - transform.position).normalized * 50);

        ammunitionQuantity--;
        textOfBullet.text = "炮弹数量: " + ammunitionQuantity.ToString();
    }
}
