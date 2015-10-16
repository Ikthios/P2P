using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServDatabase
    {
        // Entry list for connected peers and their file lists
        private static List<string> peerList = new List<string>();

        /*
        The peer database will be held in a string list. This list will hold the
        IP address of the registered peer and its' files in a comma separated
        string value that will be stored in the string list.

        Example: 192.168.0.30,File1,File2
        
        When a peer is requested or deleted each entry will be examined and identified 
        by splitting the string value in a foreach loop along the commas and looking at
        the first token (the IP address). If token[0] matches the search term the entire
        entry will be returned to the calling method and split during the execution period 
        in the calling method.
        */

        public ServDatabase() { }   // Default constructor

        /*
        Register the peer in the list.
        */
        public void RegisterPeer(string entry)
        {
            //string entry = ipaddress + "," + fileList;
            peerList.Add(entry);
        }

        /*
        Remove the peer from the list.
        */
        public void RemovePeer(string ipaddress)
        {
            foreach(string address in peerList)
            {
                string[] tokens = address.Split(',');
                if (tokens[0].Equals(ipaddress))
                {
                    peerList.Remove(address);
                }
            }
        }

        /*
        Return the peer matching the request search term.
        */
        public string RetreivePeer(string file)
        {
            string returnAddress = "";
            //string searchFile = file.Remove(0, 1);  // Removes the leading comma (',')
            string searchFile = file;
            Console.WriteLine("Searching peerList for " + searchFile);
            foreach(string address in peerList)
            {
                string[] addressTokens = address.Split(',');

                if (addressTokens.Contains(searchFile))
                {
                    //              IP Address               Port         Filename
                    //returnString = (addressTokens[0] + ',' + 5500 + ',' + searchFile);
                    returnAddress = addressTokens[0];
                }
            }
            //                     Key      IP Address      Port       Filename
            string returnString = ("PPR," + returnAddress + ",5500," + searchFile);

            if (returnAddress.Equals(""))
            {
                // Return keycode for (P)eer (N)ot (F)ound
                Console.WriteLine("PNF");
                return ("PNF");
            }
            else
            {
                Console.WriteLine("returnString: " + returnString);
                return returnString;
            }
        }

        /*
        Print the list data
        */
        public void PrintDataList()
        {
            foreach(string entry in peerList)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
