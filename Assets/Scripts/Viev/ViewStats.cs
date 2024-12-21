using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class ViewStats : MonoBehaviour
{
    [SerializeField] protected string NameView;
    [SerializeField] protected Pool<Cube> Cubes;
    [SerializeField] protected Pool<Bomb> Bombs;

    private TextMeshProUGUI Text;

    private int _count;

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    protected void Show(int value)
    {
        _count += value;
        Text.text = ($"{NameView}: {_count}");
    }
}