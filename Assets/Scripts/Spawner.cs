using UnityEngine;

public abstract class Spawner<T>: MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] protected Pool<T> Pool;
}