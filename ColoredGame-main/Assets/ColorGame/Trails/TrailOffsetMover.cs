using System.Collections;
using System.Collections.Generic;
using ColorGame.Map;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailOffsetMover : IOffsetMover
{
    private TrailRenderer _trailRenderer;
    private bool _isShouldBeDestroyed = false;
    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public override void Move(Vector3 offset)
    {
        if(_isShouldBeDestroyed)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);

            var positionCount = _trailRenderer.positionCount;
            for (var i = 0; i < positionCount; i++)
            {
                _trailRenderer.SetPosition(i, _trailRenderer.GetPosition(i) + offset);
            }

            gameObject.SetActive(true);

            _isShouldBeDestroyed = !transform.parent.TryGetComponent(typeof(OffsetTracker),
                                                                    out var tracker);
        }
    }
}
