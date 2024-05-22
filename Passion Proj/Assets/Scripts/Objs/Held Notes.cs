using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldNotes : MonoBehaviour
{
    public GameObject heldnote;s
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnCounter(float[] spawnTimes)
    {
        for(int i = 0; i < spawnTimes.Length; i++)
        {
            yield return new WaitUntil(() => (float) Time.timeSinceLevelLoadAsDouble >= spawnTimes[i]);

            spawnPos = new Vector3(Random.Range(-1.4f, 1.4f), Random.Range(-1.4f, 1.4f), 0.0f);

            if(i % 2 != 0 )
            {
                heldTarget = Instantiate(heldnote, spawnPos, Quaternion.AngleAxis(90, Vector3.right);
                heldTarget.life = spawnTimes[i + 1];
            }

        }
    }
}
