using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowTank : Enemy
{
    
    protected override void Start()
    {
        healthValue = new Health(70);
        damage = 10f;
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

    public override void PlayDeadEffect()
    {
        DropPowerUp();
        base.PlayDeadEffect();
    }
}
