using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaScript : MonoBehaviour
{
    public float SpeedOfFalling
    {
        get { return speedOfFalling; }
        set
        {
            speedOfFalling = value;
            if (value == 0)
            {

            }
        }
    }

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

    public void SetSpeedOfFalling(float newSpeed)
    {
        SpeedOfFalling = newSpeed;
    }

    private void Update()
    {
        if (SpeedOfFalling != 0)
        {
            //GetComponent<Rigidbody2D>().AddForce(Vector3.down * SpeedOfFalling * Time.deltaTime);
            transform.position += Vector3.down * SpeedOfFalling * Time.deltaTime;
        }
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

    private float speedOfFalling;
}
