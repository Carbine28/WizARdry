using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Manages all spells that can be spawn 
public class SpellManager : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    private WeaponController _weaponControllerScript;
    [SerializeField] private GameObject spellTarget; // Position of the spell
    [SerializeField] private GameObject[] spellPrefabs;

    private int spellCount;


    private void Start(){
        _weaponControllerScript = _weaponController.GetComponent<WeaponController>();
        spellCount = spellPrefabs.Length;
        spawn_Spell();
    }


    private void spawn_Spell(){
        int index = Random.Range(0, spellCount); // Pick a random spell from array
        // print(index);
        GameObject spell = Instantiate(spellPrefabs[index], spellTarget.transform.position, this.transform.rotation); // Spawn at target position

        Spell spell_Script = spell.GetComponent<Spell>();
        spell_Script.spell_Cleared.AddListener(_spellFiredEvent);

        spell.transform.SetParent(this.transform);
    }
    
    private void _spellFiredEvent(){
        _weaponControllerScript.FireSpell();
        spawn_Spell();
    }
    
}
