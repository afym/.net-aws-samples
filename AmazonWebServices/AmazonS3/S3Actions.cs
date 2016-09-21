using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace AmazonS3.Actions
{
    class AmazonS3Connection 
    {
        public static Credential Credential;

        public static AmazonS3Client GetConnection() 
        {
            if (Credential == null)
            {
                Credential = new Credential();
            }

            AmazonS3Config configuration = new AmazonS3Config();
            configuration.ServiceURL = Credential.ServiceUrl;            

            AmazonS3Client connection = new AmazonS3Client(
                 Credential.Access,
                 Credential.Private,
                 configuration
            );

            return connection;
        }
    }

    interface S3Action
    {
        void Action();
    }

    class UploadS3File : S3Action
    {
        public void Action() 
        {
            AmazonS3Client connection = AmazonS3Connection.GetConnection();
            PutObjectRequest request = new PutObjectRequest();
            request.BucketName = AmazonS3Connection.Credential.Bucket;
            request.Key = "foo/var/aws-logo-new.png";
            request.ContentType = "image/png";
            request.FilePath = "Images/aws-logo.png";
            request.CannedACL = S3CannedACL.PublicRead; // File public read
            var response = connection.PutObject(request);
            Console.WriteLine(response);
        }
    }
}
