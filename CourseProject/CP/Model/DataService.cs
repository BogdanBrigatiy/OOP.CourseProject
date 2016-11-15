using System;
using System.Collections.Generic;

namespace CP.Model
{
    public class DataService : IDataService
    {
        public void GetTrasportList(Action<List<PublicTransport>, Exception> callback)
        {
            // Use this to connect to the actual data service

            var transportList = new List<PublicTransport>();
            //var v = ;
            transportList.Add(new PublicTransport() { Axles = 2, EnginePower = 100, PassengerCapacity = 30, LowClearance = true });
            transportList.Add(new PublicTransport() { Axles = 3, EnginePower = 150, PassengerCapacity = 25, LowClearance = false });
            transportList.Add(new PublicTransport() { Axles = 3, EnginePower = 90, PassengerCapacity = 35, LowClearance = false });
            //var item = new DataItem("Welcome to MVVM Light");
            callback(transportList, null);
        }
        public List<PublicTransport> GetTrasportListNoCallback()
        {
            var transportList = new List<PublicTransport>();
            //var v = ;
            transportList.Add(new PublicTransport() { Axles = 2, EnginePower = 100, PassengerCapacity = 30, LowClearance = true });
            transportList.Add(new PublicTransport() { Axles = 3, EnginePower = 150, PassengerCapacity = 25, LowClearance = false });
            transportList.Add(new PublicTransport() { Axles = 3, EnginePower = 90, PassengerCapacity = 35, LowClearance = false });

            return transportList;
        }
    }
}