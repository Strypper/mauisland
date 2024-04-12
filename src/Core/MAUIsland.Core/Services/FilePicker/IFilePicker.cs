namespace MAUIsland.Core;

public interface IFilePicker
{
    Task<FileResult> OpenMediaPickerAsync();
    Task<Stream> FileResultToStream(FileResult fileResult);
    Stream ByteArrayToStream(byte[] bytes);
    string ByteBase64ToString(byte[] bytes);
    byte[] StringToByteBase64(string text);
    Task<ImageFile> UploadImageFile(FileResult fileResult);
}
