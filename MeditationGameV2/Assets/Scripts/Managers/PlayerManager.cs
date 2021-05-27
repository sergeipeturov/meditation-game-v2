using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public delegate void ThoughtAdded(Thought thought);
    public event ThoughtAdded ThoughtAddedNotify;
    public delegate void ThoughtRemoved(Thought thought);
    public event ThoughtRemoved ThoughtRemovedNotify;

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
                //PosistiveThoughts.Remove(item);
                RemoveThought(item);
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
                //NegativeThoughts.Remove(item);
                RemoveThought(item);
            }
            toRemove.Clear();
            NormalGameManager.Instance.EffectorUIManager.UpdateNegativeUIs(NegativeThoughts);
            //------------------------------------------------------
        }
    }

    public void AddThought(Thought thought)
    {
        //Debug.Log("Adding Thought!");
        if (thought.IsPositive)
        {
            var same = PosistiveThoughts.FirstOrDefault(x => x.Name == thought.Name);
            if (same != null)
            {
                //Debug.Log("Added!");
                same.CurrentTimeOfLife = 0.0f;
            }
            else
            {
                //Debug.Log("Added!");
                PosistiveThoughts.Add(thought);
            }
        }
        else
        {
            var same = NegativeThoughts.FirstOrDefault(x => x.Name == thought.Name);
            if (same != null)
            {
                //Debug.Log("Added!");
                same.CurrentTimeOfLife = 0.0f;
            }
            else
            {
                //Debug.Log("Added!");
                NegativeThoughts.Add(thought);
            }
        }
        ThoughtAddedNotify?.Invoke(thought);
        NormalGameManager.Instance.EffectorUIManager.UpdatePositiveUIs(PosistiveThoughts);
        NormalGameManager.Instance.EffectorUIManager.UpdateNegativeUIs(NegativeThoughts);
    }

    public void RemoveAllThoughts()
    {
        foreach (var item in PosistiveThoughts)
        {
                toRemove.Add(item);
        }
        foreach (var item in toRemove)
        {
            RemoveThought(item);
        }
        toRemove.Clear();
        //NormalGameManager.Instance.EffectorUIManager.UpdatePositiveUIs(PosistiveThoughts);
        //NormalGameManager.Instance.EffectorUIManager.UpdateNegativeUIs(NegativeThoughts);
    }

    private void RemoveThought(Thought thought)
    {
        if (thought.IsPositive)
            PosistiveThoughts.Remove(thought);
        else
            NegativeThoughts.Remove(thought);

        ThoughtRemovedNotify?.Invoke(thought);
        NormalGameManager.Instance.EffectorUIManager.UpdatePositiveUIs(PosistiveThoughts);
        NormalGameManager.Instance.EffectorUIManager.UpdateNegativeUIs(NegativeThoughts);
    }

    private List<Thought> toRemove = new List<Thought>();
}
