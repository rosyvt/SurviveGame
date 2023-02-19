using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;
using Enemy;

public class ZonedDamage : MonoBehaviour
{
    public string targetTag = "Enemy";
    public float damage;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    void ScanForDead()
    {
        enemies.RemoveAll(enemy => {
            if (enemy == null)
            {
                return true;
            }
            HealthManager healthManager = enemy.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                return healthManager.IsDead();
            }
            return false;
        });
    }

    public void DealDamage()
    {
        ScanForDead();
        enemies.ForEach(enemy =>
        {
            HealthManager healthManager = enemy.GetComponent<HealthManager>();
            if (healthManager == null || healthManager.IsDead() == true)
            {
                return;
            }
            healthManager.TakeDamage(-damage);
            EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();
            if (enemyControl != null)
            {
                enemyControl.GetHit(Random.Range(1, 6));
            }
        });
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            enemies.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        enemies.Remove(other.gameObject);
    }
}
