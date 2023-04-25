using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{

    [SerializeField] private AudioClip _block_hit;

    public Transform blockContainer;
    public int blockCount = 0;
    public Dictionary<int, GameObject> _blocks = new Dictionary<int, GameObject>();

    private int current_block_count = 0;
    private GameObject selected_block;
    private int selected_index;
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
        // select_current_block(); 
        select_random_block();
    }

    // Picks the first child in container 
    public void select_current_block(){
        // selected_block = _blocks[current_block_index];
        selected_block = _blocks.ElementAt(0).Value;
        selected_index = 0;
        meshRenderer = selected_block.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        material.SetColor("_Color", Color.green);
    }

    public void select_random_block(){
        // Select a random element in _blocks
        int randIndex = Random.Range(0 , _blocks.Count);
        KeyValuePair<int, GameObject> randomBlock = _blocks.ElementAt(randIndex);
        selected_block = randomBlock.Value;
        selected_index = randomBlock.Key;
        // Get its mesh rendered and change it to green
        meshRenderer = selected_block.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        material.SetColor("_Color", Color.green);
    }

    // check collision block
    public void check_collision(GameObject block){
        if (block == selected_block){
            // Remove from Dictionary
            _blocks.Remove(selected_index);
            // Destroy block objet
            Destroy(block);
            // Clear block, check for next block
            current_block_count += 1;
            if (current_block_count >= blockCount){
                spell_Cleared.Invoke();
                Destroy(this.gameObject);
            }else{
                // select_current_block();
                SoundManager.Instance.PlaySound(_block_hit);
                select_random_block();
            }
            
        }
    }


}
