using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.player_DeathEvent.AddListener(_switchToGameOverScene);
    }

    private void _switchToGameOverScene(){
        SceneManager.LoadScene("GameOver"); // Switch to gameover scene
    }
}
