using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyG : MonoBehaviour
{

    public Transform[] wayPointArray;

    public List<Transform> waypoints = new List<Transform>();
    public Dictionary <string, Transform> wayPointsDicc = new Dictionary<string, Transform>();

    int wayPointActual;
    float MinDist = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 newPosition = wayPointArray[wayPointActual].position;

        transform.position += (newPosition - transform.position).normalized;

        if ( Vector3.Distance(newPosition, transform.position)< MinDist)
        {
            wayPointActual++;
            if(wayPointActual >= wayPointArray.Length) 
            {
                wayPointActual = 0;
            }
        }
        
    }
}
