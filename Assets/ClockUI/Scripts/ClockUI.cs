/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {

    public const float REAL_SECONDS_PER_INGAME_DAY = 120f;

    public Transform clockHourHandTransform;
    public Transform clockMinuteHandTransform;
    public Text timeText;
    public float day;
    public float addHour = 0;
    public float prevHour = 0;
    public float timeH = 0;
    public float tempTime = 0;

    public float timeB = 1;
    public int points = 0;
    public Text point;

    public GameObject enemy;
    float randX;
    float randY;
    Vector3 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0;
    float enemNum = 0;
    int randTime;
    public Text enemyH;
    public float sgh = 0;



    public void Awake() {
        clockHourHandTransform = transform.Find("hourHand");
        clockMinuteHandTransform = transform.Find("minuteHand");
        timeText = transform.Find("timeText").GetComponent<Text>();
    }

    public void addTime()
    {
        addHour = addHour + 1;
    }

    public void subTime()
    {
        addHour = addHour - 1;
    }

    public void timeBull()
    {
        timeB = timeH;
    }

    public void Update() {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;

        if (prevHour == addHour)
        {
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        } else {
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, (-dayNormalized * rotationDegreesPerDay) - (30 * addHour));
            //prevHour = addHour;
        }
        float hoursPerDay = 12f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        

         
        timeH = Mathf.Floor((dayNormalized * hoursPerDay) + addHour);

        
        if(timeH < 0) { timeH = 12 + timeH; }
        if(timeH > 12) { timeH = timeH - 12; }
        if(timeH == tempTime || timeH == 12) { timeH = 12; }
        if(addHour == 12 || addHour == -12) { addHour = 0; }

        

        string hoursString = timeH.ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;


        
        if (Time.time > nextSpawn && enemNum < 1)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-25f, 25f);

            whereToSpawn = new Vector3(randX, 25, -1);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            enemNum = enemNum + 1;
            randTime = Random.Range(1, 12);
            MonSpawn spawn = new MonSpawn(minutesString);
            sgh = spawn.GetHealth();
            
            enemyH.text = sgh.ToString();
        }



        if (sgh == timeB)
        {
            enemyH.text = "BOOM";
            enemNum = 0;
            points = points + 1;
            sgh = 100;
            timeB = 0;
        }

        


        point.text = "points: " + points.ToString();

    }

}
