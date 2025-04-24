using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PredictKnowledgeLevelApp
{
    public static class TestStudentData
    {
        internal static readonly StudentData student = new StudentData
        {
            STG = 0.90f,
            SCG = 0.08f,
            STR = 0.1f,
            LPR = 0.24f,
            PEG = 0.9f
        };
    }
}
