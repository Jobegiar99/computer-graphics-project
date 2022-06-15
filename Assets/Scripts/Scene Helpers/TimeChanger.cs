using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
        Light myLight;
        [SerializeField] ReceptionNPCManager receptionNPCManager;
        // Start is called before the first frame update
        void Start()
        {
                myLight = GetComponent<Light>();
                StartCoroutine(ManageLight());
        }

        private IEnumerator ManageLight()
        {
                while (true)
                {
                        while(myLight.intensity > 0)
                        {
                                myLight.intensity -= 0.001f;

                                if ( myLight.intensity <= 0.5f)
                                        receptionNPCManager.IsNight = true;

                                yield return new WaitForSecondsRealtime(0.1f);
                        }

                        Material mySkybox = RenderSettings.skybox;
                        RenderSettings.skybox = null;
                        yield return new WaitForSecondsRealtime(0.4f);
                        
                        yield return new WaitForSecondsRealtime(1);
                        Color myAmbient = RenderSettings.ambientLight;
                        RenderSettings.ambientLight = Color.black;
                        RenderSettings.skybox = mySkybox;
                        
                        yield return new WaitForSeconds(5);
                        RenderSettings.ambientLight = myAmbient;
                        while (myLight.intensity < 1)
                        {
                                myLight.intensity += 0.001f;
   
                                if (myLight.intensity > 1)
                                        myLight.intensity = 1;
                                yield return new WaitForSecondsRealtime(0.1f);
                        }
                        receptionNPCManager.IsNight = false;
                }
        }
}
