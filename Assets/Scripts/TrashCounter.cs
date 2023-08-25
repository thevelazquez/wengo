using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    [SerializeField] int minTrashSpawn = 1, maxTrashSPawn = 5;
    [SerializeField] GameObject countUI;
    TMP_Text countText;
    Tile tile;
    bool hasTrash = false;
    int trashCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        tile = transform.gameObject.GetComponent<Tile>();
        UpdateUI();
    }

    public void loseTrash(GameObject playerRef, int amount = 1) {
        PlayerControls player;
        player = playerRef.GetComponent<PlayerControls>();
        if (hasTrash) {
            if (trashCount <= amount) {
                player.AddTrash(trashCount);
                trashCount = 0;
                hasTrash = false;
                UpdateUI();
                return;
            }
            trashCount -= amount;
            player.AddTrash(amount);
            UpdateUI();
        }
    }
    
    public void GetTrash() {
        hasTrash = true;
        trashCount += Random.Range(minTrashSpawn, maxTrashSPawn);
        UpdateUI();
    }
    public bool HasTrash() {
        return hasTrash;
    }
    public int TrashCount() {
        return trashCount;
    }

    void UpdateUI() {
        countText = countUI.GetComponent<TMP_Text>();
        countText.text = trashCount + "";
    }
}
