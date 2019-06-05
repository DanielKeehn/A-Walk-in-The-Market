// The Dialogue Manager displays the sentences in the dialogue object. The dialogue manager also
// checks if all the sentences in a dialogue object have been shown on screen and ends and interaction
// if neccesary.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


    //The datatype holding all the dialogue 
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
    } 

    public void StartDialogue(Dialogue dialogue) {

        animator.SetBool("IsOpen", true);   
        sentences.Clear();
        nameText.text = dialogue.characterName;
        if (dialogue.characterName == "Old Man")
        {
            animator.SetInteger("Player", 1);
        }
        else if (dialogue.characterName == "Fisherman") 
        {
            animator.SetInteger("Player", 2);
        }
        else if (dialogue.characterName == "Musician")
        {
            animator.SetInteger("Player", 3);
        }
        else if (dialogue.characterName == "Buisnessman")
        {
            animator.SetInteger("Player", 4);
        }
        else if (dialogue.characterName == "Kid")
        {
            animator.SetInteger("Player", 5);
        }
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        animator.SetInteger("Player", 0);
        GameObject.Find("InteractionsManager").GetComponent<InteractionsManager>()
            .decrementIneractionsLeft();
    }
}
