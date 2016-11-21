using System;
using System.Collections.Generic;

namespace CP.Model
{
    //інтерфейс провайдера даних
    public interface IDataService
    {
        void GetTrasportList(Action<List<PublicTransport>, Exception> callback);
        List<PublicTransport> GetTrasportListNoCallback();
        bool ExportTransportList(List<PublicTransport> exportable);
        List<PublicTransport> ImportTransportList();
        PublicTransport ImportSingle(PublicTransport t);
        bool ExportSingle(PublicTransport t);
    }
}
