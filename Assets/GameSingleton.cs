using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames.WordGame
{
    public class GameSingleton : MonoBehaviour
    {

        private static GameSingleton _instance;
        public Sprite divisonActual;
        public Sprite[] divisiones;
        public int porcentajecompletado;
        public Image rankTier;
        public float tnol;
        public float tncl;

        public int numPantalla;

        public static GameSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameSingleton>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = typeof(GameSingleton).Name;
                        _instance = go.AddComponent<GameSingleton>();
                        DontDestroyOnLoad(go);
                    }
                }
                return _instance;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (porcentajecompletado <= 11)
            {
                divisonActual = divisiones[0];
            }
            else if (porcentajecompletado > 11 && porcentajecompletado < 22)
            {
                divisonActual = divisiones[1];

            }
            else if (porcentajecompletado > 22 && porcentajecompletado < 33)
            {
                divisonActual = divisiones[2];

            }
            else if (porcentajecompletado > 33 && porcentajecompletado < 44)
            {
                divisonActual = divisiones[3];

            }
            else if (porcentajecompletado > 44 && porcentajecompletado < 55)
            {
                divisonActual = divisiones[4];

            }
            else if (porcentajecompletado > 55 && porcentajecompletado < 66)
            {
                divisonActual = divisiones[5];

            }
            else if (porcentajecompletado > 66 && porcentajecompletado < 77)
            {
                divisonActual = divisiones[6];

            }
            else if (porcentajecompletado > 77 && porcentajecompletado < 88)
            {
                divisonActual = divisiones[7];

            }
            else if (porcentajecompletado > 88 && porcentajecompletado < 100)
            {
                divisonActual = divisiones[8];

            }

            rankTier.sprite = divisonActual;

        }
    }
}
