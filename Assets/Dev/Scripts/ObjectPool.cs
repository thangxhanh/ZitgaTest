using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private int count;
    [SerializeField] private int maxCount;
    [SerializeField] private SpriteRenderer tilemap;
    [SerializeField] private List<GameObject> pooledGobjects;

    private float unit;

    void Awake()
    {
        pooledGobjects = new List<GameObject>();
        unit = tilemap.size.x / 27;

        for (int i = 0; i < count; ++i)
            pooledGobjects.Add(CreateGobject(gameObj));
    }

    public GameObject Spawn() {
        GameObject obj;
        if (pooledGobjects.Count != 0)
        {
            obj = pooledGobjects[0];
            pooledGobjects.RemoveAt(0);
        }
        else
        {
            obj = CreateGobject(gameObj);
        }
        
        obj.SetActive(true);
        return obj;
    }

    GameObject CreateGobject(GameObject item) {
        GameObject gobject = Instantiate(item, transform);
        gobject.GetComponent<Character>().unit = unit;
        gobject.SetActive(false);
        return gobject;
    }

    public void Disable(GameObject item)
    {
        item.SetActive(false);
        if (pooledGobjects.Count >= maxCount)
        {
            Destroy(item);
            return;
        }
        pooledGobjects.Add(item);
    }
}