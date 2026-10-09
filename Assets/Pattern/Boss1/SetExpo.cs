using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetExpo : Pattern
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject seedexpo;

    public override void Execute()
    {
        StartCoroutine(Setseed());
    }

    private IEnumerator Setseed()
    {
        yield return new WaitForSeconds(0.4f);

        List<Weapon> seeds = new List<Weapon>();

        for (int i = 1; i < 8; i++)
        {
            yield return new WaitForSeconds(0.3f);
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);
            Vector3 spawnPosition = new Vector3(
                player.position.x + randomX,
                player.position.y + randomY,
                firePoint.position.z
            );
            GameObject newSeed = Instantiate(
                seedexpo.gameObject,
                spawnPosition,
                Quaternion.identity
            );

            Weapon seed = newSeed.GetComponent<Weapon>();

            if (seed != null)
            {
                seeds.Add(seed);
            }
        }

        yield return new WaitForSeconds(1.5f);

        foreach (Weapon seed in seeds)
        {
            seed.Execute();
        }
            Boss1 boss = GetComponent<Boss1>();
            boss.finish = true;

    }
}