using ColorGame.Map;
using UnityEngine;

[RequireComponent(typeof(Map))]
public class MapOffsetMover : IOffsetMover
{
    private Map _map;
    private void Start()
    {
        _map = GetComponent<Map>();
    }

    public override void Move(Vector3 offset)
    {
        _map.MakeSegmentsReposition(offset);
    }
}
