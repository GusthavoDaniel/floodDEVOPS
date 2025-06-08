namespace FloodWatch.API.Models
{
    public enum TipoSensor
    {
        NivelAgua = 1,
        Precipitacao = 2,
        Temperatura = 3,
        Umidade = 4,
        VelocidadeVento = 5
    }

    public enum StatusSensor
    {
        Ativo = 1,
        Inativo = 2,
        Manutencao = 3,
        Defeito = 4
    }

    public enum NivelRisco
    {
        Baixo = 1,
        Medio = 2,
        Alto = 3,
        Critico = 4
    }

    public enum TipoAlerta
    {
        Preventivo = 1,
        Urgente = 2,
        Critico = 3,
        Emergencia = 4
    }

    public enum StatusAlerta
    {
        Ativo = 1,
        Expirado = 2,
        Cancelado = 3
    }

    public enum TipoUsuario
    {
        Administrador = 1,
        Operador = 2,
        Cidadao = 3
    }

    public enum StatusQualidade
    {
        Boa = 1,
        Regular = 2,
        Ruim = 3,
        Invalida = 4
    }

    public enum TipoEvento
    {
        Enchente = 1,
        Alagamento = 2,
        Tempestade = 3,
        Inundacao = 4,
        Deslizamento = 5
    }

    public enum NivelSeveridade
    {
        Baixo = 1,
        Medio = 2,
        Alto = 3,
        Critico = 4,
        Catastrofico = 5
    }
}

