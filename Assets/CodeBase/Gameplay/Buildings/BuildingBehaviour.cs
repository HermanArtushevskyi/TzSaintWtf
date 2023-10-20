using System.Collections;
using CodeBase.Factories.Interfaces;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.Inventory.Interfaces;
using CodeBase.Gameplay.Items;
using DG.Tweening;
using TNRD;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Buildings
{
    public class BuildingBehaviour : MonoBehaviour, IBuilding
    {
        public IStorage Storage => _storageObject.Value;
        public IStorage ProductsStorage => _productsStorageObject.Value;

        [SerializeField] private float _workTime = 1f;
        [SerializeField] private GameObject _outOfResourcesText;
        [SerializeField] private GameObject _storageIsFullText;
        [SerializeField] private Transform _stackPlace;
        [SerializeField] private SerializableInterface<IItem> _product;

        [SerializeField] private SerializableInterface<IStorage> _storageObject;
        [SerializeField] private SerializableInterface<IStorage> _productsStorageObject;

        private IFactory<GameObject, int, Vector3> _itemsFactory;
        private bool _isWorking = false;
        private WaitForSeconds _waitFor;

        private void Start()
        {
            _waitFor = new WaitForSeconds(_workTime);
        }

        [Inject]
        private void Construct(IFactory<GameObject, int, Vector3> itemsFactory)
        {
            _itemsFactory = itemsFactory;
        }

        private void FixedUpdate()
        {
            TryStartWorking();
        }

        private void TryStartWorking()
        {
            if (_isWorking)
            {
                _storageIsFullText.SetActive(false);
                _outOfResourcesText.SetActive(false);
                return;
            }
            if (!_storageObject.Value.HasNeededItems())
            {
                _storageIsFullText.SetActive(false);
                _outOfResourcesText.SetActive(true);
                return;
            }
            if (!_productsStorageObject.Value.HasSpace())
            {
                _storageIsFullText.SetActive(true);
                _outOfResourcesText.SetActive(false);
                return;
            }

            _storageObject.Value.ProcessItems();
            
            StartCoroutine(WorkCoroutine());
        }

        private IEnumerator WorkCoroutine()
        {
            _isWorking = true;
            yield return _waitFor;
            CreateProduct();
            _isWorking = false;
        }

        private void CreateProduct()
        {
            var product = _itemsFactory.Create(_product.Value.Tier, transform.position);
            product.transform.DOMove(_stackPlace.position, 0.5f);
            _storageObject.Value.ProcessItems();
            ProductsStorage.AddItem(product.GetComponent<ItemBehaviour>());
        }
    }
}