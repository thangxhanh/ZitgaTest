using UnityEngine;

public class Tilemap : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;

    public void Spawn(int count = 20)
    {
        for (int i = 1; i <= count; ++i)
        {
            pool.Spawn().GetComponent<Character>().Init();
        }
    }
}
