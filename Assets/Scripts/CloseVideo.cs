using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CloseVideo : MonoBehaviour
{
    public VideoPlayer video;
    public string sceneName;

    private void Awake()
        {
            video = GetComponent<VideoPlayer>();
            video.Play();
        video.loopPointReached += CheckOver;
        }


    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);
    }
}
