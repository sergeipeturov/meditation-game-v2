using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaScript : MonoBehaviour
{
    public Thought Thought { get; set; }

    public void SetRandomThought(IdeaSpawnMode ideaSpawnMode)
    {
        switch (ideaSpawnMode)
        {
            case IdeaSpawnMode.all:
                Thought = Thought.GetRandomThought();
                break;
            case IdeaSpawnMode.onlyNegative:
                Thought = Thought.GetRandomNegativeThought();
                break;
            case IdeaSpawnMode.onlyPositive:
                Thought = Thought.GetRandomPositiveThought();
                break;
        }

        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.SpritesManager.GetSpriteByThoughtName(Thought.Name);
    }

    private void Update()
    {
        //uncertainty realization
        if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_2_Uncertainty))
        {
            if (Randomizer.GetResultByChanse(Constants.ChanceOfUncertaintyEffect))
            {
                Thought = Thought.GetRandomThought();
                GetComponent<SpriteRenderer>().sprite = GameManager.Instance.SpritesManager.GetSpriteByThoughtName(Thought.Name);
            }
        }

        //worry realization
        if (colliderOff)
        {
            curTimeWithoutCollider += Time.deltaTime;
            if (curTimeWithoutCollider >= maxTimeWithoutCollider)
            {
                curTimeWithoutCollider = 0.0f;
                //GetComponent<Collider2D>().enabled = true;
                GetComponent<Collider2D>().isTrigger = true;
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.5f);
                colliderOff = false;
            }
        }
        else
        {
            if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_3_Worry))
            {
                if (Randomizer.GetResultByChanse(Constants.ChanceOfWorryEffect))
                {
                    //GetComponent<Collider2D>().enabled = false;
                    GetComponent<Collider2D>().isTrigger = false;
                    GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1.0f);
                    colliderOff = true;
                }
            }
        }

        //irritation realization
        if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_5_Irritation))
        {
            if (Randomizer.GetResultByChanse(Constants.ChanceOfIrritationEffect))
            {
                GetComponent<Rigidbody2D>().AddForce(Directions.GetRandomLeftRightDirection() * 30);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("GameBorder"))
            {
                GameManager.Instance.Ideas.Remove(gameObject);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag.Contains("FailField") && GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
            {
                if (Thought.Name == Names.Negative_8_Jealousy)
                {
                    int count = Random.Range(1, 5);
                    var toAdd = new List<Thought>();
                    while (toAdd.Count < count)
                    {
                        var thoughtToAdd = Thought.GetRandomThought();
                        while (toAdd.Any(x => x == thoughtToAdd) || thoughtToAdd.Name == Names.Negative_8_Jealousy || thoughtToAdd.Name == Names.Positive_8_Serenity)
                        {
                            thoughtToAdd = Thought.GetRandomThought();
                        }
                        /*thoughtToAdd.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
                        if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_9_Boredom))
                            thoughtToAdd.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromBoredom);
                        if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_4_Inspiration))
                            thoughtToAdd.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromInspiration);*/
                        MeditationGameUtils.SetTimeOfLife(ref thoughtToAdd);
                        toAdd.Add(thoughtToAdd);
                    }
                    Debug.Log("Start adding Jealousy thoughts!");
                    foreach (var item in toAdd)
                    {
                        Debug.Log("Adding " + item.Name);
                        GameManager.Instance.PlayerManager.AddThought(item);
                    }
                    Debug.Log("Stop adding Jealousy thoughts!");
                }
                else if (Thought.Name == Names.Positive_8_Serenity)
                {
                    GameManager.Instance.PlayerManager.RemoveAllThoughts();
                }
                else
                {
                    Debug.Log("In IdeaScript. Must add Thought!");
                    if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_6_Satisfaction))
                    {
                        var th = Thought.GetRandomPositiveThought();
                        MeditationGameUtils.SetTimeOfLife(ref th);
                        Thought = th;
                    }
                    if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_7_Calmness)) //calmness realization
                    {
                        if (!Randomizer.GetResultByChanse(Constants.ChanceOfCalmnessEffect))
                        {
                            GameManager.Instance.PlayerManager.AddThought(Thought);
                        }
                    }
                    else
                    {
                        GameManager.Instance.PlayerManager.AddThought(Thought);
                    }
                }

                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wasCollision = true;
    }

    private float speedOfFalling;
    private bool wasCollision = false;
    private bool colliderOff = false;
    private bool spriteRendererOff = false;
    private float curTimeWithoutCollider = 0.0f;
    private float maxTimeWithoutCollider = 0.9f;
}
