using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bomb))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private int _radius;
    [SerializeField] private float _force;

    private Bomb _bomb;
    private Quaternion _rotationEffect;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _bomb.Exploded += BlowUp;
    }

    private void OnDisable()
    {
        _bomb.Exploded -= BlowUp;
    }

    private void Init()
    {
        _bomb = GetComponent<Bomb>();
        _rotationEffect = _effect.transform.rotation;
    }

    private void BlowUp()
    {
        Instantiate(_effect, transform.position, _rotationEffect);

        foreach (Rigidbody sphere in GetExplosionObjects(_radius))
            sphere.AddExplosionForce(_force, transform.position, _radius);
    }

    private List<Rigidbody> GetExplosionObjects(int radius)
    {
        Collider[] hits;
        List<Rigidbody> objects = new List<Rigidbody>();

        hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}