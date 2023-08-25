using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] FloatingJoystick joystick;
    [SerializeField] float moveSpeed;
    [SerializeField] TextMeshProUGUI trashCountUI, coinCountUI;
    int trashOnHand, coins;
    Vector3 _Input;
    bool collectingTrash = false, depositingTrash = false;

    void Update() {
        GatherInput();
        Look();
    }
    void FixedUpdate() {
        Move();
    }

    void GatherInput() {
        //Simplify the inputs from the virtual joystick into a new vector3
        _Input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }

    void Look(){
        if (_Input != Vector3.zero) {
            //Vector3 that offsets the world input to match what appears on screen
            //and points towards the desired input vector.
            var relative = (transform.position + _Input.ToIso()) - transform.position;
            //Quaternion that calculates the next rotation for the character
            //relative to the y-axis.
            var rot = Quaternion.LookRotation(relative,Vector3.up);
            
            //Set the rotation of the character
            transform.rotation = rot;

        }
    }

    void Move() {
        //Moves the character forward relative to the magnitude of the input vector
        rb.MovePosition(transform.position + (transform.forward * _Input.magnitude) * moveSpeed * Time.deltaTime);
    }

    void OnTriggerStay (Collider obj) {
        TrashCounter tileTrash = obj.gameObject.GetComponent<TrashCounter>();
        if (tileTrash != null) {
            if (!collectingTrash) {
                collectingTrash = true;
                StartCoroutine(CollectTrash(tileTrash));
            }
        }
        if (obj.gameObject.name == "Sheebo") {
            if (!depositingTrash) {
                depositingTrash = true;
                StartCoroutine(DepositTrash());
            }
        }
    }

    IEnumerator DepositTrash() {
        yield return new WaitForSeconds(.2f);
        if (trashOnHand > 0) {
            trashOnHand--;
            coins++;
        }
        depositingTrash = false;
        UpdateUI();
    }

    IEnumerator CollectTrash(TrashCounter tileTrash) {
        yield return new WaitForSeconds(1f);
        tileTrash.loseTrash(transform.gameObject, 1);
        collectingTrash = false;
    }

    public void AddTrash(int amount) {
        trashOnHand += amount;
        UpdateUI();
    }

    void UpdateUI () {
        trashCountUI.text = "Trash: " + trashOnHand;
        coinCountUI.text = "Coins: " + coins;
    }
}
