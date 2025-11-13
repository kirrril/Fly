using System.Collections;
using UnityEngine;

public class ParticlesLauncher : MonoBehaviour
{
    private ParticlePool particlePool;
    [SerializeField] private string poolName;
    private ParticleSystem ps;

    private void OnEnable()
    {
        particlePool = GameObject.Find(poolName).GetComponent<ParticlePool>();
    }

    private void Update()
    {
        if (ps != null)
        {
            ps.transform.position = transform.position;
        }
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

    private void OnDestroy()
    {
        if (ps != null)
        {
            particlePool.Return(ps);
        }
    }
}
