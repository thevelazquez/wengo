using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bt1Clicked() {
        CloseMenu();
    }
    
    public void Bt2Clicked() {
        CloseMenu();
    }

    public void Bt3Clicked() {
        CloseMenu();
    }

    void CloseMenu() {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -100f, .2f);
    }
    //test
}
