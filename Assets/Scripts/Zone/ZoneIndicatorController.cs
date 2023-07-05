using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zone
{
    public class ZoneIndicatorController : MonoBehaviour
    {
        public void updateZones(int currentZoneNumber)
        {

            int offset = (int)(Mathf.Floor(transform.childCount / 2));

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                ZoneController childZoneController = child.GetComponent<ZoneController>();
                childZoneController.updateZone(currentZoneNumber - offset + i);
            }
        }
    }
}