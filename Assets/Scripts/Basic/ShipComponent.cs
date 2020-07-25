using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 所有船体部件的基类
/// </summary>
public class ShipComponent : MonoBehaviour
{
    public bool isOnFire = false;
    public int fullHP = 100;
    public int currentHP = 100;
    public Slider hpSlider;
    public GameObject explosionEffectPrefab;
    public GameObject fireEffectPrefab;
    protected GameObject fireEffect;
    Coroutine fireCt;
    public GameObject putOutFirePrefab;
    protected GameObject putOutFire;
    
    /// <summary>
    /// 起火概率，百分之多少
    /// </summary>
    public int firePossibility = 100;

    public void Update()
    {
        hpSlider.value = currentHP;
        if (hpSlider.value < fullHP)
        {
            hpSlider.gameObject.SetActive(true);
        }
    }

    public void Start()
    {
        hpSlider = GetComponentInChildren<Slider>(true);
        hpSlider.interactable = false;
        hpSlider.maxValue = fullHP;
        hpSlider.value = fullHP;
        currentHP = fullHP;
        hpSlider.gameObject.SetActive(false);
    }

    public void SetFire()
    {
        if(AirShip.count == 4)
        {
            AirShip.count++;
        }
        // 防止部件多次着火
        if (isOnFire) return;
        putOutFire = Instantiate(putOutFirePrefab, transform.position + new Vector3(0,0,-2), transform.rotation, GetComponentInChildren<Canvas>().transform);
        putOutFire.GetComponent<Button>().onClick.AddListener(Outfire);
        fireEffect = Instantiate(fireEffectPrefab, transform.position, transform.rotation);
        isOnFire = true;
        fireCt = StartCoroutine(CauseContinueDamage(0.3F));
    }

    public void Outfire()
    {
        if (AirShip.count == 5)
        {
            AirShip.count++;
        }
        GetComponentInParent<AirShip>().DecreaseWater(10);
        Destroy(putOutFire);
        isOnFire = false;
        StopCoroutine(fireCt);
        Destroy(fireEffect);
    }

    public virtual void Damage(int damageValue)
    {
        currentHP -= damageValue;
        if (currentHP <= 0) OnHp0();
        if (Random.Range(0, 99) < firePossibility && AirShip.count >= 4) SetFire();
    }

    public virtual void OnHp0()
    {
        if (AirShip.count == 6)//第一次组件损毁
        {
            AirShip.count++;
        }
        GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(fireEffect);
        Destroy(gameObject);
    }

    IEnumerator CauseContinueDamage(float interval)
    {
        while (true)
        {
            currentHP--;
            hpSlider.value = currentHP;
            if (currentHP <= 0) OnHp0();
            yield return new WaitForSeconds(interval);
        }
    }
}
