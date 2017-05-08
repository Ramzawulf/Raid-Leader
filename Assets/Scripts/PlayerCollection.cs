using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection:MonoBehaviour
{
    private List<Character> characters;
    public Character _activeCharacter;
    public Character ActiveCharacter
    {
        get {
            return _activeCharacter;
        }
        set {
            if (value ==null) {
                _activeCharacter = value;
                OnCharacterDeselected();
            }else if (characters != null) {
                if (characters.Contains(value))
                {
                    _activeCharacter = value;
                    OnCharacterSelected();
                }
            }
                }
    }
    public delegate void CharacterSelectionAction();
    public CharacterSelectionAction OnCharacterSelected;
    public CharacterSelectionAction OnCharacterDeselected;

    void Awake()
    {
        characters = new List<Character>();
    }

    public void AddPlayer(Character newCharacter) {
        if (!characters.Contains(newCharacter))
        {
            characters.Add(newCharacter);
            newCharacter.transform.SetParent(transform);
        }
    }
}