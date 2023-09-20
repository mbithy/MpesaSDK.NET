using MpesaSDK.NET;
using MpesaSDK.NET.Dtos.Requests;
using System;
using System.Text;
using System.Threading.Tasks;
using MpesaSDK.NET.Enums;

namespace ClientTest
{
    internal class Program
    {
        // ETHICUS
         private static string consumerkey = "lMMLbzUmlBz2EZ87v6aHT1KssYk379yB";
        private static string consumersecret = "cMUoF7tLpKS1430l";
        private static string businesscode = "3012521"; //partyA
        private static string phonenumber = "254705593689"; //partyB
        private static string passkey = "63f56bb51eeb487115ec3d86c9000b54ef73ddaa6f65645eff9f3ef9316978dd";
        private static string stkPushCallbackURL = "https://example.com";
        public static string initiatorName = "Mbithi";//partyA name
        public static string password = "Mkn$6060mkn"; //initiator password*/

        //TF
        /*private static string consumerkey = "F4ZD8DYWT8HA6f4JMs19SCme5nkeEmdj";
        private static string consumersecret = "Bv9DvoZelUDGRWkL";
        private static string businesscode = "884500"; //partyA
        private static string phonenumber = "254705593689"; //partyB
        private static string passkey = "63f56bb51eeb487115ec3d86c9000b54ef73ddaa6f65645eff9f3ef9316978dd";
        private static string stkPushCallbackURL = "https://example.com";
        public static string initiatorName = "Prod-tourism-fund-19339934";//partyA name
        public static string password = "ikhPhyCdeEVX34ut3V"; //initiator password*/


        // NDOVU NINE
        /*private static string consumerkey = "8DImvlZ2jzvnsLPN6xsXhvx80S8RsLCP";
        private static string consumersecret = "fOSf6MIAukcqBKQn";
        private static string businesscode = "4086545"; //partyA
        private static string phonenumber = "254705593689"; //partyB
        private static string passkey = "8b4439fb24eb55cafaa9e06be667a429420870302bbe0a5bbd14a8a2c369ab6e";
        private static string stkPushCallbackURL = "https://oyu.ndovunine.com/api/b3l1d2FsbGV0TXBlc2E/TXBlc2FjYWxsYmFja295dXdhbGxldA";
        public static string initiatorName = "ndovunine.api";//partyA name
        public static string password = "Mkn$4848mkn"; //initiator password*/

        static MpesaClient mpesaclient = new MpesaClient(consumerkey, consumersecret,false);

        private static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Started!");
                //Console.WriteLine(password.ToMpesaSecurityCredential());
                //return;
                //await StkPushExample();

                //await StkQueryExample();

                await B2CExample();

                //await ReversalExample();

                //await RegisterEndpoints();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! -> " + ex.Message);
            }


            Console.ReadKey();
            Console.ReadKey();
        }

        private static async Task StkPushExample()
        {
            var res = await mpesaclient.STKPushAsync(businesscode, phonenumber, 5, passkey, stkPushCallbackURL, accountReference: "TESTY", transactionDesc: "Event Ticket");

            Console.WriteLine(res.ToString());
        }


        private static async Task StkQueryExample()
        {
            var result = await mpesaclient.StkPushQueryAsync(businesscode,/*"your-checkout-request-id"*/"ws_CO_260320201332029957", passkey);
            Console.WriteLine(result.ToString());
        }

        private static async Task B2CExample()
        {
            //valid commands SalaryPayment, BusinessPayment, PromotionPayment
            //change result and timeout urls
            var result = await mpesaclient.B2CAsync(initiatorName.ToUpper(), password, Command.BusinessPayment, 20, businesscode, phonenumber, "remarks", "https://oyu.ndovunine.com/api/b3l1d2FsbGV0TXBlc2E/TXBlc2Fjb25maXJtYXRpb25veXV3YWxsZXQ", "https://oyu.ndovunine.com/api/b3l1d2FsbGV0TXBlc2E/TXBlc2Fjb25maXJtYXRpb25veXV3YWxsZXQ", "occassion");
            Console.WriteLine(result.ToString());
        }

        private static async Task ReversalExample()
        {
            var result = await mpesaclient.ReversalAsync(businesscode, password, businesscode, MpesaSDK.NET.Enums.IdentifierType.Shortcode, "ADVFR4355", 10, "https://timeouturl.com", "https://resulturl.com");
            Console.WriteLine(result.ToString());

        }

        private static async Task RegisterEndpoints()
        {
            var result = await mpesaclient.C2BRegisterUrlAsync("https://oyu.ndovunine.com/api/b3l1d2FsbGV0TXBlc2E/TXBlc2F2YWxpZGF0aW9ub3l1d2FsbGV0", "https://oyu.ndovunine.com/api/b3l1d2FsbGV0TXBlc2E/TXBlc2Fjb25maXJtYXRpb25veXV3YWxsZXQ", ResponseType.Canceled, businesscode);
            Console.WriteLine(result.ToString());
        }
    }
}

