using System.Collections.Generic;
using CodeBase.Gameplay.Items;
using UnityEngine;

namespace CodeBase.Gameplay.Inventory
{
    public class ItemsStack : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        private LinkedList<GameObject> _objects = new();
        
        public LinkedListNode<GameObject> Add(GameObject itemObject)
        {
            if (_objects.Count == 0)
            {
                itemObject.transform.parent = _startPosition;
            }
            else
            {
                itemObject.transform.parent = _objects.Last.Value.GetComponent<ItemBehaviour>().topAnchor;
            }

            return _objects.AddLast(itemObject);
        }
        
        public void Remove(GameObject itemObject)
        {
            LinkedListNode<GameObject> node = _objects.FindLast(itemObject);
            if (node == null) return;

            node.Value.transform.parent = null;
            
            if (node.Next != null && node.Previous != null)
            {
                node.Next.Value.transform.parent = node.Previous.Value.GetComponent<ItemBehaviour>().topAnchor;
                node.Next.Value.transform.position = Vector3.zero;
            }

            _objects.Remove(node);
        }

        public void Remove(LinkedListNode<GameObject> node)
        {
            if (node == null) return;
            node.Value.transform.SetParent(null);
            
            if (node.Next != null && node.Previous != null)
            {
                node.Next.Value.transform.parent = node.Previous.Value.GetComponent<ItemBehaviour>().topAnchor;
                node.Next.Value.transform.position = Vector3.zero;
            }
            _objects.Remove(node);
        }
    }
}