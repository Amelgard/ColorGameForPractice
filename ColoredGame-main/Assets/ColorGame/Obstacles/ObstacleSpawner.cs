using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace ColorGame.Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        public SpriteRenderer[] obstaclePrefabs;
        public Color[] availableColors;
        public int obstacleLimit;
        public float spawnTimer;
        private Random _random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

        private void Start()
        {
            SpawnObstacles();
        }

        public void SpawnObstacles()
        {
            if (!obstaclePrefabs.Any() || transform.childCount >= obstacleLimit) return;
            
            for(var y = -4; y <= 4; y += 2 )
            {
                var obstacleType = _random.Next(0, obstaclePrefabs.Length);
                var obstacleColor = _random.Next(0, availableColors.Length);

                var obstacle = Instantiate(obstaclePrefabs[obstacleType], this.transform);

                obstacle.color = availableColors[obstacleColor];

                var obstaclePos = obstacle.transform.position;

                obstaclePos.x = _random.Next(-2, 2);
                obstaclePos.y = transform.parent.position.y + y;

                obstacle.transform.position = obstaclePos;
            }
        }
    }
}
