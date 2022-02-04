using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public List<GameObject> controllerPrefabs = new List<GameObject>();
    public InputDeviceCharacteristics controllerCharacteristic;
    public GameObject handModelPrefab;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnHandModel;
    private Animator handAnimator;

    void Start()
    {

        TryInitialaize();
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0f);

        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float GripValue))
        {
            handAnimator.SetFloat("Grip", GripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0f);

        }

    }

    void TryInitialaize()
    {      
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {

            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(conroller => conroller.name == targetDevice.name);

            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {

                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnHandModel.GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (targetDevice == null)
        {
            TryInitialaize();
        }
        else
        {
            if (showController)
            {
                spawnHandModel.SetActive(false);
                spawnedController.SetActive(true);

            }
            else
            {
                spawnHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }

        }

    }
}
