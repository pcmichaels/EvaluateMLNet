using EvaluateMLNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluateMLNet
{
    public interface IRunEvaluation
    {
        public ResultStats Run<TInputType, TPredictionType>(string sampleFile, string predictionFieldName,
            Func<TInputType, TPredictionType> Prediction, float accuracy) where TInputType : class;

    }
}
