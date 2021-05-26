using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeditationGameUtils
{
    public static void SetTimeOfLife(ref Thought thought)
    {
        thought.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
        if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_9_Boredom))
            thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromBoredom);
        if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_4_Inspiration))
            thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromInspiration);
    }
}
