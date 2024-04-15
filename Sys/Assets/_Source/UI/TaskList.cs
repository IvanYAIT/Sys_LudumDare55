using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TaskList : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> tasks;
        [SerializeField] private List<Image> tasksImg;

        private int index;

        private void Start()
        {
            index = 0;
            tasks[index].gameObject.SetActive(true);
            tasksImg[index].gameObject.SetActive(true);
        }

        public void NextTask()
        {
            tasks[index].fontStyle = FontStyles.Strikethrough;
            index++;
            tasks[index].gameObject.SetActive(true);
            tasksImg[index].gameObject.SetActive(true);
        }
    }
}