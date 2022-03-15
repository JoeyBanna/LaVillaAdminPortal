using System.Net;
using System.Text;

namespace BlazorApp.Helper
{
    public class Base64Converter
    {
        public static String ConvertImageURLToBase64(string url)
        {

            //string url = "https://psl-app-vm3/HotelAdminAPI/images/nmhjgr12.eqi.png";
            //create an object of StringBuilder type.
            StringBuilder _sb = new StringBuilder();
            //create a byte array that will hold the return value of the getImg method
            Byte[] _byte = GetImg(url);
            //appends the argument to the stringbulilder object (_sb)
            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
            //return the complete and final url in a base64 format.
            return _sb.ToString();

        }
        private static byte[] GetImg(string url)
        {
            //create a stream object and initialize it to null
            Stream stream = null;
            //create a byte[] object. It serves as a buffer.
            byte[] buf;
            try
            {
                //Create a new WebProxy object.
                WebProxy myProxy = new WebProxy();
                //create a HttpWebRequest object and initialize it by passing the colleague api url to a create method.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //Create a HttpWebResponse object and initilize it
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                //get the response stream
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    //get the content length in integer
                    int len = (int)(response.ContentLength);
                    //Read bytes
                    buf = br.ReadBytes(len);
                    //close the binary reader
                    br.Close();
                }
                //close the stream object
                stream.Close();
                //close the response object 
                response.Close();
            }
            catch (Exception exp)
            {
                //set the buffer to null
                buf = null;
            }
            //return the buffer
            return (buf);
        }

    }
}
