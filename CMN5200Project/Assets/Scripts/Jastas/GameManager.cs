using UnityEngine;

namespace Jastas {

    public class GameManager : MonoBehaviour {

        private static GameManager m_instance;

        public static GameManager Instance { get { return m_instance; }}

        void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}