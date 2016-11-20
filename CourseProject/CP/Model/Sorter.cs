using CP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Model
{
    public static class Sorter
    {
        public static List<PublicTransport> ByModel(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Model).ToList();
            else return collection.OrderByDescending(p => p.Model).ToList();
        }
        public static List<PublicTransport> ByEngineType(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.EngineType).ToList();
            else return collection.OrderByDescending(p => p.EngineType).ToList();
        }
        public static List<PublicTransport> ByPower(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.EnginePower).ToList();
            else return collection.OrderByDescending(p => p.EnginePower).ToList();
        }
        public static List<PublicTransport> ByAxles(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Axles).ToList();
            else return collection.OrderByDescending(p => p.Axles).ToList();
        }
        public static List<PublicTransport> ByDoors(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Doors).ToList();
            else return collection.OrderByDescending(p => p.Doors).ToList();
        }
        public static List<PublicTransport> ByCapacity(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.PassengerCapacity).ToList();
            else return collection.OrderByDescending(p => p.PassengerCapacity).ToList();
        }
        public static List<PublicTransport> BySeats(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Seats).ToList();
            else return collection.OrderByDescending(p => p.Seats).ToList();
        }
        public static List<PublicTransport> ByClearance(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.LowClearance).ToList();
            else return collection.OrderByDescending(p => p.LowClearance).ToList();
        }
    }
}
