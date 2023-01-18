using System;
using UnityEngine;

namespace ColorGame.Map
{
    public class MapCleaner : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
            
            Console.Write("Deleted");
        }
    }
}
