using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thought
{
    public string Name { get; private set; }

    public float TimeOfLife { get; private set; }

    public float CurrentTimeOfLife { get; set; }

    public bool IsPositive { get; private set; }

    public bool IsMomental { get; private set; }

    public Thought(bool isMomental = false)
    {
        TimeOfLife = 0.0f;
        CurrentTimeOfLife = 0.0f;
        IsMomental = isMomental;
    }

    public void SetTimeOfLife(float newTimeOfLife)
    {
        TimeOfLife = newTimeOfLife;
    }

    public void IncreaseTimeOfLife(float additionalTime)
    {
        TimeOfLife += additionalTime;
    }

    public static List<Thought> GetPositiveThoughts()
    {
        var res = new List<Thought>
        {
            new Thought()
            {
                Name = Names.Positive_1_Joy,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_2_Concentration,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_3_Optimism,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_4_Inspiration,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_5_Hope,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_6_Satisfaction,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_7_Calmness,
                IsPositive = true
            },
            new Thought()
            {
                Name = Names.Positive_8_Serenity,
                IsPositive = true,
                IsMomental = true,
                TimeOfLife = 0.0f
            },
            new Thought()
            {
                Name = Names.Positive_9_Love,
                IsPositive = true
            },
            /*new Thought()
            {
                Name = Names.Positive_10_Enthusiasm,
                IsPositive = true
            }*/
        };
        return res;
    }

    public static List<Thought> GetNegativeThoughts()
    {
        var res = new List<Thought>
        {
            new Thought()
            {
                Name = Names.Negative_1_Hate,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_2_Uncertainty,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_3_Worry,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_4_Pessimism,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_5_Irritation,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_6_Guilt,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_7_Resentment,
                IsPositive = false
            },
            new Thought()
            {
                Name = Names.Negative_8_Jealousy,
                IsPositive = false,
                IsMomental = true,
                TimeOfLife = 0.0f
            },
            new Thought()
            {
                Name = Names.Negative_9_Boredom,
                //TimeOfLife = 
                IsPositive = false
            },
            /*new Thought()
            {
                Name = Names.Negative_10_Sorrow,
                IsPositive = false
            }*/
        };
        return res;
    }

    public static Thought GetRandomThought()
    {
        var positives = GetPositiveThoughts();
        var negatives = GetNegativeThoughts();
        int which = Random.Range(0, 2);
        int what = Random.Range(0, 10);
        if (which == 0)
            return positives[what];
        else
            return negatives[what];
    }

    public static Thought GetRandomPositiveThought()
    {
        var positives = GetPositiveThoughts();
        int what = Random.Range(0, 10);
        return positives[what];
    }

    public static Thought GetRandomNegativeThought()
    {
        var negatives = GetNegativeThoughts();
        int what = Random.Range(0, 10);
        return negatives[what];
    }

    public static Thought GetThoughtByName(string name)
    {
        var positives = GetPositiveThoughts();
        var negatives = GetNegativeThoughts();
        var res = positives.FirstOrDefault(x => x.Name == name);
        if (res == null) res = negatives.FirstOrDefault(x => x.Name == name);
        return res;
    }
}

public class ThoughtChoise
{ 
    public Thought Thought { get; set; }
    public bool IsOpened { get; set; } = false;
    public string ThoughtChoiseViewName { get; set; }

    public ThoughtChoise(Thought thought)
    {
        Thought = thought;
        IsOpened = false;
    }
}

