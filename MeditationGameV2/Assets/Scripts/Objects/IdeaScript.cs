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
                GetComponent<Collider2D>().enabled = true;
                colliderOff = false;
            }
        }
        else
        {
            if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_3_Worry))
            {
                if (Randomizer.GetResultByChanse(Constants.ChanceOfWorryEffect))
                {
                    GetComponent<Collider2D>().enabled = false;
                    colliderOff = true;
                }
            }
        }

        //irritation realization

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("GameBorder"))
            {
                Destroy(gameObject);
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
    private float curTimeWithoutCollider = 0.0f;
    private float maxTimeWithoutCollider = 0.9f;
}
