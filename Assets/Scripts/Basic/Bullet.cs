using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹、炮弹的基类
/// </summary>
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
