using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float objectSpeed = 8f;

    private List<GameObject> -activeObjects;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = objectSpeed * Time.deltaTime * Vector3.left;
        foreach (GameObjectactiveObject in _activeObjects)
        {
            activeObject.transform.position += movement;

            GameManage.UpdateScore(movement);
        }

        IEnumerator Spawn()
        {
            GameManager.UpdateList(_activeObjects);

            GameObject challengeObject = Instantiate(GameManager.GetChallengeObject());
            challengeObject.transform.position = new Vector3(GameManager.ScreenBounds.x, 0);
            _activeObjects.Add(challengeObject);

            challengeObject script.GetComponent<challengeObject>();

            yeild return new WaitForSeconds(script.challengeTime);
            StartCoroutine(Spawn());
        }
    }
}
