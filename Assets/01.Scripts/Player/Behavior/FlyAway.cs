using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : SettingDirection
{
    public override void SetupDirection()
    {
        StartCoroutine(BehaviourCoroutine());
    }
    public override void OnCollisionTarget()
    {
        isStopMovement = true;
        StartCoroutine(BehaviourCoroutine());
    }

    private IEnumerator BehaviourCoroutine()
    {
        float startTime = Time.time;

        while(Time.time - startTime < 1f)
        {
            //TODO: ������ ������ ����
            yield return null;
        }

        isStopMovement = false;
    }
}
