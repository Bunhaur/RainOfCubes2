public class ViewCreaterObjects : ViewStats
{
    private void OnEnable()
    {
        Cubes.Created += Show;
        Bombs.Created += Show;
    }

    private void OnDisable()
    {
        Cubes.Created -= Show;
        Bombs.Created -= Show;
    }
}