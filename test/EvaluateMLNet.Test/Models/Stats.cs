using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluateMLNet.Test.Models
{
    public class Stats
    {
        public string home_team_name { get; set; }
        public string away_team_name { get; set; }
        public string referee { get; set; }
        public int home_team_goal_count { get; set; }
        public int away_team_goal_count { get; set; }
        public int home_team_corner_count { get; set; }
        public int home_team_yellow_cards { get; set; }
        public int home_team_red_cards { get; set; }
        public string stadium_name { get; set; }
    }
}
