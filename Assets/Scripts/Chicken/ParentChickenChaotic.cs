using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ParentChickenChaotic: Chicken
{
    // POLYMORPHISM
    public override void ClickAction()
    {
        int numToSpawn = GameManager.Instance.spawnCount;
        float range = 25;
        float delayTime = (0.5f/numToSpawn) + 0.02f;
        Debug.Log(delayTime);
        StartCoroutine(SpawnChicks(numToSpawn, range, delayTime));
    }

    private IEnumerator SpawnChicks(int numToSpawn, float range, float delayTime)
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            SpawnChickAtRandomPos(range);
            yield return new WaitForSeconds(delayTime);
        }
        PushChicksAway(range*2);
        Destroy(gameObject);
    }

    private void SpawnChickAtRandomPos(float range)
    {
       
        float posX = Random.Range(-range, range);
        float posY = Random.Range(-range, range);
        float posZ = transform.position.z + Random.Range(-range, range); 

        Instantiate(childChick, new Vector3(posX, posY, posZ), transform.rotation);
    }


}
