using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Chicken : MonoBehaviour, IClickable
{
    [SerializeField]
    protected GameObject childChick;
    private Vector3 previousPos;
    private float speed = 10;
    private bool hasReachedCentre = false;
    private int numChicksToSpawn = 12;
    private Rigidbody chickRb;

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
        chickRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check boundary
        CheckBoundary();
        //Move until it reaches the center of the screen
        if (!hasReachedCentre) 
        {
            MoveUpwards();
        }
    }

    private void CheckBoundary()
    {
        if (!hasReachedCentre && previousPos.y > 0)
        {
            hasReachedCentre = true;
            //Display click me message 
            //TODO
        }
    }

    private void MoveUpwards()
    {
        //TODO - add side movements
        Vector3 newPos = previousPos + (Vector3.up * speed * Time.deltaTime);
        gameObject.transform.position = newPos;
        previousPos = newPos;
    }

    

    public virtual void ClickAction()
    {
        //Spawn child chick around the object clicked
        double radianTick = (360/numChicksToSpawn) * (Math.PI/180);
        for (int i=0; i <numChicksToSpawn; i++)
        {
            double angle =  radianTick * i;
            double radius = 10;

            float x = (float) (radius * Math.Cos(angle));
            float y = (float) (radius * Math.Sin(angle));

            Vector3 offset = new Vector3(x, y, 0);
            Vector3 pos = transform.position + offset;
            Instantiate(childChick, pos, transform.rotation);
            
        }
        //Add explosion so child chicks fly away
        StartCoroutine(PushChicksAway());
    }

    IEnumerator PushChicksAway()
    {
        Debug.Log("Chicks instantiated");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Adding exlosion force");
        chickRb.AddExplosionForce(1000, previousPos, 25, 0, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
