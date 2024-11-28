using UnityEngine;
public class Player : Character
{
    [SerializeField] private Transform playerWeaponTip;

    protected override void Start()
    {
        healthValue = new Health(50);
        healthValue.OnDied.AddListener(PlayDeadEffect);
    }



    public override void Attack()
    {
        currentWeapon.Shoot(playerWeaponTip);
    }


}
