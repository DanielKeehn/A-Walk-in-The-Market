using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsManager : MonoBehaviour {

    public int interactionsLeft;
    public Text interactionsUI;

    private void Start()
    {
        interactionsUI.text = interactionsLeft.ToString();
    }

    public void UpdateInteractions() {
        interactionsUI.text = interactionsLeft.ToString();
        if (interactionsLeft == 0) {
            FindObjectOfType<GameManager>().goToNextDay();
        }
     }

    public void decrementIneractionsLeft() {
        interactionsLeft--;
        UpdateInteractions();
    }
}
