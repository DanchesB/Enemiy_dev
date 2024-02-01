using System.Collections.Generic;
using UnityEngine;

public class EnemyPool<TComponent> where TComponent : Component
{
    private List<TComponent> pool;
    private TComponent prefab;
    private Transform container;

    //???????? ????
    public EnemyPool(TComponent prefab, int poolSize, Transform container)
    {
        this.prefab = prefab;
        pool = new List<TComponent>();
        this.container = container;

        for (int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }
    }

    public TComponent GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                pool[i].gameObject.SetActive(true);
                Debug.Log("?????? ???? ?? ????" + pool[i]);
                return pool[i];
            }
        }
        return CreateObject();
    }

    public void ReturnObject(TComponent obj)
    {
        obj.gameObject.SetActive(false);
    }

    //???????? ?????? ? ????
    private TComponent CreateObject()
    {
        TComponent newObj = Object.Instantiate(prefab);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(container);
        pool.Add(newObj);
        Debug.Log("?????? ???????? ? ??? " + newObj.name);
        return newObj;
    }
}