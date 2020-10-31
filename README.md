# EvaluateMLNet

A library that enables the testing of a prediction made by <a href="https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet">ML.NET</a>

## Usage

Pass the Run method a delegate that returns the prediction; for example:

```csharp
var runEvaluation = new RunEvaluation();
var resultStats = runEvaluation.Run<Stats, int>("Data/england-premier-league-matches-2018-to-2019-stats.csv",
    "home_team_red_cards", RunPrediction(a), 2);
```

The returned stats will compare the prediction to a given set of data (in this case, the football stats for 2018 - 19)

