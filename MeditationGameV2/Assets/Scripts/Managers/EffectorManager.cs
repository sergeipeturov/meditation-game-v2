using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorManager : MonoBehaviour
{

    void Update()
    {
        //resentment realization
        if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_7_Resentment))
        {
            var previousRot = Camera.main.transform.rotation;
            if (previousRot.z != -1.0f)
            {
                var newRot = Quaternion.AngleAxis(180.0f, Vector3.forward) * previousRot;
                Camera.main.transform.rotation = newRot;
            }
        }
        else
        {
            var previousRot = Camera.main.transform.rotation;
            if (Mathf.Round(previousRot.z) != 0f)
            {
                var newRot = Quaternion.AngleAxis(180.0f, Vector3.forward) * previousRot;
                Camera.main.transform.rotation = newRot;
            }
        }

        //sorrow realization
        if (spriteRenrererOff)
        {
            curTimeWithoutSpriteRenderer += Time.deltaTime;
            if (curTimeWithoutSpriteRenderer >= maxTimeWithoutSpriteRenderer)
            {
                curTimeWithoutSpriteRenderer = 0.0f;
                foreach (var item in GameManager.Instance.Ideas)
                {
                    item.GetComponent<SpriteRenderer>().enabled = true;
                }
                spriteRenrererOff = false;
            }
        }
        else
        {
            if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_10_Sorrow))
            {
                if (Randomizer.GetResultByChanse(Constants.ChanceOfSorrowEffect))
                {
                    foreach (var item in GameManager.Instance.Ideas)
                    {
                        item.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    spriteRenrererOff = true;
                }
            }
        }
    }

    private bool spriteRenrererOff = false;
    private float curTimeWithoutSpriteRenderer = 0.0f;
    private float maxTimeWithoutSpriteRenderer = 0.9f;
}
