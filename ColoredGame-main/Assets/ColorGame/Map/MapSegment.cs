using ColorGame.Obstacles;
using UnityEngine;

namespace ColorGame.Map
{
    public class MapSegment : MonoBehaviour
    {
        [SerializeField] private ObstacleSpawner obstacleSpawner;
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer wall;
        private SpriteRenderer _leftWall;
        private SpriteRenderer _rightWall;
    
        private void Start()
        {
            obstacleSpawner = Instantiate(obstacleSpawner, transform);
            background = Instantiate(background, transform);
            _leftWall = Instantiate(wall, transform);
            _rightWall = Instantiate(wall, transform);
        
            _leftWall.transform.localPosition = Vector3.left * 3f;
            _rightWall.transform.localPosition = Vector3.right * 3f;
        }

        private void OnBecameInvisible()
        {
            Destroy(this);
        }
    }
}
