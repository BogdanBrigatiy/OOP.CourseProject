using CP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CP.Model.Filtering
{
    
    public class Filter
    {
        //public
        public List<PublicTransport> ByEnginePower(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;
            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.EnginePower == arg.Sample);//.Take(takeValue).ToList(); //takeValue
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.EnginePower > arg.Sample);//.Take(takeValue).ToList();
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.EnginePower < arg.Sample);//.Take(takeValue).ToList();
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.EnginePower <= arg.Sample);//.Take(takeValue).ToList();
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.EnginePower >= arg.Sample);//.Take(takeValue).ToList();
                        break;
                    default:
                        result = collection;//.Take(takeValue).ToList(); ;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> BySeats(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;// = new List<PublicTransport>();

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.Seats == arg.Sample);
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.Seats > arg.Sample);
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.Seats < arg.Sample);
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.Seats <= arg.Sample);
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.Seats >= arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }
            return result;
        }
        public List<PublicTransport> ByAxles(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;// = new List<PublicTransport>();

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.Axles == arg.Sample);
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.Axles > arg.Sample);
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.Axles < arg.Sample);
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.Axles <= arg.Sample);
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.Axles >= arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> ByClearance(SimpleFilterArgument<bool> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;
            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.LowClearance == arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> ByDoors(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;// = new List<PublicTransport>();

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.Doors == arg.Sample);
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.Doors > arg.Sample);
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.Doors < arg.Sample);
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.Doors <= arg.Sample);
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.Doors >= arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }

        public List<PublicTransport> ByStandingRoom(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;// = new List<PublicTransport>();

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.PassengerCapacity - p.Seats == arg.Sample);
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.PassengerCapacity - p.Seats > arg.Sample);
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.PassengerCapacity - p.Seats < arg.Sample);
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.PassengerCapacity - p.Seats <= arg.Sample);
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.PassengerCapacity - p.Seats >= arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> ByModel(SimpleFilterArgument<string> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        if (arg.Sample == string.Empty || arg.Sample == null) return collection.FindAll(p => p.Model == null);
                        result = collection.FindAll(p => p.Model != null && p.Model.ToLower().Contains(arg.Sample.ToLower()));
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> ByEngineType(SimpleFilterArgument<EEngineType> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.EngineType == arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        public List<PublicTransport> ByCapacity(SimpleFilterArgument<int> arg, List<PublicTransport> collection)
        {
            List<PublicTransport> result;

            try
            {
                switch (arg.Comparer)
                {
                    case SimpleComparer.Equal:
                        result = collection.FindAll(p => p.PassengerCapacity == arg.Sample);
                        break;
                    case SimpleComparer.Bigger:
                        result = collection.FindAll(p => p.PassengerCapacity > arg.Sample);
                        break;
                    case SimpleComparer.Smaller:
                        result = collection.FindAll(p => p.PassengerCapacity < arg.Sample);
                        break;
                    case SimpleComparer.NotBigger:
                        result = collection.FindAll(p => p.PassengerCapacity <= arg.Sample);
                        break;
                    case SimpleComparer.NotSmaller:
                        result = collection.FindAll(p => p.PassengerCapacity >= arg.Sample);
                        break;
                    default:
                        result = collection;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                result = new List<PublicTransport>();
            }

            return result;
        }
        //private
    }
}
