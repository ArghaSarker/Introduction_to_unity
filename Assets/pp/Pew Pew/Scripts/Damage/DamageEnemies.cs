using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Damages enemies on trigger enter.
    /// </summary>
    [RequireComponent(typeof(PoolableProjectile))]
    public class DamageEnemies : MonoBehaviour
    {
        private PoolableProjectile m_Projectile;

        void Awake()
        {
            m_Projectile = GetComponent<PoolableProjectile>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") || other.CompareTag("Blackhole"))
            {
                var hits = other.GetComponents<HitListener>();

                foreach (var hit in hits)
                {
                    hit.OnHit(m_Projectile.damage);
                }

                m_Projectile.ReturnProjectile();
            }
        }
    }
}