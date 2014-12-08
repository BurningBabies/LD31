using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float spawnPeriod = 5.0f;
    public float waveTime = 20.0f;
    public float newWaveMultiplier = 0.75f;
    public GameObject enemyPrefab;
    public float areaInnerRadius = 6.0f;
    public float areaOuterRadius = 8.0f;
    public UnityEngine.UI.Text waveText;
    public UnityEngine.UI.Text waveTimerText;

    int wave = 1;
    float timer = 0;
    GameController gc;
    ScoreController sc;

    void Start() {
        StartCoroutine(Spawn());
        StartCoroutine(WaveControl());
        gc = GetComponent<GameController>();
        sc = ScoreController.Get();
        sc.wave = 0;
        sc.score = 0;
    }

    IEnumerator Spawn() {
        for(;;) {
            var position = GetSpawnPos();
            Instantiate(enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnPeriod);
        }
    }

    IEnumerator WaveControl() {
        for(;;) {
            timer = waveTime;
            yield return new WaitForSeconds(waveTime);
            spawnPeriod *= newWaveMultiplier;
            wave++;
            sc.wave = wave;
            gc.ChangeRule();
            audio.Play();
        }
    }

    Vector3 GetSpawnPos() {
        Vector3 pos;
        do {
            pos = Random.insideUnitCircle*areaOuterRadius;
        } while(pos.magnitude < areaInnerRadius);

        return pos;
    }

    void Update() {
        waveText.text = "WAVE " + wave.ToString();
        waveTimerText.text = timer.ToString("0.0");

        timer -= Time.deltaTime;
        if(timer <= 0)
            timer = 0;
    }
}
