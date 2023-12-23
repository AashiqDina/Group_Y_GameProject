using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public GameObject RayCastOut;
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
        Debug.Log(hit.distance);

        return hit.distance;
    }

    public GameObject GetObject(float Distance){
        RaycastHit hit;
        Physics.Raycast(RayCastOut.transform.position, RayCastOut.transform.forward,out hit, Distance);
        Debug.DrawRay(RayCastOut.transform.position, RayCastOut.transform.forward * Distance,Color.green, 100);
        if(hit.transform == null){
            return gameObject;
        }
        return  hit.transform.gameObject;

    }
}
