using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{

    public Transform blockContainer;
    public int blockCount = 0;
    public Dictionary<int, GameObject> _blocks = new Dictionary<int, GameObject>();

    private int current_block_index = 0;
    private GameObject selected_block;
    private MeshRenderer meshRenderer;

    public UnityEvent spell_Cleared;

    void Start()
    {
        blockContainer = transform.GetChild(0); 
        blockCount = blockContainer.childCount; // Count number of blocks in spell

        // Populate dictionary with blocks
        for (int i = 0; i < blockCount; i++){
            _blocks[i] = blockContainer.GetChild(i).gameObject;
            BoxCollider block_collider = _blocks[i].GetComponent<BoxCollider>();
            block_collider.size = new Vector3(1.0f, 1.0f, 5000.0f);
            _blocks[i].tag = "Spell"; // Set tag of block
            // _blocks[i].gameObject.GetComponent<Sphere>()._spellObject = gameObject;
        }

        select_current_block(); 
    }

    // Picks the first child in container 
    public void select_current_block(){
        selected_block = _blocks[current_block_index];
        meshRenderer = selected_block.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        material.SetColor("_Color", Color.green);
    }

    // check collision block
    public void check_collision(GameObject block){
        if (block == selected_block){
            Destroy(block);
            // Clear block, check for next block
            current_block_index += 1;
            if (current_block_index >= blockCount){
                spell_Cleared.Invoke();
                Destroy(this.gameObject);
            }else{
                print("CurrentIndex" + current_block_index);
                print("Count" + blockCount);
                select_current_block();
            }
            
        }
    }


}
