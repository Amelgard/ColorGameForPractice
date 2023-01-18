using System.Collections;
using System.Collections.Generic;
using ColorGame.Map;
using UnityEngine;

public class PlayerOffsetMover : IOffsetMover
{
    public override void Move(Vector3 offset)
    {
        transform.position += offset;
    }
}
