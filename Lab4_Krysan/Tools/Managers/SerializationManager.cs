using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab4_Krysan.Tools.Managers
{
    internal static class SerializationManager
    {
        internal static void Serialize<TObject>(TObject obj, string filePath)
        {
            try
            {
                var file = new FileInfo(filePath);
                if (file.CreateFolderAndCheckFileExistance())
                {
                    file.Delete();
                }
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Failed to serialize data to file {filePath}", ex);
            }
        }

        internal static TObject Deserialize<TObject>(string filePath) where TObject : class
        {
            try
            {
                if (!FileFolderHelper.CreateFolderAndCheckFileExistance(filePath))
                    throw new FileNotFoundException("File doesn't exist.");
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    return (TObject)formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Failed to Deserialize Data From File {filePath}", ex);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Failed to Deserialize Data From File {filePath}", ex);
            }
        }
    }
}
