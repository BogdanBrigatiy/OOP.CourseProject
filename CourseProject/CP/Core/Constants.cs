namespace CP.Core
{
    //клас констант
    public static class Constants
    {
        public const string DefaultFilePath = "Transports.txt";
        public const string DefaultErrorHeader = "Сталася помилка!";
        public const string DefaultWarningHeader = "Попередження!";
        public const string DefaultMessageHeader = "Attention!";
        public const string DefaultMessageBody = "Під час виконання сталася помилка, детальна інформація:";
        public const string UnauthorizedAccessMessage = "Сталася помилка при звертанні до файлу\r\nСхоже, файл використовується іншою програмою або має обмеження прав доступу.\r\nСпробуйте змінити атрибути файлу або змінити політику доступу\r\nДодаткова інформація:\r\n";
    }
}
