using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fastweaksniper : Enemy
{
    
  
    protected override void Start()
    {
      
        damage = 3f;
        base.Start();
  
    }

    private void Update()
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