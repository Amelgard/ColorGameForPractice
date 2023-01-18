using System;
using ColorGame.Map;
using UnityEngine;

namespace ColorGame.Trails
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TrailCreator : MonoBehaviour
    {
        [SerializeField] private TrailRenderer trailPrefab;
        private SpriteRenderer _spriteRenderer;
        private Color _previousColor;
        private TrailRenderer _previousTrailSegment;
        private TrailRenderer _currentTrailSegment;
        private GameObject _oldSegmentsContainer;
        private bool _isNeedToDetachSegment;

        private void Start()
        {
            _oldSegmentsContainer = new GameObject("TrailContainer");
            _oldSegmentsContainer.transform.SetParent(transform, true);
            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _previousColor = _spriteRenderer.color;
        
            CreateTrailSegment(_previousColor, trailPrefab.endColor);
            
        }

        private void Update()
        {
            var currentColor = _spriteRenderer.color;
            if (currentColor != _previousColor)
            {
                CreateTrailSegment(currentColor, _previousColor);
                _previousColor = currentColor;
            }
            else if (_isNeedToDetachSegment)
            {
                DetachPreviousSegment();
            }
        }

        private void CreateTrailSegment(Color startColor, Color endColor)
        {
            _previousTrailSegment = _currentTrailSegment;

            _currentTrailSegment = Instantiate(trailPrefab, this.transform);

            _currentTrailSegment.startColor = startColor;
            _currentTrailSegment.endColor = endColor;
            
            _isNeedToDetachSegment = true;
        }

        private void DetachPreviousSegment()
        {
            if (!_previousTrailSegment) return;
            
            _previousTrailSegment.emitting = false;
            _previousTrailSegment.transform.parent = _oldSegmentsContainer.transform;
            
            _isNeedToDetachSegment = false;
        }
    }
}
