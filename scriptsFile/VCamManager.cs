using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cinemachine;
using Player;

namespace ControlledCamera
{
    public enum CamMode
    {
        ZoomIn,
        ZoomOut,
        Shoot,
        Normal
    }
    public class VCamManager : MonoBehaviour
    {
        public GameObject zoomIn;
        public GameObject zoomOut;
        public GameObject shootL;
        public GameObject shootR;
        public GameObject normal;
        public CamMode replaceNormal;
        IEnumerator switchCoroutine;
        IEnumerator stopShakeCoroutine;
        PlayerDirection playerDirection;
        GameObject activeVCam;

        void Start()
        {
            replaceNormal = CamMode.Normal;
            DisableAllCam();
            _SetCamMode(CamMode.Normal);
        }

        void DisableAllCam()
        {
            zoomIn.SetActive(false);
            zoomOut.SetActive(false);
            shootL.SetActive(false);
            shootR.SetActive(false);
            normal.SetActive(false);
        }

        void _SetCamMode(CamMode camMode)
        {
            switch (camMode)
            {
                case CamMode.Normal:
                    normal.SetActive(true);
                    activeVCam = normal;
                    break;
                case CamMode.Shoot:
                    if (playerDirection == PlayerDirection.Left)
                    {
                        shootL.SetActive(true);
                        activeVCam = shootL;
                    }
                    else
                    {
                        shootR.SetActive(true);
                        activeVCam = shootR;
                    }
                    break;
                case CamMode.ZoomIn:
                    zoomIn.SetActive(true);
                    activeVCam = zoomIn;
                    break;
                case CamMode.ZoomOut:
                    zoomOut.SetActive(true);
                    activeVCam = zoomOut;
                    break;
            }
        }

        void _StopShake(GameObject vcam)
        {
            CinemachineBasicMultiChannelPerlin noiseComponent = vcam
                .GetComponent<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noiseComponent.m_AmplitudeGain = 0;
            noiseComponent.m_FrequencyGain = 0;
        }

        public void SetPlayerDirection(PlayerDirection playerDirection)
        {
            this.playerDirection = playerDirection;
        }

        public void SetCamMode(CamMode camMode, Action callback, Action invertCallback, float duration = 1)
        {
            if (switchCoroutine != null)
            {
                StopCoroutine(switchCoroutine);
            }
            DisableAllCam();
            _SetCamMode(camMode);
            switchCoroutine = SwitchTimeout(duration, invertCallback);
            StartCoroutine(switchCoroutine);
            callback();
        }
        public void SetCamMode(CamMode camMode, float duration = 1)
        {
            if (switchCoroutine != null)
            {
                StopCoroutine(switchCoroutine);
            }
            DisableAllCam();
            _SetCamMode(camMode);
            if (duration < 0)
            {
                return;
            }
            switchCoroutine = SwitchTimeout(duration);
            StartCoroutine(switchCoroutine);
        }

        public void Shake(float shakeAmp = 1, float shakeFrequency = 4, float duration = 0.3f)
        {
            if (stopShakeCoroutine != null)
            {
                StopCoroutine(stopShakeCoroutine);
            }

            CinemachineBasicMultiChannelPerlin noiseComponent = activeVCam
                .GetComponent<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noiseComponent.m_AmplitudeGain = shakeAmp;
            noiseComponent.m_FrequencyGain = shakeFrequency;

            stopShakeCoroutine = StopShakeCoroutine(duration);
            StartCoroutine(stopShakeCoroutine);
        }

        public void StopShake()
        {
            _StopShake(normal);
            _StopShake(shootL);
            _StopShake(shootR);
            _StopShake(zoomIn);
            _StopShake(zoomOut);
        }

        IEnumerator StopShakeCoroutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            StopShake();
        }

        IEnumerator SwitchTimeout(float duration, Action invertCallback)
        {
            yield return new WaitForSeconds(duration);
            invertCallback();
            _SetCamMode(replaceNormal);
        }

        IEnumerator SwitchTimeout(float duration)
        {
            yield return new WaitForSeconds(duration);
            _SetCamMode(replaceNormal);
        }
    }
}
