using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private List<Character> characters;
    public int Size
    {
        get
        {
            if (characters != null)
                return characters.Count;
            return -1;
        }
    }

    void Awake()
    {
        characters = new List<Character>();
    }

    public void AddPlayer(Character newCharacter)
    {
        if (!characters.Contains(newCharacter))
        {
            characters.Add(newCharacter);
            newCharacter.transform.SetParent(transform);
        }
    }

    public Character this[int index]
    {
        get
        {

            if (index >= 0 && index < characters.Count)
            {
                return characters[index];
            }
            return null;
        }
        set
        {
            if (index >= 0 && index < characters.Count)
            {
                characters[index] = value;
            }
        }
    }
}