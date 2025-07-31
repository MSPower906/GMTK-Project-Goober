using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyScript : EnemiesScript
{

    public Vector3[] movePoints;
    private int pointIndex;
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while(transform.position != movePoints[pointIndex])
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[pointIndex], speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        SetTarget();
    }

    void SetTarget()
    {
       if(pointIndex >= movePoints.Length-1)
       {
            pointIndex = 0;
       }
       else
       {
            pointIndex++;
       }

       StartCoroutine(MoveToTarget());
    }
}
