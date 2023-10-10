using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPoolManager : MonoBehaviour
{
    // 1. ObjectPoolManager �̱������� ����
    public static ObjectPoolManager instance;

    // 2. ������Ʈ Ǯ�� ����� ���� ������Ʈ�� ����
    [SerializeField] GameObject prefab;

    // 3. ������Ʈ Ǯ�� ����� (Queue) �����̳� ����
    private Queue<GameObject> queue = new Queue<GameObject>();
    int createCount = 5;

    void Start()
    {
        // 1. �̱��� ����
        if(instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 2. ���� ������Ʈ ����
        for (int i = 0; i < createCount; i++)
        {
            GameObject bullet = Instantiate(prefab);


            // 3. Queue �����̳ʿ� ������ ����
            queue.Enqueue(bullet);

            // 4. ���� ������Ʈ ��Ȱ��ȭ
            bullet.SetActive(false);
        }
    }

    public void InsertQueue(GameObject bullet)
    {
        queue.Enqueue(bullet);
        bullet.SetActive(false);
    }

    public GameObject GetQueue(Vector3 createPosition)
    {
        GameObject bullet = queue.Dequeue();

        bullet.transform.position = createPosition;
        bullet.SetActive(true);

        return bullet;
    }
}
