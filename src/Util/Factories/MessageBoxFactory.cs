using System;
using System.Windows.Forms;

namespace BartenderUI.Util.Factories
{
    class MessageBoxFactory
    {
        private readonly static string REDIS_CONNECTION_ERROR_TEXT = "Nem sikerült csatlakozni az adatbázishoz!";
        private readonly static string REDIS_CONNECTION_ERROR_TITLE = "Csatlakozási hiba";

        private readonly static string EXIT_TEXT = "Biztos be akarod zárni az ablakot?";
        private readonly static string EXIT_TITLE = "Bezárás";

        private readonly static string ONLY_INT_TEXT = "Az 'Ár' mező csak számokat fogad el!";
        private readonly static string ONLY_INT_TITLE = "Csak szám";

        private readonly static string EMPTY_INPUT_TEXT = "Üresen hagyott mező!";
        private readonly static string EMPTY_INPUT_TITLE = "Üres mező";

        private readonly static string NOT_EMPTY_TABLE_TEXT = "Az asztalon van rendezetlen tétel!\nBiztos törli?";
        private readonly static string NOT_EMPTY_TABLE_TITLE = "Rendezetlen asztal";

        private readonly static string DELETE_ALL_TABLE_TEXT = "Biztos törli az összes asztalt?";
        private readonly static string DELETE_ALL_TABLE_TITLE = "Reset";

        private readonly static string FILE_IN_USE_TEXT = "A fájl használatban van!\nZárja be a programot ami használja és próbálja meg újra!";
        private readonly static string FILE_IN_USE_TITLE = "Fájl használatban van";

        private readonly static string COLUMN_COUNT_ERROR_TEXT = "A fájl nem tartalmaz két oszlopt! (Név, Ár)";
        private readonly static string COLUMN_COUNT_ERROR_TITLE = "Hibás fájl";

        private readonly static string ITEM_NOT_FOUND_ERROR_TEXT = "A termék nem található!";
        private readonly static string ITEM_NOT_FOUND_ERROR_TITLE = "Nem található termék";

        private static string ADDED_ITEMS_WITH_ERRORS_TEXT(int arg1, int arg2) { return String.Format("{0} hozzáadva, {1} hiba.\nEllenőrizze, hogy az A oszlopban csak a termék neve van, illetve a B oszlopban csak az ára számokkal leírva vagy esetleg ugyan az a termék szerepel-e kétszer.", arg1, arg2); }
        private static string ADDED_ITEMS_WITHOUT_ERRORS_TEXT(int arg) { return String.Format("{0} hozzáadva.", arg); }
        private readonly static string ADDED_ITEMS_TITLE = "Termék hozzáadás";

        private readonly static string NEW_ORDER_TITLE = "Új rendelés!";

        public static DialogResult Produce(string text, string title, MessageBoxButtons buttons) 
        {
            return MessageBox.Show(text, title, buttons);
        }

        public static DialogResult GetPositiveResult()
        {
            return DialogResult.Yes;
        }

        public static DialogResult GetRetryResult()
        {
            return DialogResult.Retry;
        }

        public static string GetRedisConnectionErrorText()
        {
            return REDIS_CONNECTION_ERROR_TEXT;
        }

        public static string GetRedisConnectionErrorTitle()
        {
            return REDIS_CONNECTION_ERROR_TITLE;
        }

        public static string GetExitText()
        {
            return EXIT_TEXT;
        }

        public static string GetExitTitle()
        {
            return EXIT_TITLE;
        }

        public static string GetOnlyIntText()
        {
            return ONLY_INT_TEXT;
        }

        public static string GetOnlyIntTitle()
        {
            return ONLY_INT_TITLE;
        }

        public static string GetEmptyInputText()
        {
            return EMPTY_INPUT_TEXT;
        }

        public static string GetEmptyInputTitle()
        {
            return EMPTY_INPUT_TITLE;
        }

        public static string GetNotEmptyTableText()
        {
            return NOT_EMPTY_TABLE_TEXT;
        }

        public static string GetNotEmptyTableTitle()
        {
            return NOT_EMPTY_TABLE_TITLE;
        }

        public static string GetDeleteAllTableText()
        {
            return DELETE_ALL_TABLE_TEXT;
        }

        public static string GetDeleteAllTableTitle()
        {
            return DELETE_ALL_TABLE_TITLE;
        }

        public static string GetFileInUseText()
        {
            return FILE_IN_USE_TEXT;
        }

        public static string GetFileInUseTitle()
        {
            return FILE_IN_USE_TITLE;
        }

        public static string GetAddedItemsWithErrorsText(int arg1, int arg2)
        {
            return ADDED_ITEMS_WITH_ERRORS_TEXT(arg1, arg2);
        }

        public static string GetAddedItemsWithoutErrorsText(int arg)
        {
            return ADDED_ITEMS_WITHOUT_ERRORS_TEXT(arg);
        }

        public static string GetAddedItemsTitle()
        {
            return ADDED_ITEMS_TITLE;
        }

        public static string GetColumnCountErrorText()
        {
            return COLUMN_COUNT_ERROR_TEXT;
        }

        public static string GetColumnCountErrorTitle()
        {
            return COLUMN_COUNT_ERROR_TITLE;
        }

        public static string GetNewOrderTitle()
        {
            return NEW_ORDER_TITLE;
        }

        public static string GetItemNotFoundText()
        {
            return ITEM_NOT_FOUND_ERROR_TEXT;
        }

        public static string GetItemNotFoundTitle()
        {
            return ITEM_NOT_FOUND_ERROR_TITLE;
        }
    }
}
