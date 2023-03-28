using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 respawnPoint;
    public GameObject wherToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = wherToSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint;
            Debug.Log("respawn now");
        }
    }
}
