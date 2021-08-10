using UnityEngine;
using System.Collections;

public class Environment : Singleton<Environment>
{
    public enum Weather
    {
        Clear,
        Foggy,
        Rainy,
        ThunderStorm,
    }

    public float OneDay = 30.0f;
    public float CurrentTime = 0.0f;

    public float FogFadeTime = 2.0f;
    public float FogDuration = 5.0f;

    public float FogDensity = 0.0f;

    public float RainFadeTime = 2.0f;
    public float RainDuration = 5.0f;

    public float RainIntensity = 0.0f;

    public float ThunderStormFadeTime = 2.0f;
    public float ThunderStormDuration = 10.0f;

    public int CurrentHour { get { return (int)(Instance.CurrentTime * 24); } }

    float lastWeatherTime = 0.0f;
    public Weather currentWeather = Weather.Clear;
    public float WeatherLast { get { return Time.time - lastWeatherTime;  } }

    Weather[] weatherCandidates = { Weather.Clear, Weather.Foggy, Weather.Rainy, Weather.ThunderStorm, };
    float[] weatherChances = { 80, 20, 15, 10 };

    GameObject lightning = null;

    public static string TimeString()
    {
        var h = (int)(Instance.CurrentTime * 24);
        var m = ((Instance.CurrentTime * 24) - h) * 60;
        return string.Format("{0:00}:{1:00}", h, m);
    }

    void Start()
    {
        StartCoroutine(PlayWeathers());
    }

    public void InitializeWithStage(GameObject parent)
    {
        if (lightning != null)
            return;

        lightning = Util.Find(parent, "Lightning");

        if (lightning != null)
            lightning.SetActive(false);
    }

    void PickNextWeather()
    {
        lastWeatherTime = Time.time;
        if (currentWeather != Weather.Clear)
            currentWeather = Weather.Clear;
        else
            currentWeather = Util.GetRandom(weatherCandidates, weatherChances);
    }

    IEnumerator PlayWeathers()
    {
        while (true)
        {
            switch (currentWeather)
            {
                case Weather.Clear:
                    yield return ProcessClear();
                    break;
                case Weather.Foggy:
                    yield return ProcessFog();
                    break;
                case Weather.Rainy:
                    yield return ProcessRain();
                    break;
                case Weather.ThunderStorm:
                    yield return ProcessThunderstorm();
                    break;
            }
            PickNextWeather();
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator ProcessClear()
    {
        yield return new WaitForSeconds(5.0f);
    }

    IEnumerator ProcessFog()
    {
        FogDensity = 0.0f;
                
        while (true)
        {
            FogDensity += Time.deltaTime * (1.0f / FogFadeTime);
            if (FogDensity > 1.0f)
            {
                FogDensity = 1.0f;
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(FogDuration);

        while (true)
        {
            FogDensity -= Time.deltaTime * (1.0f / FogFadeTime);
            if (FogDensity < 0.0f)
            {
                FogDensity = 0.0f;
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        FogDensity = 0.0f;
    }

    IEnumerator ProcessRain()
    {
        RainIntensity = 0.0f;

        while (true)
        {
            RainIntensity += Time.deltaTime * (1.0f / RainFadeTime);
            FogDensity = RainIntensity;
            if (RainIntensity > 1.0f)
            {
                RainIntensity = FogDensity = 1.0f;
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(RainDuration);

        while (true)
        {
            RainIntensity -= Time.deltaTime * (1.0f / RainFadeTime);
            FogDensity = RainIntensity;
            if (RainIntensity < 0.0f)
            {
                RainIntensity = FogDensity = 0.0f;
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        RainIntensity = 0.0f;
    }

    IEnumerator ProcessThunderstorm()
    {
        if (lightning != null)
        {
            var r = 0.0f;
            RainIntensity = 0.0f;

            while (true)
            {
                r += Time.deltaTime * (1.0f / ThunderStormFadeTime);
                FogDensity = r;
                RainIntensity = r * 1.5f;
                if (r > 1.0f)
                {
                    r = FogDensity = 1.0f;
                    break;
                }
                yield return new WaitForEndOfFrame();
            }

            lightning.SetActive(true);
            yield return new WaitForSeconds(ThunderStormDuration);
            lightning.SetActive(false);

            while (true)
            {
                r -= Time.deltaTime * (1.0f / ThunderStormFadeTime);
                FogDensity = r;
                RainIntensity = r * 1.5f;
                if (r < 0.0f)
                {
                    r = FogDensity = 0.0f;
                    break;
                }
                yield return new WaitForEndOfFrame();
            }

            RainIntensity = 0.0f;
        }
    }

    void Update()
    {
        if (OneDay > 0.0f)
            CurrentTime += (1.0f / OneDay) * Time.deltaTime;

        if (CurrentTime > 1.0f)
            CurrentTime = 0.0f;        

        Shader.SetGlobalFloat("_CurrentTime", CurrentTime);
        Shader.SetGlobalFloat("_FogDensity", FogDensity);
    }
}
