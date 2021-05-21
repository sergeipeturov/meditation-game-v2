using System.Linq;
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
                var spawnMode = GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_4_Pessimism) ? IdeaSpawnMode.onlyNegative :
                    GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_3_Optimism) ? IdeaSpawnMode.onlyPositive : IdeaSpawnMode.all;
                initedObj.GetComponent<IdeaScript>().SetRandomThought(spawnMode);

                //time of life
                initedObj.GetComponent<IdeaScript>().Thought.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
                if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_9_Boredom))
                    initedObj.GetComponent<IdeaScript>().Thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromBoredom);
                if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_4_Inspiration))
                    initedObj.GetComponent<IdeaScript>().Thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromInspiration);

                //speed of falling 
                float speed = GameManager.Instance.LevelsManager.CurrentLevel.IdeasFallingSpeed;
                if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_1_Hate))
                {
                    speed += Constants.BonusToSpeedFromHate;
                    if (speed <= 1.0) speed = 1.0f;
                }
                if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_1_Joy))
                {
                    speed += Constants.BonusToSpeedFromJoy;
                    if (speed <= 1.0) speed = 1.0f;
                }
                initedObj.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);

                //new delay
                float minDelay = GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenIdeas;
                float maxDelay = GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenIdeas;
                if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_1_Hate))
                {
                    minDelay += Constants.BonusToTimeBetweenFromHate;
                    if (minDelay < 0) minDelay = 0;
                    maxDelay += Constants.BonusToTimeBetweenFromHate;
                    if (maxDelay < 0) maxDelay = 0;
                }
                if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_1_Joy))
                {
                    minDelay += Constants.BonusToTimeBetweenFromJoy;
                    if (minDelay < 0) minDelay = 0;
                    maxDelay += Constants.BonusToTimeBetweenFromJoy;
                    if (maxDelay < 0) maxDelay = 0;
                }
                delay = Random.Range(minDelay, maxDelay);
            }
        }
    }

    private float delay = 1.0f;
    private float curDelay = 0.0f;
}
