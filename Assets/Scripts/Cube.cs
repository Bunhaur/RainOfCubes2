using System.Collections;
using UnityEngine;

public class Cube : PoolObject<Cube>
{
    private bool _canChangeColor;

    protected override void SetDefault()
    {
        base.SetDefault();

        _canChangeColor = true;
    }

    protected override void Init()
    {
        base.Init();

        _canChangeColor = true;
    }


    protected override IEnumerator StartLifeTime()
    {
        yield return Delay;

        DeadNotify();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Plane _plane) && _canChangeColor)
        {
            _canChangeColor = false;

            MeshRenderer.material.color = Random.ColorHSV();
            StartLifeTimeWork = StartCoroutine(StartLifeTime());
        }
    }
}