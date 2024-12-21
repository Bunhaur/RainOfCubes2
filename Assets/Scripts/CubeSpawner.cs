using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Vector3 _spawnPoint;

    private float _half = 2;
    private float _xPosition;
    private float _yPosition;
    private float _zPosition;
    private float _offset;

    private void Start()
    {
        Init();

        InvokeRepeating(nameof(Repeat), 0f, 1f);
    }

    private void Init()
    {
        _offset = Pool.GetScaleX() / _half;
    }

    private void Repeat()
    {
        Pool.StartPolling(GetSpawnPosition());
    }

    private Vector3 GetSpawnPosition()
    {
        _xPosition = GetRandomValue(-_spawnPoint.x, _spawnPoint.x);
        _yPosition = _spawnPoint.y;
        _zPosition = GetRandomValue(-_spawnPoint.z, _spawnPoint.z);

        return new Vector3(_xPosition, _yPosition, _zPosition);
    }

    private float GetRandomValue(float min, float max)
    {
        return Random.Range(min + _offset, max - _offset);
    }
}