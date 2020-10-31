using Castr;
using Castr.Options;
using EvaluateMLNet.Models;
using System;
using System.IO;
using System.Linq;

namespace EvaluateMLNet
{
    public class RunEvaluation : IRunEvaluation
    {
        /// <summary>
        /// Analyse the machine learning result        
        /// </summary>
        /// <typeparam name="TInputType"></typeparam>
        /// <typeparam name="TPrediction"></typeparam>
        /// <param name="sampleFile"></param>
        /// <param name="predictionFieldName">
        /// Name of the field that you are trying to predict
        /// Must be a float, or convertable to one
        /// </param>
        /// <returns></returns>
        public ResultStats Run<TInputType, TPredictionType>(string sampleFile, string predictionFieldName,
            Func<TInputType, TPredictionType> Prediction, float accuracy) where TInputType : class
        {
            string csvData = File.ReadAllText(sampleFile);
            var csv = new Castr.CSV.CastrCSVMulti(csvData, ",", true);

            var sampleDataList = csv.CastAsClassMulti<TInputType>();

            int success = 0;

            foreach (var sampleData in sampleDataList)
            {
                var castr = new CastrClass<TInputType>(
                    sampleData, new ClassOptions()
                    {
                        IsStrict = false
                    });
                var result = castr.ExtractField<TPredictionType>(predictionFieldName);                
                
                var predictedValue = Prediction(sampleData);

                decimal predictedValueDec = (decimal)Convert.ChangeType(predictedValue, typeof(decimal));
                int low = (int)Math.Floor(predictedValueDec);
                int high = (int)Math.Ceiling(predictedValueDec);

                if (TestRange<TPredictionType>(result, low, high))
                {
                    success++;
                }                
            }

            var resultStats = new ResultStats()
            {
                EvaluatedCount = sampleDataList.Count(),
                SuccessCount = success
            };
            return resultStats;
        }

        private bool TestRange<T>(T numberToCheck, int bottom, int top)
        {
            var convertedNumberToCheck = (decimal)Convert.ChangeType(numberToCheck, typeof(decimal));
            return convertedNumberToCheck >= bottom && convertedNumberToCheck <= top;
        }

    }
}
