using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class AndroidNotification : MonoBehaviour
    {
        
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnApplicationQuit()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(1), "The knight needs you!", "It's time to increase your high score, don't you think?", Color.yellow);
        }

    }
}
