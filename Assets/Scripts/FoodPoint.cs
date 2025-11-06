using System.Collections;
using UnityEngine;

public class FoodPoint : MonoBehaviour
{
    private ParticlePool particlePool;
    [SerializeField] private string poolName;
    private ParticleSystem ps;

    private void OnEnable()
    {
        particlePool = GameObject.Find(poolName).GetComponent<ParticlePool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ps = particlePool.Get(transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (ps != null)
        {
            particlePool.Return(ps);
        }

    }
}
