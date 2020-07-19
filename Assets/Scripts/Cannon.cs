using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public abstract class Cannon : ShipComponent
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 大炮开火。
     * 应该生成一个炮弹 */
    public abstract void Fire();
}
