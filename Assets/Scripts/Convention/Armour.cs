using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 所有的护甲基类
/// </summary>
public class Armour : ShipComponent
{
    public Slider armSlider;
    /// <summary>
    /// 护甲值
    /// </summary>
    public int armor = 25;
    public int currentArmor;
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        // 第二个Slider是护甲
        armSlider = GetComponentsInChildren<Slider>(true)[1];
        armSlider.maxValue = armor;
        armSlider.value = armor;
        currentArmor = armor;
        armSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (armSlider.value / armor <= 0.6f)
        {
            armSlider.gameObject.SetActive(true);
        }
    }

    override public void Damage(int damageValue)
    {
        if (currentArmor > 0)
        {
            currentArmor -= damageValue / 6;
            armSlider.value = currentArmor;
        }
        else
        {
            currentHP -= damageValue;
            hpSlider.value = currentHP;
            if (currentHP <= 0) OnHp0();
        }
    }
}
