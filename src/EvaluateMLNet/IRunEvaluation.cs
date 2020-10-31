using EvaluateMLNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluateMLNet
{
    public interface IRunEvaluation
    {
        public ResultStats RunFloat<TInputType>(string sampleFile, string predictionFieldName,
            Func<TInputType, float> Prediction, float accuracy) where TInputType : class;

    }
}
