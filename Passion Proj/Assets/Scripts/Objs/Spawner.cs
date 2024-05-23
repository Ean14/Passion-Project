using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Spawner : MonoBehaviour
{
    //Other GameObjects
    private GameObject target;
    private Transform canvasTrans;
    private GameObject counterObject;
    public TextMeshProUGUI startTimer;
    //Prefabs
    public GameObject targetPrefab;
    public GameObject counterPrefab;
    public GameObject heldTarget;
    //Other Scripts
    //Instance Vars
    public static int totalNotes;
    public static float totalTime;
    public static Vector3 spawnPos = new Vector3(0.0f, 0.0f, 0.0f);
    public float spawnCooldown = 0.5f;
    public float timeFromSpawn = 0f;
    public float bloom = 0;
    public static Dictionary<string, float[]> songTimes = new Dictionary<string, float[]>();
    public static float[][] times;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        canvasTrans = GameObject.FindGameObjectWithTag("CrosshairUI").GetComponent<Transform>();
        //spawnPos = new Vector3(Random.Range(-1.4f - ScoreKeeper.bloom, 1.4f + ScoreKeeper.bloom), Random.Range(-1.4f - ScoreKeeper.bloom, 1.4f + ScoreKeeper.bloom), 0.0f);
        StartCoroutine(start());
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(0.00f);
        //Collapseable statement to save space
        StartCoroutine(countdown());
        //songTimes = new Dictionary<string, float[]>();
        songTimes.Clear();
        string[] songNames = {"Random By Random", "Circles by EDEN"};
        /*
        for (int i = 0;i<songNames.Length;i++)
        {
            songTimes.Add(songNames[i], times[i]);
        }
        */

        songTimes.Add("Random by Random", new float[] { 1 });
        songTimes.Add("Circles by EDEN", new float[] {1});
        StartCoroutine(spawnCounter(songTimes[SongSelect2.theSong]));
    }

    IEnumerator countdown()
    {
        startTimer.text = "3";
        yield return new WaitForSeconds(0.5f);
        startTimer.text = "2";
        yield return new WaitForSeconds(0.5f);
        startTimer.text = "1";
        yield return new WaitForSeconds(0.5f);
        startTimer.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        startTimer.text = "";
    }
    IEnumerator spawnCounter(float[] spawnTimes)
    {
        totalTime = spawnTimes[spawnTimes.Length - 1];
        totalNotes = spawnTimes.Length;
        for (int i = 0; i < spawnTimes.Length; i++)
        {
            yield return new WaitUntil(() => (float) Time.timeSinceLevelLoadAsDouble >= spawnTimes[i]);
            //Debug.Log(spawnTimes[i]);
            
            for (int j = i; j<spawnTimes.Length;j++)
            {
                if (spawnTimes[j] < (float)Time.timeSinceLevelLoadAsDouble + 3.0f)
                {bloom += 0.025f;}
                else
                { break; }
            }
            //Debug.Log(bloom);
            spawnPos = new Vector3(Random.Range(-1.4f, 1.4f), Random.Range(-1.4f, 1.4f), 0.0f);
            Instantiate(counterPrefab, spawnPos, Quaternion.AngleAxis(90, Vector3.right));
        }
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator spawnHelds(float[] heldTimes)
    {
        for (int i = 0; i < heldTimes.Length; i++)
        {
            yield return new WaitUntil(() => (float)Time.timeSinceLevelLoadAsDouble >= heldTimes[i]);
            spawnPos = new Vector3(Random.Range(-1.4f, 1.4f), Random.Range(-1.4f, 1.4f), 0.0f);
            GameObject heldObj = Instantiate(heldTarget, spawnPos, Quaternion.AngleAxis(90, Vector3.right));
        }
    }
}