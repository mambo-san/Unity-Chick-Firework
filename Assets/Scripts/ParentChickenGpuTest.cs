using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenGpuTest: Chicken
{
    public override void ClickAction()
    {
        Instantiate(childChick);
        Destroy(gameObject);
    }
}
