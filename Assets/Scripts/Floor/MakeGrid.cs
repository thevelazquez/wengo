using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGrid : MonoBehaviour
{
    [SerializeField] int width = 10, length = 10;
    [SerializeField] float padding = 1;
    public GameObject tile, tileContainer;

    // Start is called before the first frame update
    void Start() {
        InstantiateTiles();
    }
    
    void InstantiateTiles() {
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < length; z++) {
                Instantiate(tile, new Vector3(x * padding,0,z * padding), Quaternion.identity, tileContainer.transform);
            }
        }
    }
}
