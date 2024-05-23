using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
public class playMusic : MonoBehaviour
{
    //Video
    public VideoClip RandomVid;
    //Players
    private AudioSource audioSource;
    private VideoPlayer vidPlayer;
    //Textures
    public RenderTexture RandomTexture;
    //Other Objects
    public GameObject VideoPlayerParent;
    //Other Scripts
    //Instance Vars

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(playVid());
    }
    IEnumerator playVid()
    {
        yield return new WaitForSeconds(0.00f);
        //Initiallizing dictionaries
        string[] songNames = {"Random by Random"};
        VideoClip[] videos = {RandomVid};

        RenderTexture[] textures = {RandomTexture};

        Dictionary<string, VideoClip> songVid = new Dictionary<string, VideoClip>();
        Dictionary<string, RenderTexture> songText = new Dictionary<string, RenderTexture>();
        songText.Clear();
        songVid.Clear();
        /*
        for (int i = 0;i<songNames.Length;i++)
        {
            songText.Add(songNames[i], textures[i]);
            songVid.Add(songNames[i], videos[i]);
        }
        */
        // For some reason, a for loop to add key/values doesn't work, perhaps cuz im adding in different orders in different scripts?
        songVid.Add("Random", RandomVid);

        songText.Add("Random", RandomTexture);
        
        vidPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        yield return new WaitForSeconds(3);
        vidPlayer.clip = songVid[SongSelect2.theSong];
        vidPlayer.targetTexture = songText[SongSelect2.theSong];
        VideoPlayerParent.GetComponent<RawImage>().texture = songText[SongSelect2.theSong];

    }
}
