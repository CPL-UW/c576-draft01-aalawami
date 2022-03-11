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

        string hoursString = Mathf.Floor((dayNormalized * hoursPerDay) + addHour).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }

}
