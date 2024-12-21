public class ViewActiveObjects : ViewStats
{
    private void OnEnable()
    {
        Cubes.ActiveChanged += Show;
        Bombs.ActiveChanged += Show;
    }

    private void OnDisable()
    {
        Cubes.ActiveChanged -= Show;
        Bombs.ActiveChanged -= Show;
    }
}