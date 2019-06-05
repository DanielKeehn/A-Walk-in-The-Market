using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where all the data pertaining to dialogue is controlled 
//This command allows us to edit in Inspector in Unity
[System.Serializable]
public class Dialogue {

    public string characterName;
    
    [TextArea(3,10)]
    public string[] sentences;
}