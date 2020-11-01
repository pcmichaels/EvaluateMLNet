using EvaluateMLNet.Test.Models;
using System;
using System.IO;
using Xunit;

namespace EvaluateMLNet.Test
{
    public class FloatTest
    {
        [Fact]
        public void CorrectlyEvaluatesResults()
        {
            var runEvaluation = new RunEvaluation();
            var resultStats = runEvaluation.Run<Stats, int>("Data/england-premier-league-matches-2018-to-2019-stats.csv",
                "home_team_yellow_cards", (a) => 2, 0);

            Assert.Equal(107, resultStats.SuccessCount);
        }

        [Fact]
        public void CorrectlyEvaluatesResults_Accuracy()
        {
            var runEvaluation = new RunEvaluation();
            var resultStats = runEvaluation.Run<Stats, int>("Data/england-premier-league-matches-2018-to-2019-stats.csv",
                "home_team_yellow_cards", (a) => 2, 1);

            Assert.Equal(272, resultStats.SuccessCount);
        }

    }
}
