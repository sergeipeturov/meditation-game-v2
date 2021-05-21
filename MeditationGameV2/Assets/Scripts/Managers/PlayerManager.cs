using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Thought> PosistiveThoughts { get; private set; } = new List<Thought>();
    public List<Thought> NegativeThoughts { get; private set; } = new List<Thought>();

    private void Update()
    {
        //----------count time of life for thoughts---------------
        if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
        {
            //for positive
            foreach (var item in PosistiveThoughts)
            {
                item.CurrentTimeOfLife += Time.deltaTime;
                if (item.CurrentTimeOfLife >= item.TimeOfLife)
                {
                    item.CurrentTimeOfLife = 0.0f;
                    toRemove.Add(item);
                }
            }
            foreach (var item in toRemove)
            {
                PosistiveThoughts.Remove(item);
            }
            toRemove.Clear();
            NormalGameManager.Instance.EffectorUIManager.UpdatePositiveUIs(PosistiveThoughts);

            //for negative
            foreach (var item in NegativeThoughts)
            {
                item.CurrentTimeOfLife += Time.deltaTime;
                if (item.CurrentTimeOfLife >= item.TimeOfLife)
                {
                    item.CurrentTimeOfLife = 0.0f;
                    toRemove.Add(item);
                }
            }
            foreach (var item in toRemove)
            {
                NegativeThoughts.Remove(item);
            }
            toRemove.Clear();
            NormalGameManager.Instance.EffectorUIManager.UpdateNegativeUIs(NegativeThoughts);
            //------------------------------------------------------
        }
    }

    public void AddThought(Thought thought)
    {
        if (thought.IsPositive)
        {
            var same = PosistiveThoughts.FirstOrDefault(x => x == thought);
            if (same != null)
                same.CurrentTimeOfLife = 0.0f;
            else
                PosistiveThoughts.Add(thought);
        }
        else
        {
            var same = NegativeThoughts.FirstOrDefault(x => x == thought);
            if (same != null)
                same.CurrentTimeOfLife = 0.0f;
            else
                NegativeThoughts.Add(thought);
        }
    }

    private void RemoveThought(Thought thought)
    {
        if (thought.IsPositive)
            PosistiveThoughts.Remove(thought);
        else
            NegativeThoughts.Remove(thought);
    }

    private List<Thought> toRemove = new List<Thought>();
}
