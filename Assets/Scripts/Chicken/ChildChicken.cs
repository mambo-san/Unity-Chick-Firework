using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildChicken : Chicken
{
    private string m_name = "chick #";

    private float yBoundary = -40;

    // Start is called before the first frame update
    void Start()
    {
        m_name += UnityEngine.Random.Range(10000, 900000);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yBoundary)
        {
            Destroy(gameObject);
        }
    }

    //The mechanism for spawn movement needs to be refactored.
    public override void ClickAction()
    {
        int spawnType = GameManager.Instance.SelectedType;
        switch (spawnType)
        {
            case 0:
                SpawnStandard();
                break;
            case 1:
                SpawnCross();
                break;
            case 2:
                SpawnChaos();
                break;
            default:
                base.ClickAction();
                break;
        }
    }

    public void SpawnStandard()
    {
        int numChicksToSpawn = GameManager.Instance.spawnCount;
        //Spawn child chick around the object clicked
        double radianTick = (360 / numChicksToSpawn) * (Math.PI / 180);
        double radius = 10;

        for (int i = 0; i < numChicksToSpawn; i++)
        {
            double angle = radianTick * i;


            float x = (float)(radius * Math.Cos(angle));
            float y = (float)(radius * Math.Sin(angle));

            Vector3 offset = new Vector3(x, y, 0);
            Vector3 pos = transform.position + offset;
            Instantiate(childChick, pos, transform.rotation);

        }
        //Add explosion so child chicks fly away
        PushChicksAway((float)radius * 3);

        Destroy(gameObject);
    }

    public void SpawnCross()
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
    
    public void SpawnChaos()
    {

    }
}
