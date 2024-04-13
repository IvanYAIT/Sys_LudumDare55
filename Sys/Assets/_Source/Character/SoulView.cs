using TMPro;
using UnityEngine;

namespace Character
{
    public class SoulView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI soulCounter;

        public void SetSoul(int soul) =>
            soulCounter.text = $"{soul}/5";
    }
}