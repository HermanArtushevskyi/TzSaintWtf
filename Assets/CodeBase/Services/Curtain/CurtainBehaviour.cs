using System;
using UnityEngine;

namespace CodeBase.Services.Curtain
{
    public class CurtainBehaviour : MonoBehaviour
    {
        public event Action OpenStarted;
        public event Action OpenFinished;
        public event Action CloseStarted;
        public event Action CloseFinished;

        private Animator _animator;

        private static readonly int OpenHash = Animator.StringToHash("Open");
        private static readonly int CloseHash = Animator.StringToHash("Close");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Open() => _animator.Play(OpenHash);

        public void Close() => _animator.Play(CloseHash);

        public void Destroy() => Destroy(gameObject);
    }
}