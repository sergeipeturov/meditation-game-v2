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
                //speed of falling
                //float speedOfFalling = Random.Range(0.0f, 50.0f);
                float gravitiScale = 1.0f;//Random.Range(0.8f, 5.0f);
                                          //size
                float scaleSize = Random.Range(0.3f, 0.9f);

                var initedObj = Instantiate(IdeaPrefab, new Vector3(posX, posY, 0.0f), newRot);
                //initedObj.GetComponent<Rigidbody2D>().AddForce(Vector3.down * speedOfFalling);
                //var fob = initedObj.GetComponent<FallingObjectBase>();
                //fob.SetSpeedOfFalling(speedOfFalling);
                initedObj.GetComponent<Rigidbody2D>().gravityScale = gravitiScale;
                initedObj.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                initedObj.GetComponent<IdeaScript>().SetRandomThought(IdeaSpawnMode.all); //TODO: устанавливать режим в зависимости от текущих дум

                //new delay
                delay = Random.Range(0.0f, 1.0f);
            }
        }
    }

    private float delay = 1.0f;
    private float curDelay = 0.0f;
}
