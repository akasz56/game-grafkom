using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool timerActive = false;
    float currentTime;
    [SerializeField] public int currentLevel = 1;
    [SerializeField] public Text missionObjectives;
    public int startMinutes;
    public Text currentTimeText;
    public GameObject Endscrn;
    public GameObject timeUpScrn;

    [HideInInspector]
    public int
        jumlahSampah = 0,
        jumlahRumput = 0,
        jumlahGaliable = 0,
        jumlahTanamable = 0,
        jumlahSiramable = 0;
    [HideInInspector] bool isGameOver;

    private void Awake()
    {
        instance = this;
        timerActive = true;
        Time.timeScale = 1f;
        currentTime = startMinutes * 60;

        switch (currentLevel)
        {
            case 1:
                levelOneInit();
                break;
            case 2:
                levelTwoInit();
                break;
            case 3:
                levelThreeInit();
                break;
        }
    }

    private void Update()
    {
        switch (currentLevel)
        {
            case 1:
                missionObjectives.text =
                    "Misi :" + "\n" +
                    "- Ambil " + jumlahSampah + " sampah yang ada" + "\n" +
                    "- Bersihkan " + jumlahRumput + " semak - semak";
                isGameOver = (jumlahSampah == 0 && jumlahRumput == 0);
                break;
            case 2:
                missionObjectives.text =
                    "Misi :" + "\n" +
                    "- Ambil " + jumlahSampah + " sampah yang ada" + "\n" +
                    "- Bersihkan " + jumlahRumput + " semak - semak" + "\n" +
                    "- Siram " + jumlahSiramable + " tanaman";
                isGameOver = (jumlahSampah == 0 && jumlahRumput == 0 && jumlahSiramable == 0);
                break;
            case 3:
                missionObjectives.text =
                    "Misi :" + "\n" +
                    "- Ambil " + jumlahSampah + " sampah yang ada" + "\n" +
                    "- Bersihkan " + jumlahRumput + " semak - semak" + "\n" +
                    "- Gali " + jumlahGaliable + " petak tanah" + "\n" +
                    "- Tanamkan di " + jumlahTanamable + " petak tanah" + "\n" +
                    "- Siram " + jumlahSiramable + " tanaman";
                isGameOver = (jumlahSampah == 0 && jumlahRumput == 0 && jumlahSiramable == 0 && jumlahGaliable == 0 && jumlahTanamable == 0);
                break;
        }

        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                timeUpScrn.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log("Waktu Habis");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        if (isGameOver)
        {
            Endscrn.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }

    private void levelOneInit()
    {
        GameObject[] sampah = GameObject.FindGameObjectsWithTag("SampahDrop");
        GameObject[] rumput = GameObject.FindGameObjectsWithTag("RumputCuttable");

        jumlahSampah = sampah.Length;
        jumlahRumput = rumput.Length;
    }

    private void levelTwoInit()
    {
        GameObject[] sampah = GameObject.FindGameObjectsWithTag("SampahDrop");
        GameObject[] rumput = GameObject.FindGameObjectsWithTag("RumputCuttable");
        GameObject[] siramable = GameObject.FindGameObjectsWithTag("TanamanSiramable");

        jumlahSampah = sampah.Length;
        jumlahRumput = rumput.Length;
        jumlahSiramable = siramable.Length;
    }

    private void levelThreeInit()
    {
        GameObject[] sampah = GameObject.FindGameObjectsWithTag("SampahDrop");
        GameObject[] rumput = GameObject.FindGameObjectsWithTag("RumputCuttable");
        GameObject[] siramable = GameObject.FindGameObjectsWithTag("TanamanSiramable");
        GameObject[] galiable = GameObject.FindGameObjectsWithTag("TanahGaliable");
        GameObject[] tanamable = GameObject.FindGameObjectsWithTag("TanahTanamable");

        jumlahSampah = sampah.Length;
        jumlahRumput = rumput.Length;
        jumlahSiramable = siramable.Length;
        jumlahGaliable = galiable.Length;
        jumlahTanamable = tanamable.Length;
    }

    public void updateSampah()
    {
        jumlahSampah = GameObject.FindGameObjectsWithTag("SampahDrop").Length;
        if (jumlahSampah == 0)
        {
            Debug.Log("Sampah Habis");
        }
    }

    public void updateRumput()
    {
        jumlahRumput = GameObject.FindGameObjectsWithTag("RumputCuttable").Length;
        if (jumlahRumput == 0)
        {
            Debug.Log("Rumput Habis");
        }
    }

    public void updateSiramable()
    {
        jumlahSiramable = GameObject.FindGameObjectsWithTag("TanamanSiramable").Length;
        if (jumlahSiramable == 0)
        {
            Debug.Log("Siramable Habis");
        }
    }

    public void updateGaliable()
    {
        jumlahGaliable = GameObject.FindGameObjectsWithTag("TanahGaliable").Length;
        if (jumlahGaliable == 0)
        {
            Debug.Log("Galiable Habis");
        }
    }

    public void updateTanamable()
    {
        jumlahTanamable = GameObject.FindGameObjectsWithTag("TanahTanamable").Length;
        if (jumlahTanamable == 0)
        {
            Debug.Log("Tanamable Habis");
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public GameObject player;
}
