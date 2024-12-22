using TMPro;
using UnityEngine;

public abstract class Informer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI Text;

    protected string InformerName;
    protected int Count;

    private void Start()
    {
        Show(0);
    }

    public void Show(int value)
    {
        Count += value;
        Text.text = $"{InformerName}: {Count}";
    }
}