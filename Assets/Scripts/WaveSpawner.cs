using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 0;
    public int Bob = 0;
    public int Speed = 0;


    void Start()
    {
        waveNumber = 0;
        Bob = 0;
        Speed = 0;
    }
    public GameManager gameManager;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            Time.timeScale = 1;
            this.enabled = false;
        }

        if ((countdown <= 0f) && (Bob == 1))
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            Bob -= 1;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}", countdown);

    }

    IEnumerator SpawnWave()
    {
        playerStats.Rounds++;

        Wave wave = waves[waveNumber];

        EnemiesAlive = wave.maxRBE;
        //a is cluser number, i is enemy in cluster
        for (int a = 0; a < wave.count.Length; a++)
        {
            for (int i = 0; i < wave.count[a]; i++)
            {
                SpawnEnemy(wave.enemy[a]);
                yield return new WaitForSeconds(1f / wave.rate[a]);
            }
            yield return new WaitForSeconds(1f / wave.groupRate[a]);
        }

        waveNumber++;
    }
    void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    }

    public void StartRound()
    {
        if ((countdown <= 0f) && (Bob == 0))
        {
            Bob = +1;
        }
        else if ((countdown > 0f) && (Speed == 0))
        {
            Time.timeScale = 2;
            Speed += 1;
        }
        else if ((countdown > 0f) && (Speed != 0))
        {
            Time.timeScale = 1;
            Speed -= 1;
        }
    }

}
