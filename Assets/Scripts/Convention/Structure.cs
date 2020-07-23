using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 结构块
/// </summary>
public class Structure : ShipComponent
{


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
