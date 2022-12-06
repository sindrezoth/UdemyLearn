using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private Transform _spawnPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ReviveCharacter();
        }
    }

    private void ReviveCharacter()
    {
        Health h = _character.GetComponent<Health>();

        if(h.CurrentHealth <= 0)
        {
            h.Revive();
            _character.transform.position = _spawnPosition.transform.position;
        }
    }

}
