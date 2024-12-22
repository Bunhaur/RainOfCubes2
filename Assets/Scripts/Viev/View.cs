using UnityEngine;

public abstract class View<T> : MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] protected Pool<T> Pool;
    [SerializeField] protected SpawnedObjectsInformer SpawnedObjects;
    [SerializeField] protected CreatedObjectsInformer CreatedObjects;
    [SerializeField] protected ActiveObjjectsInformer ActivedObjjects;

    private void OnEnable()
    {
        Pool.Spawned += SpawnedObjects.Show;
        Pool.Created += CreatedObjects.Show;
        Pool.ActiveChanged += ActivedObjjects.Show;
    }

    private void OnDisable()
    {
        Pool.Spawned -= SpawnedObjects.Show;
        Pool.Created -= CreatedObjects.Show;
        Pool.ActiveChanged -= ActivedObjjects.Show;
    }
}