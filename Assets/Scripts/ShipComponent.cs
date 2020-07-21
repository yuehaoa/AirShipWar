using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipComponent : MonoBehaviour
{
    public float fullHP = 100;
    public float currentHP;
    public float protect;
    public Slider hpSlider;
    public GameObject explosionEffectPrefab;
    public GameObject magazineExplosion;
    public float radius = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = fullHP;
        hpSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hpSlider.value <= 0.6f)
        {
            hpSlider.gameObject.SetActive(true);
        }
    }

    public void damage(float damageValue)
    {
        currentHP -= damageValue*(1-protect);
        if (currentHP<=0)
        {
            GameObject effect;
            if (gameObject.name== "magazineComp")
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
                        if(m_cCollider[i].gameObject.GetComponent<shipComponent>())
                        {
                            m_cCollider[i].gameObject.GetComponent<shipComponent>().damage(fullHP * 0.4f);
                        }
                    }
                }
                Destroy(effect, 2f);
                Destroy(this.gameObject);
            }
            else
            {
                effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
                Destroy(effect, 1);
                Destroy(this.gameObject);
            }
        } else
        {
            hpSlider.value = (float)currentHP / fullHP;
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
