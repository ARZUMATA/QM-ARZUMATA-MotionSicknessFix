using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

internal static class Helpers
{
    public static string GetMd5HashFromFilePath(string filePath)
    {
        using (var md5 = MD5.Create())
        using (var stream = File.OpenRead(filePath))
        {
            return BitConverter
                .ToString(md5.ComputeHash(stream))
                .Replace("-", "")
                .ToLowerInvariant();
        }
    }

    public static string GetMd5HashFromStream(Stream stream)
    {
        using (var md5 = MD5.Create())
        {
            return BitConverter
                .ToString(md5.ComputeHash(stream))
                .Replace("-", "")
                .ToLowerInvariant();
        }
    }
}
