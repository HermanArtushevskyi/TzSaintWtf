using System;
using UnityEngine;

namespace CodeBase.Services.UnityContext
{
    public interface IFixedUpdateCallback
    {
        public event Action OnFixedUpdate;
    }
}