using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDistructEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Coroutine _destroyAfterTimeWork;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        _destroyAfterTimeWork = StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        float time = _particleSystem.main.duration;
        WaitForSeconds delay = new WaitForSeconds(time);

        yield return delay;

        Destroy(gameObject);
    }
}
