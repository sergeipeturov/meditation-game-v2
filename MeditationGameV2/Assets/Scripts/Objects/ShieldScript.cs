using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.PlayerManager.ThoughtAddedNotify += PlayerManager_ThoughtAddedNotify;
        GameManager.Instance.PlayerManager.ThoughtRemovedNotify += PlayerManager_ThoughtRemovedNotify;

        if (!GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_2_Concentration))
            this.gameObject.SetActive(false);
    }

    private void PlayerManager_ThoughtAddedNotify(Thought thought)
    {
        if (thought.Name == Names.Positive_2_Concentration)
            this.gameObject.SetActive(true);
    }

    private void PlayerManager_ThoughtRemovedNotify(Thought thought)
    {
        if (thought.Name == Names.Positive_2_Concentration)
            this.gameObject.SetActive(false);
    }
}
