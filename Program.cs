// See https://aka.ms/new-console-template for more information
using Microsoft.ML;
using PredictKnowledgeLevelApp;

string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "Student.csv");
string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "StudentClusteringModel.zip");

var mlContext = new MLContext(seed: 0);
IDataView dataView = mlContext.Data.LoadFromTextFile<StudentData>(_dataPath, hasHeader: false, separatorChar: ',');


string featuresColumnName = "Features";
var pipeline = mlContext.Transforms
    .Concatenate(featuresColumnName, "STG", "SCG", "STR", "LPR", "PEG")
    .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 4)); //"High," "Middle," "Low," "very_low" 

var model = pipeline.Fit(dataView);

using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
{
    mlContext.Model.Save(model, dataView.Schema, fileStream);
}

var predictor = mlContext.Model.CreatePredictionEngine<StudentData, ClusterPrediction>(model);

var prediction = predictor.Predict(TestStudentData.student);
Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances ?? Array.Empty<float>())}");

