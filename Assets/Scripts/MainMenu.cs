using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuBack;
    public GameObject Story;
    public GameObject Setting;

    public GameObject CheckMusic;
    public GameObject CheckSound;

    public Slider SliderMusic;
    public Slider SliderSound;

    public int isMusic = 0;
    public int isSound = 0;

    public float musicVolume = 1;
    public float soundVolume = 1;

    void Start()
    {
        CheckMusic.SetActive(true);
        CheckSound.SetActive(true);

        SliderMusic.onValueChanged.AddListener(delegate { MusicValueChange();}); // AddListener = 앞의 조건이 활성화될떄 해당 함수를 호출한다. 이 코드는 변수의 값이 변할때이다.
        SliderSound.onValueChanged.AddListener(delegate { SoundValueCahnge();});

        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", SliderMusic.value);
        }
        SliderMusic.value = musicVolume;

        if(PlayerPrefs.HasKey("SoundVolume"))
        {
            soundVolume = PlayerPrefs.GetFloat("SoundVolume", SliderSound.value);
        }
        SliderSound.value = soundVolume;


    }

    public void BtnBack(int num)
    {
        switch(num)
        {
            case 0:
                Story.GetComponent<Animator>().SetTrigger("Close");
                Invoke("OpenMenuBack", 1.5f);
                break;
            case 1:
                Setting.GetComponent<Animator>().SetTrigger("Close");
                Invoke("OpenMenuBack", 1.5f);
                break;
        }
    }

    void MusicValueChange()
    {
        Debug.Log(SliderMusic.value);
        PlayerPrefs.SetFloat("MusicVolume", SliderMusic.value);
    }

    void SoundValueCahnge()
    {
        Debug.Log(SliderSound.value);
        PlayerPrefs.SetFloat("SoundVolume", SliderSound.value);
    }
    
    public void BtnStory()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Close");
        Invoke("OpenStroy", 1.5f);
    }

    public void BtnSetting()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Close");
        Invoke("OpenSetting", 1.5f);
    }

    public void BtnMusic()
    {
        CheckMusic.SetActive(!CheckMusic.activeInHierarchy);
    }

    public void BtnSound()
    {
        CheckSound.SetActive(!CheckSound.activeInHierarchy);
    }

    void OpenStroy()
    {
        Story.SetActive(true);
        Story.GetComponent<Animator>().SetTrigger("Open");
    }

    void OpenSetting()
    {
        Setting.SetActive(true);
        Setting.GetComponent<Animator>().SetTrigger("Open");
    }

    void OpenMenuBack()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Open");
    }

}
