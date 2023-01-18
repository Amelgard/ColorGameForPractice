using UnityEngine;

namespace ColorGame.Map
{
    public abstract class IOffsetMover : MonoBehaviour
    {
        public abstract void Move(Vector3 offset);
    }
}
