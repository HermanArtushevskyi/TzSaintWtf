using System;
using UnityEngine;

namespace CodeBase.Services.UnityContext
{
    public interface IUpdateCallback
    {
        public event Action OnUpdate;
    }
}