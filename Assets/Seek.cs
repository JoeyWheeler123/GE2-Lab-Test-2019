using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Seek : SteeringBehaviour
{
    public GameObject bullet;

    public GameObject targetGameObject = null;
    public Vector3 target;// = Vector3.zero;

    //public Transform[] bases;

    int index;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }
    
    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);    
    }

    public void Start()
    {
       //var possibleTargets = GameObject.FindWithTag("base");
        //targetGameObject = possibleTargets[Random.Range(0, possibleTargets.length)].transform;
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet);
    }

}