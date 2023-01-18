using System.Collections;
using UnityEngine;

namespace ColorGame.Map
{
    public class OffsetTracker : MonoBehaviour
    {
        [SerializeField] private float period = 20f;

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > 20f)
            {
                StartCoroutine(nameof(Move));
            }
        }

        private IEnumerator Move()
        {
            foreach (var mover in FindObjectsOfType<IOffsetMover>())
            {
                mover.Move(Vector3.down * period);
            }
            
            yield break;
        }
    }
}
