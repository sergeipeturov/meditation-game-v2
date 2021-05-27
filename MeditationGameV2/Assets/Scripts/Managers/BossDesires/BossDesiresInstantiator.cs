using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesiresInstantiator : MonoBehaviour
{
    public GameObject DesirePrefab;
    public GameObject[] InstantiatePoints;
    public float[] InstantiateAngles;


    private void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.bossPlaying)
        {
            curDelay += Time.deltaTime;
            if (curDelay >= delay)
            {
                curDelay = 0.0f;
                float minDelay = GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenIdeas;
                float maxDelay = GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenIdeas;
                delay = Random.Range(minDelay, maxDelay);

                int pointIndex = Random.Range(0, InstantiatePoints.Length);
                var previousRot = DesirePrefab.transform.rotation;
                var newRot = Quaternion.AngleAxis(InstantiateAngles[pointIndex], Vector3.forward) * previousRot;
                var initedObj = Instantiate(DesirePrefab, InstantiatePoints[pointIndex].transform.position, newRot);

                Debug.Log("Desire Spawned!");
            }
        }
    }

    private float delay = 1.0f;
    private float curDelay = 0.0f;
}
