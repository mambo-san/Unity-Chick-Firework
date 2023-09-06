using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Click registered - Mouse Pos:" + Input.mousePosition.x + ", " + Input.mousePosition.x);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 200))
            {
                Debug.Log("Hit detected: " + hit.transform.gameObject.name);
                //Implement something to ignore when plane is clicked.
                if (!hit.transform.gameObject.CompareTag("Plane")) 
                {
                    Chicken chick = hit.transform.gameObject.GetComponent<Chicken>();
                    chick.ClickAction();
                }
            }
        }
    }

    
}
