using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ISMWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ISMWebApp.Services
{
    public class S3Service : IS3Service
    {
        public static string Error = "";
        private IAmazonS3 _S3Client { get; set; }
        private const string bucketName = "ism-bucket";
        public S3Service(IOptions<MyAwsS3> configuration) //IAmazonS3 s3Client)
        {
            var credentials = new BasicAWSCredentials(configuration.Value.AccessKey, configuration.Value.SecretKey);
            this._S3Client = new AmazonS3Client(credentials, RegionEndpoint.APSoutheast2);
            // this._S3Client = s3Client;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            try
            {
                var transferUtility = new TransferUtility(this._S3Client);
                var stream = file.OpenReadStream();
                
                await transferUtility.UploadAsync(stream, bucketName, file.FileName);

                var request = new GetPreSignedUrlRequest();
                request.BucketName = bucketName;
                request.Key = file.FileName;
                request.Expires = DateTime.Now.AddHours(1);
                request.Protocol = Protocol.HTTP;

                return this._S3Client.GetPreSignedURL(request);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error = ex.Message;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = key
                    };

                await this._S3Client.DeleteObjectAsync(deleteObjectRequest);

                return true;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error = ex.Message;
            }
            return false;
        }
    }
}