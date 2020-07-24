using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirShip : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed = 1;
    public GameObject text;
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;
    public int count = 0;
    public Slider waterSlider;
    void Start()
    {
        //添加大炮
        
    }

    public void DecreaseWater(int value)
    {
        waterSlider.value -= value;
    }

    // Update is called once per frame
    void Update()
    {
        text = GameObject.Find("textCube");
        if (up && down && left && right)
        {
            if (count == 0) { 
                text.GetComponentInChildren<Text>().text = "下一步 发射武器，按鼠标左键发射炮弹";
                count++;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
            up = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
            down = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            left = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
            right = true;
        }

    }
}
