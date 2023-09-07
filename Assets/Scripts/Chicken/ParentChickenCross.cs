using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenSpiral: Chicken
{
    public override void ClickAction()
    {
        Instantiate(childChick);
        Destroy(gameObject);
    }
}
