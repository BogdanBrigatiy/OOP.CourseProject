using CP.Core;
using System.Collections.Generic;
using System.Linq;

namespace CP.Model
{
    //сортувальник
    public static class Sorter
    {
        //за маркою
        public static List<PublicTransport> ByModel(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Model).ToList();
            else return collection.OrderByDescending(p => p.Model).ToList();
        }
        //за типом двигуна
        public static List<PublicTransport> ByEngineType(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.EngineType).ToList();
            else return collection.OrderByDescending(p => p.EngineType).ToList();
        }
        //за потужністю
        public static List<PublicTransport> ByPower(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.EnginePower).ToList();
            else return collection.OrderByDescending(p => p.EnginePower).ToList();
        }
        //за кількістю осей
        public static List<PublicTransport> ByAxles(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Axles).ToList();
            else return collection.OrderByDescending(p => p.Axles).ToList();
        }
        //за кількістю дверей
        public static List<PublicTransport> ByDoors(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Doors).ToList();
            else return collection.OrderByDescending(p => p.Doors).ToList();
        }
        //за пасажиромісткістю
        public static List<PublicTransport> ByCapacity(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.PassengerCapacity).ToList();
            else return collection.OrderByDescending(p => p.PassengerCapacity).ToList();
        }
        //за кількістю сидінь
        public static List<PublicTransport> BySeats(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.Seats).ToList();
            else return collection.OrderByDescending(p => p.Seats).ToList();
        }
        //наявність низької підлоги
        public static List<PublicTransport> ByClearance(List<PublicTransport> collection, Order order)
        {
            if (order == Order.Ascending) return collection.OrderBy(p => p.LowClearance).ToList();
            else return collection.OrderByDescending(p => p.LowClearance).ToList();
        }
    }
}
