using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private List<Level> levels = new List<Level>()
    {
        new Level()
        {
            Number = 1,
            TimeToReach = 25.0f,
            ThoughtsTimeOfLife = 10.0f,
            IdeasFallingSpeed = 1.0f,
            MinTimeBetweenIdeas = 0.5f,
            MaxTimeBetweenIdeas = 1.5f,
            ChanceOfBlackHole = 0,
            MaxTimeBetweenBlackHoles = 0,
            MinTimeBetweenBlackHoles = 0,
            ChanceOfGreyHole = 0,
            MaxTimeBetweenGreyHoles = 0,
            MinTimeBetweenGreyHoles = 0
        },
        new Level()
        {
            Number = 2,
            TimeToReach = 27.0f,
            ThoughtsTimeOfLife = 10.0f,
            IdeasFallingSpeed = 100.0f,
            MinTimeBetweenIdeas = 0.3f,
            MaxTimeBetweenIdeas = 1.5f,
            ChanceOfBlackHole = 80,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 0,
            MaxTimeBetweenGreyHoles = 0,
            MinTimeBetweenGreyHoles = 0
        },
        new Level()
        {
            Number = 3,
            TimeToReach = 2.0f, //TimeToReach = 30.0f, //test
            ThoughtsTimeOfLife = 15.0f,
            IdeasFallingSpeed = 200.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.5f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 80,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        },
        new Level()
        {
            Number = 4,
            TimeToReach = 33.0f,
            ThoughtsTimeOfLife = 15.0f,
            IdeasFallingSpeed = 300.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.0f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 50,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        },
        new Level()
        {
            Number = 5,
            TimeToReach = 35.0f,
            ThoughtsTimeOfLife = 20.0f,
            IdeasFallingSpeed = 500.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.0f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 50,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        },
        new Level()
        {
            Number = 6,
            TimeToReach = 37.0f,
            ThoughtsTimeOfLife = 20.0f,
            IdeasFallingSpeed = 600.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.0f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 50,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        },
        new Level()
        {
            Number = 7,
            TimeToReach = 40.0f,
            ThoughtsTimeOfLife = 25.0f,
            IdeasFallingSpeed = 800.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.0f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 50,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        },
        new Level()
        {
            Number = 8,
            TimeToReach = 25.0f,
            ThoughtsTimeOfLife = 40.0f,
            IdeasFallingSpeed = 900.0f,
            MinTimeBetweenIdeas = 0.0f,
            MaxTimeBetweenIdeas = 1.0f,
            ChanceOfBlackHole = 50,
            MaxTimeBetweenBlackHoles = 3.0f,
            MinTimeBetweenBlackHoles = 5.0f,
            ChanceOfGreyHole = 50,
            MaxTimeBetweenGreyHoles = 3.0f,
            MinTimeBetweenGreyHoles = 5.0f
        }
    };

    public Level CurrentLevel { get { return levels.FirstOrDefault(x => x.Number == GameManager.Instance.CurrentLevel); } }
}
