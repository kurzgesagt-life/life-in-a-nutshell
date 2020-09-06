using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {

    public class ResourceManager : MonoBehaviour {
        public static ResourceManager resourceManager;

        public Dictionary<string, int> resources;

        #region Singleton
        private void Awake () {
            if (resourceManager == null) {
                resourceManager = this;
            } else {
                Destroy (this.gameObject);
            }
        }
        #endregion

        void Start () {
            resources = new Dictionary<string, int> ();
            resources.Add ("wood", 5);
            resources.Add ("food", 5);
            resources.Add ("energy", 5);
            resourceManager.resources = resources;
        }
        public event Action onBuildHouse;
        public void BuildHouse () {
            if (resources["wood"] >= 20) {
                if (onBuildHouse != null) {
                    resources["wood"] -= 20;
                    onBuildHouse ();
                }
            }
        }

        public event Action onBuildGenerator;
        public void BuildGenerator () {
            if (resources["wood"] >= 30) {
                if (onBuildGenerator != null) {
                    resources["wood"] -= 30;
                    resources["energy"] += 20;
                    onBuildGenerator ();
                }
            }
        }

        public void ChangeFood (int food) {
            resources["food"] += food;
        }
        public void ChangeWood (int wood) {
            resources["wood"] += wood;
        }
        public void ChangeEnergy (int energy) {
            resources["energy"] += energy;
        }
    }
}