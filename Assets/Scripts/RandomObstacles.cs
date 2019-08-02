using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class RandomObstacles : MonoBehaviour
{

    public GameObject _plane;        
    public GameObject[] _obstacles;
    public GameObject[] _powerups;

    public float _position;
    private GameObject _player;
    private int _spawnedNumbers = 0;
    
    private void Start()
    {
        _obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        _powerups = GameObject.FindGameObjectsWithTag("PowerUp");
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        return;

        if (_spawnedNumbers > 50)
            return;

        if (_obstacles.Length > 0)
        {
            var obstacleIndex = Random.Range(0, _obstacles.Length);
            var pos = new Vector3(_player.transform.position.x, _plane.transform.position.y + 200, _player.transform.position.z);
            GameObject obstacleInstance = Instantiate(_obstacles[obstacleIndex],  pos + Vector3.forward * _position, new Quaternion(0, 0, 0, 0));
        }

        if (_powerups.Length > 0)
        {
            var powerupIndex = Random.Range(0, _powerups.Length);
            GameObject powerupInstance = Instantiate(_powerups[powerupIndex], _player.transform.position + Vector3.forward * 5, new Quaternion(0, 0, 0, 0));
        }

        _spawnedNumbers++;
    }


}
