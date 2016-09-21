using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AmazonS3
{
    class Credential
    {
        public string ServiceUrl { get; set; }
        public string Access { get; set; }
        public string Private { get; set; }
        public string Bucket { get; set; }
        private XmlDocument Document;

        public Credential() 
        {
            this.GetXmlCredential();
            this.SetCredential();
        }

        private void GetXmlCredential() 
        {
            this.Document = new XmlDocument();
            this.Document.Load("Config/s3.credential.xml");
        }

        private void SetCredential() 
        {
            var credential = this.Document.GetElementsByTagName("Credential");
			
			if (credential.Count != 1) {
                throw new Exception("You must have only one credential per file");
            }

            this.Access = credential[0].SelectSingleNode("Access").InnerText;
            this.Private = credential[0].SelectSingleNode("Private").InnerText;
            this.ServiceUrl = credential[0].SelectSingleNode("ServiceUrl").InnerText;
            this.Bucket = credential[0].SelectSingleNode("Bucket").InnerText;
        }
    }
}
