using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterList", menuName = "CharacterList")]
public class CharacterList : ScriptableObject
{
    public List<CharacterData> characters = new List<CharacterData>();
}
