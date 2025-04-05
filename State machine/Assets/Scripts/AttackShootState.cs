using UnityEngine;

public class AttackShootState : State
{
    [SerializeField] private GameObject bulletPrefab;
    private Transform firePoint;

    public AttackShootState(PlayerCombat combat) : base(combat)
    {
        bulletPrefab = combat.BulletPrefab;
        firePoint = combat.FirePoint;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(combat.AttackKey))
            Shoot();
    }

    private void Shoot()
    {
        Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}