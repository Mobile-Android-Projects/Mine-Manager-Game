using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/*
 * Base class for miners. 
 * has basic miner functionality
 * such as moving,collecting and depositing.
 */
public class BaseMiner : MonoBehaviour
{
    [SerializeField] protected Transform collectingLocation;
    [SerializeField] protected Transform depositLocation;
    [SerializeField] protected float moveSpeed;

    public bool isTimeToCollect { get; set; }

    private void Start()
    {
        isTimeToCollect = true;
    }
    protected void MoveMiner(Vector3 goalPos)
    {
        var tweakedGoalPos = new Vector3(goalPos.x, transform.position.y);
        transform.DOMove(tweakedGoalPos, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (isTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        }).Play();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveMiner(collectingLocation.position);
        }
    }

    protected virtual void CollectGold()
    {
        
    }
    protected virtual void DepositGold()
    {

    }

    protected void SwitchGoal()
    {
        isTimeToCollect = !isTimeToCollect;
    }

    protected void FlipMiner(int direction)
    {
        //where if direction is 1 miner is facing right
        //if direction is -1 miner is facing left
        if (direction == 1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
