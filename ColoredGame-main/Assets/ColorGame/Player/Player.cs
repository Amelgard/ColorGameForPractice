using System;
using System.Linq;
using UnityEngine;

namespace ColorGame.Player
{
    public class Player : MonoBehaviour
    {
        public Action<Color> OnColorChange;
        [SerializeField]private Camera currentCamera;
        [SerializeField]private float ySpeed = 5;
        [SerializeField]private float xSpeed = 50;

        public float health = 100f;
        private Rigidbody2D _rb;
        public Vector2 Velocity { get; private set; }
        private SpriteRenderer _sprite;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            CheckTouches();
            SyncCamera();

            if (_rb.velocity != Velocity)
            {
                _rb.velocity = Velocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Velocity = Vector2.Reflect(Velocity, other.contacts[0].normal);
                _rb.velocity = Velocity;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Color Changer"))
            {
                var colorChangerSprite = other.gameObject.GetComponent<SpriteRenderer>();
            
                ChangeColor(colorChangerSprite.color);
                Destroy(other.gameObject);

                if (colorChangerSprite.color == Color.black)
                {
                    health -= 25;
                }
                else 
                {
                    health += 10;
                    if (health > 100) 
                    {
                        health = 100;
                    }
                    
                }
            }
        }

        private void CheckTouches()
        {

            if (Input.touches.Any())
            {
                var direction = (Vector2) (currentCamera.ScreenToWorldPoint(Input.touches[0].position)
                                           - transform.position);

                Velocity = new Vector2(Mathf.Clamp(direction.x,-1, 1) * xSpeed, ySpeed);
                _rb.velocity = Velocity;
            }
        }

        void SyncCamera()
        {
            var cameraPosition = currentCamera.transform.position;
            cameraPosition.y = transform.position.y;
        
            currentCamera.transform.position = cameraPosition;
        }

        private void ChangeColor(Color color)
        {
            _sprite.color = color;
            
            OnColorChange?.Invoke(color);
        }
    }
}
