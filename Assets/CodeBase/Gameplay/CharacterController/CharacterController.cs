using System;
using UnityEngine;

namespace CodeBase.Gameplay.CharacterController
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        #if UNITY_EDITOR
        [SerializeField] private Vector2 _direction;
        #endif
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Move(Vector2 direction)
        {
            Vector3 direction3D = new Vector3(direction.x, 0, direction.y);
            _rigidbody.velocity = direction3D.normalized * _speed * Time.deltaTime;
        }
        
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, _direction);
        }

        private void FixedUpdate()
        {
            Move(_direction);
        }
        #endif
    }
}