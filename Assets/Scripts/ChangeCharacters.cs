using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacters : MonoBehaviour {

    // All characters
    public GameObject CharacterNapoleon;
    public GameObject CharacterDali;

    // For debug
    public GameObject CharacterAction;
    public bool activeObject = true;

    // Start is called before the first frame update
    void Start() {
        this.activeObject = true;
    }

    private void toggleVisibilityCharacter(GameObject character) {

        for (int i = 0; i < character.gameObject.transform.childCount; ++i) {
            Transform currentObject = character.gameObject.transform.GetChild(i);
            currentObject.gameObject.SetActive(!currentObject.gameObject.activeSelf);
        }
    }

    // Update is called once per frame
    void Update() {
        this.toggleVisibilityCharacter(CharacterAction);
    }
}
