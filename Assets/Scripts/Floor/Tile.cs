using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    int contaminatedChance = 3;
    Material tileMat;
    Color contaminated = Color.red;
    Color originalColor;
    TrashCounter trashCounter;

    // Start is called before the first frame update
    void Start()
    {
        tileMat = GetComponent<Renderer>().material; 
        trashCounter = transform.GetChild(0).GetComponent<TrashCounter>();
        originalColor = tileMat.GetColor("_BaseColor");
        RollContamination();
    }

    void RollContamination() {
        int roll;
        roll = Random.Range(1, contaminatedChance);
        if (roll == 1) {
            trashCounter.GetTrash();
            tileMat.SetColor("_BaseColor",Color.red);
            return;
        }
    }

    public void AllClean() {
        tileMat.SetColor("_BaseColor", originalColor);
    }
}
