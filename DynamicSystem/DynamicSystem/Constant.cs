namespace DynamicSystem
{
    public class Constant
    {
        public static string APP_CONNECTION_STRING = "ConnectionString";
        public static string APP_KEY_TABLE = "TableName";
        public static string APP_CREATOR_USERID = "CreatorUserId";

        public static string BACKUP_DATABASE_NAME = "DynamicSystemDb";
        public static string BACKUP_FILE_NAME = "InsertIntoScript";
        public static string BACKUP_FILE_LOCATION = "C:\\FPT\\";

        public static string METHOD_ADD = "Add";
        public static string METHOD_UPDATE = "Update";

        public static string DB_FIELD_ISDELETED = "IsDeleted";
        public static string DB_FIELD_CREATETIONTIME = "CreationTime";
        public static string DB_FIELD_LASTMODIFICATIONTIME = "LastModificationTime";
        public static string DB_FIELD_LASTMODIFIERUSERID = "LastModifierUserId";
        public static string DB_FIELD_CREATORUSERID = "CreatorUserId";

        public static string[] INGORE_FILE = { "AggregatedCounter", "Counter", "Hash", "Job", "JobParameter", "JobQueue"
                , "List", "Schema", "Server", "Set", "State" };
    }
}
