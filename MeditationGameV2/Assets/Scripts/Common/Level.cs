using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int Number { get; set; }

    /// <summary>
    /// Время без дум, чтобы достичь битвы с боссом
    /// </summary>
    public float TimeToReach { get; set; }  //чем больше, тем сложнее

    public float ThoughtsTimeOfLife { get; set; } //чем больше, тем сложнее

    public float IdeasFallingSpeed { get; set; } //чем больше, тем сложнее

    public float MaxTimeBetweenIdeas { get; set; } //чем больше, тем проще

    public float MinTimeBetweenIdeas { get; set; } //чем больше, тем проще

    public float MaxTimeBetweemBlackHoles { get; set; } //чем больше, тем сложнее

    public float MinTimeBetweemBlackHoles { get; set; } //чем больше, тем сложнее

    public int ChanceOfBlackHole { get; set; } //чем больше, тем проще

}
