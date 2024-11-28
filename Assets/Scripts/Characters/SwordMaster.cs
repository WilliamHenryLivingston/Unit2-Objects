using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMaster : Enemy
{

    protected override void Start()
    {
        healthValue = new Health(31); //I moved this from character into each of these classes 
        damage = 15f;
        base.Start();

    }


    void Update()
    {
        if (!target) return;

        Vector2 destination = target.transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 direction = destination - currentPosition;

        if (Vector2.Distance(destination, currentPosition) > distanceToStop)
        {
            Move(direction.normalized);
        }
        else
        {
            Attack();
        }

        Look(direction.normalized);

    }

    public override void Attack()
    {
        base.Attack();
    }
}
