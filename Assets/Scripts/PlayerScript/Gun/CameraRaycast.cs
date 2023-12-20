using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float CheckDistance(float MaxDistance){
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward,out hit, 100);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 100, Color.green, 60, false);
        Debug.Log(hit.distance);

        return hit.distance;
    }
}
