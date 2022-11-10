using System.Collections.Generic;
using UnityEngine;
using Creators;

public class Pool
{

    private List<GameObject> items;

    private CreatorBase _creator;

    private int _count = 1;

    public Pool(CreatorBase creator , int count)
    {
        items = new List<GameObject>();

        _creator = creator;

        _count = count;

        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _count; i++)
        {
            items.Add(CreateItem());
        }
    }

    private GameObject CreateItem()
    {
        GameObject item = _creator.Create();

        item.SetActive(false);

        return item;
    }

    public GameObject GetFreeItem()
    {
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                if (!item.activeInHierarchy)
                {
                    return item.gameObject;
                }
            }
        }

        GameObject newObject = CreateItem();

        items.Add(newObject);

        return newObject;
    } 

    public GameObject[] GetActiveItems()
    {
        if (items.Count > 0)
        {
            List<GameObject> gameObjectsActive = items.FindAll(i => i.activeInHierarchy);

            return gameObjectsActive.ToArray();
        }

        throw new System.Exception($"Pool is emty {this.ToString()}");
    }
}
