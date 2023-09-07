using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenSpiral: Chicken
{
    public override void ClickAction()
    {
        int numChicksToSpawn = GameManager.Instance.spawnCount;
        Vector3 pos = transform.position;
        Quaternion rotation = transform.rotation;
        
        //1st loop: Right, Left
        //2nd loop: Up, Down
        float spacing = 1f;
        float distance = 0;
        bool horizontalPlacement = true;

        for (int i = 1; i <= numChicksToSpawn; i++)
        {
            distance = i * spacing;

            if (horizontalPlacement)
            {
                Instantiate(childChick, pos + new Vector3(distance, 0), rotation);
                i++;
                if (i < numChicksToSpawn)
                {
                    Instantiate(childChick, pos + new Vector3(-distance, 0), rotation);
                }
                horizontalPlacement = false;
            }
            else
            {
                Instantiate(childChick, pos + new Vector3(0, distance), rotation);
                i++;
                if (i < numChicksToSpawn)
                {
                    Instantiate(childChick, pos + new Vector3(0, -distance), rotation);
                }
                horizontalPlacement = true;
            }
        }
        PushChicksAway(distance * 2);
        Destroy(gameObject);
    }

}
