using CommunityToolkit.HighPerformance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Select;
using Minio.Helper;

var endpoint = "minio-api-bit.28.sohan.cloud";
var accessKey = "petaverse";
var secretKey = "jyGRA9pgYHQT7UUj7ho3wp6d5odMu4Fy";
var bucketName = "petaverse";

var builder = WebApplication.CreateBuilder();
var minio = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            .WithSSL(true)
            .Build();


// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
builder.Services.AddSingleton<IMinioClient>(minio);

var serviceProvider = builder.Services.BuildServiceProvider();

var buckets = await minio.ListBucketsAsync().ConfigureAwait(false);
//var bucket = buckets.Buckets.FirstOrDefault(x => x.Name == "petaverse");
//var url = await minio.PresignedGetObjectAsync(new PresignedGetObjectArgs()
//                .WithBucket(bucket.Name));
//Console.WriteLine(url);

var progress = new SyncProgress<ProgressReport>(progressReport =>
{
    Console.WriteLine(
        $"Percentage: {progressReport.Percentage}% TotalBytesTransferred: {progressReport.TotalBytesTransferred} bytes");
    if (progressReport.Percentage != 100)
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    else Console.WriteLine();
});
ReadOnlyMemory<byte> bs = await File.ReadAllBytesAsync("C:\\Users\\Hung\\Downloads\\images.png").ConfigureAwait(false);
using var filestream = bs.AsStream();

//upload
var objName = $"Hung-test-{Guid.NewGuid()}.png";
var fileName = "C:/Users/Hung/Downloads/images.png";
var contentType = "application/octet-stream";
var metaData = new Dictionary<string, string>
    (StringComparer.Ordinal) { { "Test-Metadata", "Test  Test" } };
var putArgs = new PutObjectArgs()
    .WithBucket("petaverse")
    .WithObject(objName)
    .WithStreamData(filestream)
    .WithObjectSize(filestream.Length)
    .WithContentType(contentType)
    .WithServerSideEncryption(null);
_ = await minio.PutObjectAsync(putArgs).ConfigureAwait(false);

//check stat after upload
StatObjectArgs statObjectArgs = new StatObjectArgs().WithBucket(bucketName).WithObject(objName);
var objStat = await minio.StatObjectAsync(statObjectArgs);
Console.WriteLine($"Name: {objStat.ObjectName} - ETag: {objStat.ETag} - VersionId: {objStat.VersionId} - ContentType: {objStat.ContentType} - Size: {objStat.Size}");

//list
var listArg = new ListObjectsArgs()
    .WithBucket("petaverse");
await foreach(var item in minio.ListObjectsEnumAsync(listArg))
{
    Console.WriteLine($"Object: {item.Key} - {item.ContentType}");
}

File.Delete("C:\\Users\\Hung\\Downloads\\newfirst-object");
var getArg = new GetObjectArgs()
    .WithBucket("petaverse")
    .WithObject(objName)
    .WithCallbackStream((stream) =>
    {
        stream.CopyTo(Console.OpenStandardOutput());
    })
    //.WithFile("C:/Users/Hung/Downloads")
    .WithServerSideEncryption(null);
_ = await minio.GetObjectAsync(getArg).ConfigureAwait(false);

Console.WriteLine($"Downloaded Done");

var queryType = QueryExpressionType.SQL;
var queryExpr = "select count(*) from s3object";
var inputSerialization = new SelectObjectInputSerialization
{
    CompressionType = SelectCompressionType.NONE,
    CSV = new CSVInputOptions
    {
        FileHeaderInfo = CSVFileHeaderInfo.None,
        RecordDelimiter = "\n",
        FieldDelimiter = ","
    }
};
var outputSerialization = new SelectObjectOutputSerialization
{
    CSV = new CSVOutputOptions { RecordDelimiter = "\n", FieldDelimiter = "," }
};

var selectObjectArg = new SelectObjectContentArgs()
                .WithBucket("petaverse")
                .WithObject("first-object")
                .WithExpressionType(queryType)
                .WithQueryExpression(queryExpr)
                .WithInputSerialization(inputSerialization)
                .WithOutputSerialization(outputSerialization)
                ;
var resp = await minio.SelectObjectContentAsync(selectObjectArg).ConfigureAwait(false);
using var standardOutput = Console.OpenStandardOutput();
await resp.Payload.CopyToAsync(standardOutput).ConfigureAwait(false);
Console.WriteLine("Bytes scanned:" + resp.Stats.BytesScanned);
Console.WriteLine("Bytes returned:" + resp.Stats.BytesReturned);
Console.WriteLine("Bytes processed:" + resp.Stats.BytesProcessed);
if (resp.Progress is not null) Console.WriteLine("Progress :" + resp.Progress.BytesProcessed);
var a = "";

