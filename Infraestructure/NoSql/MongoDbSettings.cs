namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017/";
        public string Database { get; set; } = "itl_app";
    }
}
