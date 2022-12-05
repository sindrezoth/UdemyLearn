using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterType
    {
        Player,
        Ai
    }

    [SerializeField]
    private CharacterType _type;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
