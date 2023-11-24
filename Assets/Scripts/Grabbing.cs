using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public int GRABI;
    public float grabPower = 10f;
    public float throwPower = 10f;
    public float RayDistance = 30f;

    private bool Grab = false;
    private bool Throw = false;
    public Transform offset;
    public Camera camera;
    RaycastHit hit;

    void Start()
    {
        GRABI = 0;
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, RayDistance, 1);
            if (hit.rigidbody) 
            {
                GRABI = GRABI + 1;
                switch (GRABI)
                {
                    case 1:
                        Grab = true;
                        break;
                    case 2:
                        Grab = false;
                        break;
                    default:
                        break;
                }
                if (GRABI == 3)
                {
                    GRABI = 0;
                }
                if (Grab == false)
                {
                    GRABI = 0;
                }
            }
            Debug.Log(GRABI);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            {
                GRABI = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            {
                Grab = false;
                Throw = true;
            }
        }

        if (Grab)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;
            }
        }

        if (Throw)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = camera.ScreenPointToRay(Input.mousePosition).direction * throwPower;
                Throw = false;
            }
        }

        void Grabb()
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, RayDistance);
            if (hit.rigidbody)
            {
                Grab = true;
            }
        }
    }
}
