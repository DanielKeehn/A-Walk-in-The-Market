//This class is instantiated for each character the player can interact with. This code checks
// what interaction a player is on with a certain character, and increments to setup for the 
//next interaction.

using UnityEngine;

public class CharacterDialogueManager: MonoBehaviour {

    private int interactionNum = 1;

    public void interactWithCharacter() {
        DialogueTrigger[] characterInteractions = this.GetComponentsInChildren<DialogueTrigger>();
        foreach (DialogueTrigger interaction in characterInteractions) {
            if (interactionNum == interaction.interactionNum) {
                interaction.TriggerDialogue();
            }
        }
        interactionNum++;
    }
	
}
