using AmazonS3.Actions;
using System;


namespace AmazonS3
{
    class Program
    {
        static void Main(string[] args)
        {

            UploadS3File upload = new UploadS3File();
            upload.Action();
            Console.ReadLine();
        }
    }
}
