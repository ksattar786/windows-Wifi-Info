using System;
using NativeWifi;
namespace WifiDetails
{
    
 /// <summary>
///  Main Class 
///  Description: This is a simple and quick solution if someone want to get Wifi Information to
///  which it is Connected
///  Developed BY: Kashif 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            GetConnectedWifiDetails();

            //Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Getting Wifi Details 
        /// </summary>
        static void GetConnectedWifiDetails()
        {
            try
            {
                //instantiating Wlan Client Object
                WlanClient client = new WlanClient();              
                    WlanClient.WlanInterface WlanIface = client.Interfaces[0];
                        string State = WlanIface.CurrentConnection.isState.ToString();
                            string ProfileName = WlanIface.CurrentConnection.profileName;
                                 var physicalAddress = WlanIface.CurrentConnection.wlanAssociationAttributes.Dot11Bssid;
                                     byte[] McAddr = WlanIface.CurrentConnection.wlanAssociationAttributes.dot11Bssid;

                                        string Mac = "";
                                        for (int i = 0; i < McAddr.Length; i++)
                                        {
                                            Mac += McAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();
                                        }

                                     //Printing Wifi Fetched Details 
                                    Console.WriteLine("Wifi Name:" + ProfileName + "\n");
                                 Console.WriteLine("Wifi MAC:" + Mac + "\n");
                            Console.WriteLine("Wifi State:" + State + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occoured"+ex.Message);
            }

        }
    }
}
