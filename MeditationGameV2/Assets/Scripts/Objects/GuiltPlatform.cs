using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiltPlatform : MonoBehaviour
{
    public bool IsLeft;

    private void Awake()
    {
        //vector = Vector2.up;
        mult = IsLeft ? 1 : -1;

        GameManager.Instance.PlayerManager.ThoughtAddedNotify += PlayerManager_ThoughtAddedNotify;
        GameManager.Instance.PlayerManager.ThoughtRemovedNotify += PlayerManager_ThoughtRemovedNotify;

        if (!GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_6_Guilt))
            this.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(mult * Vector2.up * 2.5f * Time.deltaTime);
        curDelay += Time.deltaTime;
        if (curDelay >= delay)
        {
            curDelay = 0.0f;
            mult = -mult;
        }
    }

    private void PlayerManager_ThoughtAddedNotify(Thought thought)
    {
        if (thought.Name == Names.Negative_6_Guilt)
            this.gameObject.SetActive(true);
    }

    private void PlayerManager_ThoughtRemovedNotify(Thought thought)
    {
        if (thought.Name == Names.Negative_6_Guilt)
            this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerManager.ThoughtAddedNotify -= PlayerManager_ThoughtAddedNotify;
        GameManager.Instance.PlayerManager.ThoughtRemovedNotify -= PlayerManager_ThoughtRemovedNotify;
    }

    private float curDelay = 0.0f;
    private float delay = 1.4f;
    private int mult = 1;
}
