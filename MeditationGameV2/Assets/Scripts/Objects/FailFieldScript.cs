using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailFieldScript : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        var idea = collision.gameObject.GetComponent<IdeaScript>();
        if (idea != null)
        {
            var thought = idea.Thought;
            if (thought.Name == Names.Negative_8_Jealousy)
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
                    toAdd.Add(thoughtToAdd);
                }
                foreach (var item in toAdd)
                {
                    GameManager.Instance.PlayerManager.AddThought(item);
                }
            }
            else if (thought.Name == Names.Positive_8_Serenity)
            {
                GameManager.Instance.PlayerManager.RemoveAllThoughts();
            }
            else
            {
                GameManager.Instance.PlayerManager.AddThought(idea.Thought);
            }

            Destroy(collision.gameObject);
        }
    }*/
}
