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
    Coroutine fireCt;
    /// <summary>
    /// 起火概率，百分之多少
    /// </summary>
    public int firePossibility = 20;

    public void Start()
    {
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.interactable = false;
        hpSlider.maxValue = fullHP;
        hpSlider.value = fullHP;
        currentHP = fullHP;
    }

    public void SetFire()
    {
        isOnFire = true;
        fireCt = StartCoroutine(CauseContinueDamage(0.3F));
    }

    public void Outfire()
    {
        StopCoroutine(fireCt);
    }

    public virtual void Damage(int damageValue)
    {
        currentHP -= damageValue;
        hpSlider.value = currentHP;
        if (currentHP <= 0)
        {
            GameObject effect;
            effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
        if (Random.Range(0, 99) < firePossibility) SetFire();
    }

    IEnumerator CauseContinueDamage(float interval)
    {
        while (true)
        {
            currentHP--;
            hpSlider.value = currentHP;
            if (currentHP <= 0)
            {
                GameObject effect;
                effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
                Destroy(effect, 1);
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
