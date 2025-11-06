using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private ParticleSystem particlePrefab;
    [SerializeField] private int poolSize;
    private Queue<ParticleSystem> pool = new();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var ps = Instantiate(particlePrefab, transform);
            ps.gameObject.SetActive(false);
            pool.Enqueue(ps);
        }
    }
    public ParticleSystem Get(Vector3 position)
    {
        if (pool.Count == 0) return null;
        var ps = pool.Dequeue();
        ps.transform.position = position;
        ps.gameObject.SetActive(true);
        ps.Play();
        return ps;
    }

    public void Return(ParticleSystem ps)
    {
        ps.Stop();
        ps.gameObject.SetActive(false);
        pool.Enqueue(ps);
    }
}
