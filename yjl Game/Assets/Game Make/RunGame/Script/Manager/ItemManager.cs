using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<GameObject> items;

    private void Start()
    {
        items.Capacity = 10;
    }

    public GameObject CloneItem()
    {
        return items[Random.Range(0, items.Count)];
    }
}
