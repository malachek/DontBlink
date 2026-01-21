using NUnit.Framework;
using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawningObjects;

    [SerializeField] float spawnInterval = 1.5f;
    float acceleration;
    public void SpawnObjects()
    {
        acceleration = spawnInterval / spawningObjects.Length;
        SpawnObject();
    }
    int currDrawingIndex = 0;
    private void SpawnObject()
    {
        spawningObjects[currDrawingIndex].SetActive(true);
        if(++currDrawingIndex >= spawningObjects.Length) return;
        Invoke(nameof(SpawnObject), spawnInterval + .5f - (acceleration * currDrawingIndex));
    }
}
