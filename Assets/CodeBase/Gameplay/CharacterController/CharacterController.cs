using CodeBase.Gameplay.InputProvider.Common;
using UnityEngine;

namespace CodeBase.Gameplay.CharacterController
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Rigidbody _rigidbody = null;
        
        public void ProvideInput(InputData data)
        {
            if (_rigidbody == null)
                _rigidbody = gameObject.GetComponent<Rigidbody>();
            
            Vector3 direction3D = new Vector3(data.MovementDirection.x, 0, data.MovementDirection.y);
            _rigidbody.velocity = direction3D.normalized * _speed * Time.deltaTime;
        }
    }
}