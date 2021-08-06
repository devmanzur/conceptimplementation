using System;
using System.Data;

namespace Concepts.Core.Builders
{
    /**
     * A staged builder component that forces users to follow a order
     * when creating a object using builder
     *
     * This helps to force users to follow a order and provide necessary
     * information all while following the builder pattern
     */
    public class DatabaseConnectionBuilder : IDatabaseConnectionBuilderHostSelectionStage,
        IDatabaseConnectionBuilderDatabaseSelectionStage, IDatabaseConnectionBuilderCredentialSelectionStage,
        IConnectionInitializerStage
    {
        private string _host;
        private string _databaseName;
        private DatabaseEngine _databaseEngine = DatabaseEngine.InnoDB;
        private string _databaseVersion = "~5.0";
        private DatabaseUser _user;

        private DatabaseConnectionBuilder()
        {
        }

        public static IDatabaseConnectionBuilderHostSelectionStage CreateConnection()
        {
            return new DatabaseConnectionBuilder();
        }

        public IDatabaseConnectionBuilderDatabaseSelectionStage WithHost(string host)
        {
            _host = host;
            return this;
        }

        public IDatabaseConnectionBuilderCredentialSelectionStage WithDatabase(string databaseName)
        {
            _databaseName = databaseName;
            return this;
        }

        public IConnectionInitializerStage WithCredential(Action<DatabaseUser> credentialSetup)
        {
            _user = new DatabaseUser();
            //invoke is conditional since user may not pass any function;
            credentialSetup?.Invoke(_user);
            return this;
        }

        public IConnectionInitializerStage SetDatabaseEngine(DatabaseEngine engine)
        {
            _databaseEngine = engine;
            return this;
        }

        public IConnectionInitializerStage SetDatabaseVersion(string versionCode)
        {
            _databaseVersion = versionCode;
            return this;
        }

        public DatabaseConnection Connect()
        {
            return new DatabaseConnection(_host, _databaseName, _user.Username, _user.Password,_databaseEngine,_databaseVersion);
        }
    }

    public interface IDatabaseConnectionBuilderHostSelectionStage
    {
        public IDatabaseConnectionBuilderDatabaseSelectionStage WithHost(string host);
    }

    public interface IDatabaseConnectionBuilderDatabaseSelectionStage
    {
        public IDatabaseConnectionBuilderCredentialSelectionStage WithDatabase(string databaseName);
    }

    public interface IDatabaseConnectionBuilderCredentialSelectionStage
    {
        public IConnectionInitializerStage WithCredential(Action<DatabaseUser> credentialSetup);
    }

    public interface IConnectionInitializerStage
    {
        public IConnectionInitializerStage SetDatabaseEngine(DatabaseEngine engine);
        public IConnectionInitializerStage SetDatabaseVersion(string versionCode);
        public DatabaseConnection Connect();
    }


    public enum DatabaseEngine
    {
        MariaDB,
        InnoDB
    }

    public class DatabaseConnection
    {
        public string Host { get; }
        public string Database { get; }
        public string DatabaseVersion { get; }
        public DatabaseEngine DatabaseEngine { get; }
        public string Username { get; }
        public string Password { get; }

        public DatabaseConnection(string host, string database, string username, string password,
            DatabaseEngine databaseEngine, string databaseVersion)
        {
            Host = host;
            Database = database;
            Username = username;
            Password = password;
            DatabaseEngine = databaseEngine;
            DatabaseVersion = databaseVersion;
        }

        public override bool Equals(object obj)
        {
            return obj is DatabaseConnection other &&
                   Host == other.Host &&
                   Database == other.Database &&
                   Username == other.Username &&
                   Password == other.Password &&
                   DatabaseEngine == other.DatabaseEngine &&
                   DatabaseVersion == other.DatabaseVersion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Host, Database,DatabaseVersion,DatabaseEngine,Username,Password);
        }
    }

    public class DatabaseUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}