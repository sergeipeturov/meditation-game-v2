using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject IdeaPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
        {
            curDelay += Time.deltaTime;
            if (curDelay >= delay)
            {
                curDelay = 0.0f;

                //position
                float posX = Random.Range(-2.5f, 2.5f);
                float posY = 5.3f;

                //rotation
                var previousRot = IdeaPrefab.transform.rotation;
                var newRot = Quaternion.AngleAxis(Random.Range(-25.0f, 25.0f), Vector3.forward) * previousRot;

                float scaleSize = Random.Range(0.3f, 0.9f);

                var initedObj = Instantiate(IdeaPrefab, new Vector3(posX, posY, 0.0f), newRot);
                initedObj.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);

                //set idea to object
                var spawnMode = IdeaSpawnMode.all; //TODO: устанавливать режим в зависимости от текущих дум
                initedObj.GetComponent<IdeaScript>().SetRandomThought(spawnMode);

                //speed of falling 
                initedObj.GetComponent<Rigidbody2D>().AddForce(Vector2.down * GameManager.Instance.LevelsManager.CurrentLevel.IdeasFallingSpeed);

                //new delay
                delay = Random.Range(GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenIdeas, GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenIdeas);
            }
        }
    }

    private float delay = 1.0f;
    private float curDelay = 0.0f;
}
