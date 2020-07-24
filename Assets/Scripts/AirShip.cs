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
    static public int count = 0;
    public Slider waterSlider;
    public Slider fuelSlider;
    void Start()
    {
        fuelSlider.maxValue = 1000;
        fuelSlider.value = 1000;
    }

    public void DecreaseWater(int value)
    {
        waterSlider.value -= value;
    }

    // Update is called once per frame
    void Update()
    {
        text = GameObject.Find("textCube");
        {
            if (count == 0&& (up || down || left || right))//移动一下后
            {
                text.GetComponentInChildren<Text>().text = "飞船移动将消耗燃料";
                count++;
            }
            else if (count == 1&& up && down && left && right) { //上下左右都移动过后
                text.GetComponentInChildren<Text>().text = "下一步 发射武器，按鼠标左键发射炮弹";
            }
            else if(count == 2)//第一次发炮后
            {
                text.GetComponentInChildren<Text>().text = "我方炮弹数为50。刀剑无眼，小心伤到自己。";
            }
            else if(count == 3)//发射3炮后
            {
                text.GetComponentInChildren<Text>().text = "受到攻击可能引起组件着火";
            }
            else if (count == 4)//装甲受到攻击
            {
                text.GetComponentInChildren<Text>().text = "装甲不会着火,可以抵御一定攻击";
            }
            else if (count == 5)//组件着火后
            {
                text.GetComponentInChildren<Text>().text = "着火的组件将持续受火伤害，快用水灭火！";
            }
            else if (count == 6)//用水灭火后
            {
                text.GetComponentInChildren<Text>().text = "左下角显示水量，水量有限";
            }
            else if (count == 7)//第一个组件损毁
            {
                text.GetComponentInChildren<Text>().text = "组件生命值耗尽即发生爆炸损毁";
            }
            else if(count == 8)//弹药库损毁
            {
                text.GetComponentInChildren<Text>().text = "弹药库爆炸将波及爆炸半径内的所有组件！";
            }
        }
        if (fuelSlider.value <= 0)
            return;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
            up = true;
            fuelSlider.value -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
            down = true;
            fuelSlider.value -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            left = true;
            fuelSlider.value -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
            right = true;
            fuelSlider.value -= 1;
        }

    }
}
