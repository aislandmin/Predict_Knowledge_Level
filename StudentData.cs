using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PredictKnowledgeLevelApp
{
    public class StudentData
    {
        [LoadColumn(0)]
        public float STG; //The degree of study time for goal object materails

        [LoadColumn(1)]
        public float SCG; //The degree of repetition number of user for goal object materails

        [LoadColumn(2)]
        public float STR; //The degree of study time of user for related objects with goal object

        [LoadColumn(3)]
        public float LPR; //The exam performance of user for related objects with goal object

        [LoadColumn(4)]
        public float PEG; //The exam performance of user for goal objects

    }

    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[]? Distances;
    }
}
