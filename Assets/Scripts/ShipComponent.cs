using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 结构块
/// </summary>
public class ShipComponent : Struct
{
    public int fullHP = 100;
    public int currentHP = 100;
    // public float protect;
    public Slider hpSlider;
    public GameObject explosionEffectPrefab;
    // public GameObject magazineExplosion;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.maxValue = fullHP;
        hpSlider.value = fullHP;
        currentHP = fullHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damageValue)
    {
        currentHP -= damageValue;
        hpSlider.value = currentHP;
        Debug.Log(currentHP);
        if (currentHP <= 0)
        {
            GameObject effect;
            /*if (gameObject.name== "magazineComp")
            {
                Vector3 pos = transform.position;
                pos.x -= 0.8f;
                pos.y -= 0.8f;
                effect = GameObject.Instantiate(magazineExplosion, pos, transform.rotation);
                Collider[] m_cCollider = Physics.OverlapSphere(transform.position, radius);
                for (int i = 0; i < m_cCollider.Length; ++i)
                {
                    if (m_cCollider[i].gameObject != this.gameObject)
                    {
                        if(m_cCollider[i].gameObject.GetComponent<ShipComponent>())
                        {
                            m_cCollider[i].gameObject.GetComponent<ShipComponent>().damage(fullHP * 0.4f);
                        }
                    }
                }
                Destroy(effect, 2f);
                Destroy(this.gameObject);
            }*/
            effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Bullet(Clone)")
    //    {
    //        float radius = 6.0f;
    //        //定义爆炸位置为炸弹位置
    //        Vector3 explosionPos = transform.position;
    //        //这个方法用于返回球形半径内的所有碰撞体collider[];
    //        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
    //        //遍历返回的碰撞体，如果是刚体，则给刚体添加力
    //        foreach (Collider hit in colliders)
    //        {
    //            if (hit.GetComponent<Rigidbody>())
    //            {
    //                hit.GetComponent<Rigidbody>().AddExplosionForce(1000, explosionPos, radius);
    //            }
    //            //销毁炸弹和小球
    //        }
    //    }
    //}
}
