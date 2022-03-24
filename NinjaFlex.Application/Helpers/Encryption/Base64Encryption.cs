namespace NinjaFlex.Application.Helpers.Encryption
{
    public class Base64Encryption
    {
        public string DecodeFrom64(string decode)
        {
            byte[] encodeDataAsByte = System.Convert.FromBase64String(decode);

            string retorno = System.Text.ASCIIEncoding.UTF8.GetString(encodeDataAsByte);

            return retorno;
        }

        public string EncodeTo64(string encode)
        {
            byte[] toEncodeAsByte = System.Text.ASCIIEncoding.UTF8.GetBytes(encode);

            string retorno = System.Convert.ToBase64String(toEncodeAsByte);

            return retorno;
        }
    }
}
