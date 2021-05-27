using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopePlatforms : MonoBehaviour
{
    public GameObject[] Platforms;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.ThoughtAddedNotify += PlayerManager_ThoughtAddedNotify;
        GameManager.Instance.PlayerManager.ThoughtRemovedNotify += PlayerManager_ThoughtRemovedNotify;

        if (!GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_5_Hope))
        {
            foreach (var item in Platforms)
                item.SetActive(false);
        }
    }

    private void PlayerManager_ThoughtAddedNotify(Thought thought)
    {
        if (thought.Name == Names.Positive_5_Hope)
        {
            int rand = Random.Range(0, 3);
            Platforms[rand].SetActive(true);
        }
    }

    private void PlayerManager_ThoughtRemovedNotify(Thought thought)
    {
        if (thought.Name == Names.Positive_5_Hope)
        {
            foreach (var item in Platforms)
                item.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerManager.ThoughtAddedNotify -= PlayerManager_ThoughtAddedNotify;
        GameManager.Instance.PlayerManager.ThoughtRemovedNotify -= PlayerManager_ThoughtRemovedNotify;
    }
}
