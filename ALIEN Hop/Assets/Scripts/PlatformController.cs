using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform enemySpawner;
    public GameObject[] enemies;

    private bool _activated;

    private GameObject _platformEnemy
    private Transform _player;
    private PlatformSettings _platformSettings;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerController.position.y - transform.position.y >= 5f)
        {
            if(_platformEnemy !=  null) _platformEnemy.SetActive(false):

            gameObject.SetActive(false);
        }
            
    }

    void Awake()
    {
        _platformSettings = GetComponent<PlatformSettings>();
        _player = FindOnjectsOfType<PlayerController>().transform;
    }
    public void InitialisePlatform()
    {
        _activated = false;
        _platformSettings.SetRed();

        int enemy = Random.Range(0, enemies.Length + 1);

        if (enemy == enemies.Length) return;

        float randomPos = Random.Range(-2f, 2f);

        enemies[enemy].transform.position - new Vector3(randomPos, enemySpawner.position.y);
        eneimes[enemy].SetActive(true);

        _platformEnemy = enemies[enemy];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !_activated)
        {
            _activated = true;
            _platformSettings.SetGreen();

        }
    }
}
