using System;
using System.Collections;
using UnityEngine;

public class Bomb : PoolObject<Bomb>
{
    public event Action Exploded;

    private void OnEnable()
    {
        StartLifeTimeWork = StartCoroutine(StartLifeTime());
    }

    protected override IEnumerator StartLifeTime()
    {
        Color tempColor = MeshRenderer.material.color;
        float alpha = tempColor.a;

        while (alpha != 0)
        {
            alpha = Mathf.MoveTowards(alpha, 0, Time.deltaTime / LifeTime);
            tempColor.a = alpha;
            MeshRenderer.material.color = tempColor;

            yield return null;
        }

        Exploded?.Invoke();
        DeadNotify();
    }
}