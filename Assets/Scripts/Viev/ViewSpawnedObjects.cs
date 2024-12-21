public class ViewSpawnedObjects : ViewStats
{
    private void OnEnable()
    {
        Cubes.Spawned += Show;
        Bombs.Spawned += Show;
    }

    private void OnDisable()
    {
        Cubes.Spawned -= Show;
        Bombs.Spawned -= Show;
    }
}