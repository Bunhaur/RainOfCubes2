using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] protected T Prefab;

    [SerializeField] private int _maxCapacity;

    private Queue<T> _pool = new Queue<T>();
    private T _tempObject;

    public event Action<Vector3> Dead;
    public event Action<int> Created;
    public event Action<int> Spawned;
    public event Action<int> ActiveChanged;


    private void Awake()
    {
        CreateObjects(_maxCapacity);
    }

    public void StartPolling(Vector3 position)
    {
        if (_pool.Count == 0)
            CreateObjects(1);

        Activate(position);
    }

    public float GetScaleX()
    {
        return transform.localScale.x;
    }

    private void Activate(Vector3 position)
    {
        _tempObject = _pool.Dequeue();
        _tempObject.transform.position = position;
        _tempObject.SetActiveObject(true);
        Spawned?.Invoke(1);
        ActiveChanged?.Invoke(1);
    }

    private void Diactivate(T poolObject)
    {
        Dead?.Invoke(poolObject.transform.position);
        poolObject.SetActiveObject(false);
        _pool.Enqueue(poolObject);
        ActiveChanged?.Invoke(-1);
    }

    private void CreateObjects(int count)
    {
        T newObject;

        for (int i = 0; i < count; i++)
        {
            newObject = Instantiate(Prefab, Vector3.zero, Quaternion.identity, transform);
            newObject.Dead += Diactivate;

            Created?.Invoke(1);
            _pool.Enqueue(newObject);
        }
    }
}