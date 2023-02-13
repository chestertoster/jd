using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ScoreManager
    {
        private Dictionary<string, int> _playersTimeScore = new Dictionary<string, int>();

        public void AddNewScore(string name, int time)
        {
            string resultName = name;

            if(String.IsNullOrEmpty(name.Trim()))
                resultName = "Player " + (_playersTimeScore.Count + 1);

            if (_playersTimeScore.ContainsKey(resultName))
                _playersTimeScore[resultName] = time;

            else
                _playersTimeScore.Add(resultName, time);
        }

        public string GetPlayerScoreList() 
        {
            StringBuilder resultScoreList = new StringBuilder();

            foreach (var playerScore in _playersTimeScore)
            {
                resultScoreList.AppendLine(playerScore.Key + " " 
                    + TimerStringConverter.GetStringFromSeconds(playerScore.Value));
            }

            return resultScoreList.ToString();
        }
    }
}
