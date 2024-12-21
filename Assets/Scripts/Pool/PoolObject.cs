using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public abstract class PoolObject<T> : MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] private float _minLifeTime;
    [SerializeField] private float _maxLifeTime;

    protected float LifeTime;
    protected Coroutine StartLifeTimeWork;
    protected WaitForSeconds Delay;
    protected MeshRenderer MeshRenderer;

    private Rigidbody _rigidBody;
    private Quaternion _quanternion;
    private Color _defaultColor;

    public event Action<T> Dead;

    private void Awake()
    {
        Init();
    }

    private void OnDisable()
    {
        SetDefault();
    }

    public void SetActiveObject(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    protected virtual IEnumerator StartLifeTime()
    {
        yield return null;
    }

    protected virtual void Init()
    {
        SetLifeTime();

        MeshRenderer = GetComponent<MeshRenderer>();
        _rigidBody = GetComponent<Rigidbody>();

        Delay = new WaitForSeconds(LifeTime);

        _quanternion = transform.rotation;
        _defaultColor = MeshRenderer.material.color;

        gameObject.SetActive(false);
    }

    protected virtual void SetDefault()
    {
        transform.rotation = _quanternion;
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
        MeshRenderer.material.color = _defaultColor;
    }

    protected void DeadNotify()
    {
        Dead?.Invoke((T)this);
        gameObject.SetActive(false);
    }

    private void SetLifeTime()
    {
        LifeTime = GetRandom(_minLifeTime, _maxLifeTime);
    }

    private float GetRandom(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}