//This class gets all the transforms of the characters the player interacts with. If a player is close 
// enough to an NPC, they can press shift which will cause dialogue to be triggered 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDetectNPC : MonoBehaviour {

    private float distance;
    public float distanceToTriggerDialogue; //how close a player must be to be able to interact with character
    private Transform[] charactersTransformArray;
    private GameObject characters;

    public void Start()
    {
        characters = GameObject.Find("Characters"); //parent object for all characters
        charactersTransformArray = characters.GetComponentsInChildren<Transform>();
    }

    //iterates through all the characters transforms
    void Update () {
        if (GameObject.Find("DialogueBox").GetComponent<Animator>().GetBool("IsOpen") == false) {
            foreach (Transform characterTransform in charactersTransformArray) {
                distance = Vector3.Distance(characterTransform.position, transform.position);
                if (distance < distanceToTriggerDialogue)
                {
                    if (Input.GetButtonDown("Talk"))
                    {
                        //This deals with stopping the walking animation
                        GameObject.Find("Player").GetComponent<PlayerMovement>()
                            .setStopAnimation(true);
                        CharacterDialogueManager characterDialogueManager = characterTransform.
                            gameObject.GetComponent<CharacterDialogueManager>();
                        characterDialogueManager.interactWithCharacter();
                    }
                }
            }
        }
	}
}