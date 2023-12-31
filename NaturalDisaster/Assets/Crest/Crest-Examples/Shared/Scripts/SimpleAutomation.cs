﻿// Crest Ocean System

// Copyright 2020 Wave Harmonic Ltd

#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crest.Examples
{
    /// <summary>
    /// A simple automation script that pauses the game after a time.
    /// </summary>
    public class SimpleAutomation : MonoBehaviour
    {
        /// <summary>
        /// The version of this asset. Can be used to migrate across versions. This value should
        /// only be changed when the editor upgrades the version.
        /// </summary>
        [SerializeField, HideInInspector]
#pragma warning disable 414
        int _version = 0;
#pragma warning restore 414

        static bool _reloadPending = true;

        public int _pauseOnFrame = -1;
        public float _pauseAtTime = -1f;

        void Update()
        {
            if (_reloadPending && Time.time > 2f)
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
                _reloadPending = false;
            }

            if (_pauseOnFrame != -1 && Crest.OceanRenderer.FrameCount >= _pauseOnFrame)
            {
                UnityEditor.EditorApplication.isPaused = true;
            }

            if (_pauseAtTime != -1f && Time.time >= _pauseAtTime)
            {
                UnityEditor.EditorApplication.isPaused = true;
            }
        }
    }
}

#endif
