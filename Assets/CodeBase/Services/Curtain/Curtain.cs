using System;
using UnityEngine;

namespace CodeBase.Services.Curtain
{
    public class Curtain
    {
        public event Action OpenStarted;
        public event Action OpenFinished;
        public event Action CloseStarted;
        public event Action CloseFinished;

        private GameObject _curtainPrefab;

        public Curtain(GameObject curtainPrefab)
        {
            if (!curtainPrefab.TryGetComponent<CurtainBehaviour>(out _))
                throw new ArgumentException("Curtain prefab has no CurtainBehaviour component");
            
            _curtainPrefab = curtainPrefab;
        }

        public CurtainBehaviour Open()
        {
            GameObject curtainGO = GameObject.Instantiate(_curtainPrefab);
            CurtainBehaviour curtain = curtainGO.GetComponent<CurtainBehaviour>();
            
            curtain.OpenStarted += () => OpenStarted?.Invoke();
            curtain.OpenFinished += () => OpenFinished?.Invoke();
            
            curtain.Open();
            return curtain;
        }

        public CurtainBehaviour Close()
        {
            GameObject curtainGO = GameObject.Instantiate(_curtainPrefab);
            CurtainBehaviour curtain = curtainGO.GetComponent<CurtainBehaviour>();
            
            curtain.CloseStarted += () => CloseStarted?.Invoke();
            curtain.CloseFinished += () => CloseFinished?.Invoke();
            
            curtain.Close();
            return curtain;
        }
    }
}