using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioTimeTest : MonoBehaviour {

	private AudioSource audioSource;
	private int currentHour;
	private int currentMinute;
	private int currentSecond;
	private int clipHour;
	private int clipMinute;
	private int clipSecond;

	public AudioClip audioClip;
	public Text audioTimeText;
	public Text audioName;
	public Slider audioTimeSlider;

	bool lue=false;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioName.text = audioClip.name;
		clipHour = (int)audioSource.clip.length / 3600;
		clipMinute = (int)(audioSource.clip.length - clipHour * 3600) / 60;
		clipSecond = (int)(audioSource.clip.length - clipHour * 3600 - clipMinute * 60);
		audioSource.Play();
	}

	void SetAudioTimeValueChange()
	{
		audioSource.time = audioTimeSlider.value * audioSource.clip.length;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0)&& EventSystem.current.IsPointerOverGameObject())
		{
			lue = true;
			audioSource.Stop();
		}
		else if (Input.GetMouseButton(0) && lue)
		{
			SetAudioTimeValueChange();
		}
		else
		{
			ShowAudioTime();
		}
		if (Input.GetMouseButtonUp(0))
		{

			audioSource.Play();
			lue = false;
		}

	}

	void ShowAudioTime()
	{
		currentHour = (int)audioSource.time / 3600;
		currentMinute = (int)(audioSource.time - currentHour * 3600) / 60;
		currentSecond = (int)(audioSource.time - currentHour * 3600 - currentMinute * 60);

		audioTimeText.text = string.Format("{0}:{1}:{2}/{3}:{4}:{5}", currentHour, currentMinute, currentSecond, clipHour, clipMinute, clipSecond);
		audioTimeSlider.value = audioSource.time / audioSource.clip.length;
	}

}
