//=================================================================================
//==description:音频管理器
//==state:播放音频、暂停、暂停继续播放、停止播放、切换音频、音频回调播放器、延时音频播放器、生成2D音效、3D音效、指定音效播放
//=================================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


/// <summary>
/// 配合AudioManagers使用
/// </summary>
interface IClipData {
    /// <summary>
    /// 通过字符串获取音频文件
    /// </summary>
    /// <param name="name">音频名称</param>
    /// <returns></returns>
    public AudioClip audiodata(string name);
}

//实现接口
public class ClipData : IClipData {
    public AudioClip audiodata(string name) {
        return Resources.Load<AudioClip>("Audios/" + name);
    }
}

    public delegate void AudioCallBack();
//携带AduioSource
public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    IClipData clipdata = new ClipData();

    private AudioSource _audioSource;

    void Awake() {
        Instance = this;
    }
    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// 播放音频 Resources/Audios/name
    /// </summary>
    /// <param name="name"></param>
    public void AudioPlay(string name) {
        _audioSource.clip = clipdata.audiodata(name);
        if (_audioSource.clip!=null) {
            _audioSource.Play();
        }
       
    }
    /// <summary>
    /// 暂停播放
    /// </summary>
    public void AudioPause() {
        _audioSource.Pause();
    }
    /// <summary>
    /// 暂停播放后继续播放
    /// </summary>
    public void AudioUnPause() {
        _audioSource.UnPause();
    }
    /// <summary>
    /// 停止播放
    /// </summary>
    public void AudioStop() {
        _audioSource.Stop();
    }
    /// <summary>
    /// 切换音频 Resources/Audios/name
    /// </summary>
    /// <param name="name"></param>
    public void AudioSwitch(string name) {
        AudioClip _clip = clipdata.audiodata(name);
        if (_audioSource.isPlaying) {
            _audioSource.Stop();
        }
        _audioSource.clip = _clip;
        _audioSource.Play();
    }
    /// <summary>
    /// 音频回调播放器  Resources/Audios/name callback=>音频播完后执行的方法。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    public void AudioPlayer(string name, AudioCallBack callback) {
        _audioSource.clip = clipdata.audiodata(name);
        _audioSource.Play();
        StartCoroutine(AudioDelayedCallBack(_audioSource.clip.length, callback));
    }


    /// <summary>
    /// 音频回调播放器  Resources/Audios/name callback=>音频播完后执行的方法。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    /// <param name="time"></param>
    public void AudioPlayer(string name, AudioCallBack callback, float time) {
        _audioSource.clip = clipdata.audiodata(name);
        _audioSource.Play();
        StartCoroutine(AudioDelayedCallBack(_audioSource.clip.length + time, callback));
    }

    //音频延迟回调
    IEnumerator AudioDelayedCallBack(float time, AudioCallBack callback) {
        yield return new WaitForSeconds(time);
        callback();
    }
    /// <summary>
    /// 延时播放音频 Resources/Audios/name time=>延时时间
    /// </summary>
    /// <param name="name"></param>
    /// <param name="time"></param>
    public void AudioDelayPlay(string name, float time) {
        _audioSource.clip = clipdata.audiodata(name);
        Invoke("AudioDelayTime", time);
    }
    private void AudioDelayTime() { _audioSource.Play(); }

    /// <summary>
    /// 生成2D音效 Resources/Audios/name 播放完毕消失
    /// </summary>
    /// <param name="name"></param>
    public void AudioInstantiate(string name) {
        GameObject obj = new GameObject();
        AudioSource _audio = obj.AddComponent<AudioSource>();
        _audio.name = "AudioSource";
        _audio.playOnAwake = true;
        _audio.clip = clipdata.audiodata(name);
        _audio.Play();
        StartCoroutine(AudioFinish(_audio.clip.length, obj));
    }
    //音效结束销毁AudioGameObject
    IEnumerator AudioFinish(float time, GameObject obj) {
        yield return new WaitForSeconds(time);
        DestroyImmediate(obj);
    }
    /// <summary>
    /// 3D音效 (只播放一次) Resources/Audios/name CameraPos:摄像机位置
    /// </summary>
    /// <param name="name"></param>
    /// <param name="CameraPos"></param>
    public void AudioAtPoint(string name, Vector3 CameraPos) {
        AudioSource.PlayClipAtPoint(clipdata.audiodata(name), CameraPos, 1.0f);
    }
    /// <summary>
    /// 指定AudioSource播放音频
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="name"></param>
    public void AudioSourceOther(GameObject obj, string name) {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = clipdata.audiodata(name);
        audioSource.Play();
    }

    public void CloseAudio() {
        StopAllCoroutines();
        _audioSource.clip = null;
    }
}


