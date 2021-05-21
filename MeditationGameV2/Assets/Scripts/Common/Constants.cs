using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public const float BonusToTimeBetweenFromHate = -0.5f;
    public const float BonusToSpeedFromHate = 500.0f;
    public const float BonusToTimeBetweenFromJoy = 0.5f;
    public const float BonusToSpeedFromJoy = -500.0f;
    public const float BonusToTimeOfLifeFromBoredom = 5.0f;
    public const float BonusToTimeOfLifeFromInspiration = -5.0f;
    public const int ChanceOfUncertaintyEffect = 3;
    public const int ChanceOfWorryEffect = 2;
    public const int ChanceOfIrritationEffect = 100;
}

public static class Names
{
    //positive thoughts
    public const string Positive_1_Joy = "Joy";
    public const string Positive_2_Concentration = "Concentration";
    public const string Positive_3_Optimism = "Optimism";
    public const string Positive_4_Inspiration = "Inspiration";
    public const string Positive_5_Hope = "Hope";
    public const string Positive_6_Satisfaction = "Satisfaction";
    public const string Positive_7_Calmness = "Calmness";
    public const string Positive_8_Serenity = "Serenity";
    public const string Positive_9_Love = "Love";
    public const string Positive_10_Enthusiasm = "Enthusiasm";

    //negative thoughts
    public const string Negative_1_Hate = "Hate";
    public const string Negative_2_Uncertainty = "Uncertainty";
    public const string Negative_3_Worry = "Worry";
    public const string Negative_4_Pessimism = "Pessimism";
    public const string Negative_5_Irritation = "Irritation";
    public const string Negative_6_Guilt = "Guilt";
    public const string Negative_7_Resentment = "Resentment";
    public const string Negative_8_Jealousy = "Jealousy";
    public const string Negative_9_Boredom = "Boredom";
    public const string Negative_10_Sorrow = "Sorrow";
}
