/**********************************************************************/
/*                                                                    */
/*                        Glitch Garden  							  */
/*																	  */
/*		This is the code from a game created to practice my           */
/*      Unity and Game Development skills. Most of this was           */
/*      made watching Ben Tristem's tutorial at Udemy.                */
/*                                                                    */
/*      For more information please visit:                            */
/*      https://www.udemy.com/unitycourse/                            */
/*                                                                    */
/*                                                                    */
/**********************************************************************/

using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	static MusicManager musicManager = null;
	
	public AudioClip[]  musics;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		if(musicManager != null && musicManager != this)
		{
			Destroy(gameObject);
		}
		else
		{
			musicManager = this;
			GameObject.DontDestroyOnLoad(musicManager);
			AudioSourceParameters();		
		}
	}
	
	//Set audio source default parameters
	void AudioSourceParameters()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = musics[0];
		audioSource.loop = true;
		SetVolume(PlayerPrefsManager.GetMasterVolume());
		audioSource.Play();
	}
	
	//Check for loaded levels and set new AudioClip to play
	void OnLevelWasLoaded(int level)
	{
		if(musics[level])
		{
			audioSource.Stop();
			audioSource.clip = musics[level];	
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
