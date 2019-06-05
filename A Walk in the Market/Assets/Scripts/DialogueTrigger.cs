// This object lets game developer type in dialogue in Unity as well
// as acting as a trigger to start dialogue

using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public int interactionNum;

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }

}
