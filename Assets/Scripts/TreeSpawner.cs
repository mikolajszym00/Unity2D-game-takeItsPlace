using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> treePrefab;

    void Start()
    {
        SpawnTree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTree() 
    {
        Instantiate(treePrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
