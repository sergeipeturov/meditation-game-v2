using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnxietyInstantiator : MonoBehaviour
{
    public GameObject IdeaPrefab;
    public GameObject InstantiatePoint;

    public void GoInstantiate()
    {
        if (ideas.Count >= 2)
        {
            for (int i = 0; i < 3; i++)
            {
                var obj = Instantiate(IdeaPrefab, InstantiatePoint.transform);
                obj.GetComponent<BossAnxietyIdeaScript>().OnDestroyIdeaNotify += BossAnxietyInstantiator_OnDestroyIdeaNotify;
                obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                ideas.Add(obj);
            }
        }
        else
        {
            var obj = Instantiate(IdeaPrefab, InstantiatePoint.transform);
            obj.GetComponent<BossAnxietyIdeaScript>().OnDestroyIdeaNotify += BossAnxietyInstantiator_OnDestroyIdeaNotify;
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            ideas.Add(obj);
        }
    }

    private void BossAnxietyInstantiator_OnDestroyIdeaNotify(GameObject _gameObject)
    {
        ideas.Remove(_gameObject);
        Destroy(_gameObject);
        GameObject.Find("BossGameManager").GetComponent<BossGameManager>().DamagePlayer();
    }

    private void Update()
    {
        haveFreeIdeas = false;
        foreach (var item in ideas)
        {
            if (item.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
            {
                haveFreeIdeas = true;
                break;
            }
        }

        if (GameManager.Instance.StateMachine.GameState == GameState.bossPlaying)
        {
            if (!haveFreeIdeas)
            {
                GoInstantiate();
                haveFreeIdeas = true;
            }
        }
    }

    private bool haveFreeIdeas = false;
    private List<GameObject> ideas = new List<GameObject>();
}
