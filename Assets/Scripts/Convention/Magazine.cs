using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : ShipComponent
{
    public override void OnHp0()
    {
        if (AirShip.count == 7)//第一次弹药库损毁
        {
            AirShip.count++;
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
        foreach(Collider collider in colliders)
        {
            if (collider.gameObject == this.gameObject) continue;
            ShipComponent sp = collider.gameObject.GetComponent<ShipComponent>();
            if(sp != null) 
                sp.Damage(30);
        }

        GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(fireEffect);
        Destroy(gameObject);
        
    }

    public override void Damage(int damageValue)
    {
        currentHP -= damageValue;
        hpSlider.value = currentHP;
        if (currentHP <= 0) this.OnHp0();
        if (Random.Range(0, 99) < firePossibility) SetFire();
    }
}
