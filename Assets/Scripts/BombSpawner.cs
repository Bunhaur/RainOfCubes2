using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Pool<Cube> _cubes;

    private void OnEnable()
    {
        _cubes.Dead += Create;
    }

    private void Create(Vector3 position)
    {
        Pool.StartPolling(position);
    }
}