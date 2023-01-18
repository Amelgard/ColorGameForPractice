using System;
using UnityEngine;

namespace ColorGame.Map
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MapSegment[] availableSegments;
        private MapSegment[] _activeSegments;
        void Start()
        {
            _activeSegments = new MapSegment[]
            {
                CreateMapSegment(-10f),
                CreateMapSegment(0f),
                CreateMapSegment(10f),
                CreateMapSegment(20f)
            };
            
        }
        public void MakeSegmentsReposition(Vector3 offset)
        {
            foreach (var segment in _activeSegments)
            {
                segment.transform.localPosition += offset;
            }

            Destroy(_activeSegments[0].gameObject);
            Destroy(_activeSegments[1].gameObject);

            _activeSegments[0] = _activeSegments[2];
            _activeSegments[1] = _activeSegments[3];

            _activeSegments[2] = CreateMapSegment(10f);
            _activeSegments[3] = CreateMapSegment(20f);
        }

        MapSegment CreateMapSegment(float y)
        {
            var segment = Instantiate(availableSegments[0], transform);
            segment.transform.localPosition = Vector3.up * y;

            return segment;
        }
    }
}
