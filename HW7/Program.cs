using HW7;
using Newtonsoft.Json;

F f = F.Get();
int iterations = 100000;

// Reflection сериализация
var (csv, serializationTime) = PerformanceMeasurer.MeasureWithResult(
	() => CsvSerializer.SerializeToCsv(f),
	iterations);

long consoleTime = PerformanceMeasurer.Measure(
	() => Console.WriteLine(CsvSerializer.SerializeToCsv(f)),
	iterations);

// JSON сериализация
var (jsonString, jsonTime) = PerformanceMeasurer.MeasureWithResult(
	() => JsonConvert.SerializeObject(f),
	iterations);

// Reflection десериализация
string csvData = "10,20,30,40,50";
long deserTime = PerformanceMeasurer.Measure(
	() => CsvSerializer.DeserializeFromCsv(csvData),
	iterations);

// JSON десериализация
string jsonData = "{\"i1\":100,\"i2\":200,\"i3\":300,\"i4\":400,\"i5\":500}";
long jsonDeserTime = PerformanceMeasurer.Measure(
	() => JsonConvert.DeserializeObject<F>(jsonData),
	iterations);

// результаты
Console.WriteLine("Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}");
Console.WriteLine($"количество замеров: {iterations} итераций");
Console.WriteLine("мой рефлекшен:");
Console.WriteLine($"Время на сериализацию = {serializationTime} мс");
Console.WriteLine($"Время на десериализацию = {deserTime} мс");
Console.WriteLine("стандартный механизм (NewtonsoftJson):");
Console.WriteLine($"Время на сериализацию = {jsonTime} мс");
Console.WriteLine($"Время на десериализацию = {jsonDeserTime} мс");