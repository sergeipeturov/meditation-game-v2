using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour //Singleton<SpritesManager>
{
    //positive
    public Sprite Joy;
    public Sprite Concentration;
    public Sprite Optimism;
    public Sprite Inspiration;
    public Sprite Hope;
    public Sprite Satisfaction;
    public Sprite Calmness;
    public Sprite Serenity;
    public Sprite Love;
    public Sprite Enthusiasm;

    //negative
    public Sprite Hate;
    public Sprite Uncertainty;
    public Sprite Worry;
    public Sprite Pessimism;
    public Sprite Irritation;
    public Sprite Guilt;
    public Sprite Resentment;
    public Sprite Jealousy;
    public Sprite Boredom;
    public Sprite Sorrow;

    //default
    public Sprite Default;

    public Sprite GetSpriteByThoughtName(string name)
    {
        switch (name)
        {
            case Names.Positive_1_Joy:
                return Joy;
            case Names.Positive_2_Concentration:
                return Concentration;
            case Names.Positive_3_Optimism:
                return Optimism;
            case Names.Positive_4_Inspiration:
                return Inspiration;
            case Names.Positive_5_Hope:
                return Hope;
            case Names.Positive_6_Satisfaction:
                return Satisfaction;
            case Names.Positive_7_Calmness:
                return Calmness;
            case Names.Positive_8_Serenity:
                return Serenity;
            case Names.Positive_9_Love:
                return Love;
            case Names.Positive_10_Enthusiasm:
                return Enthusiasm;

            case Names.Negative_1_Hate:
                return Hate;
            case Names.Negative_2_Uncertainty:
                return Uncertainty;
            case Names.Negative_3_Worry:
                return Worry;
            case Names.Negative_4_Pessimism:
                return Pessimism;
            case Names.Negative_5_Irritation:
                return Irritation;
            case Names.Negative_6_Guilt:
                return Guilt;
            case Names.Negative_7_Resentment:
                return Resentment;
            case Names.Negative_8_Jealousy:
                return Jealousy;
            case Names.Negative_9_Boredom:
                return Boredom;
            case Names.Negative_10_Sorrow:
                return Sorrow;

            default:
                return Default;
        }
    }

    public Sprite GetDefaultSprite()
    {
        return Default;
    }
}
