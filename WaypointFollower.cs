using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    int NextPosIndex;
    Transform NextPos;

    [SerializeField] float speed;

    void Start()
    {
        NextPos=Positions[0];
    }

    private void Update()
    {
        if (transform.position==NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex>=Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, Time.deltaTime * speed);
        }
    }
}