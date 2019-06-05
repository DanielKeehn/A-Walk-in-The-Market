//This class first checks if the dialogue box is open. If the dialogue box is open and the player presses
// the space bar, the next setence in the dialogue object appears because of this code

using UnityEngine;

public class ContinueDialogue : MonoBehaviour {

	void Update () {
        if (GameObject.Find("DialogueBox").GetComponent<Animator>().GetBool("IsOpen") == true) {
            if (Input.GetButtonDown("Continue")) {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }
}
