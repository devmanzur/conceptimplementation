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
        private readonly DatabaseUser _user = new DatabaseUser();

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
            credentialSetup(_user);
            return this;
        }

        public DatabaseConnection Connect()
        {
            return new DatabaseConnection(_host, _databaseName, _user.Username, _user.Password);
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
        public DatabaseConnection Connect();
    }


    public class DatabaseConnection
    {
        public string Host { get; private set; }
        public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public DatabaseConnection(string host, string database, string username, string password)
        {
            Host = host;
            Database = database;
            Username = username;
            Password = password;
        }
    }

    public class DatabaseUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}