namespace MicroOndas.Dominio;

public class Forno
{
    public int TempoEmSegundos { get; private set; }
    public int Potencia { get; private set; }
    public bool EmAquecimento { get; private set; }
    public string StringInformativa { get; private set; } = "";

    public Forno()
    {
        TempoEmSegundos = 0;
        Potencia = 10;
        EmAquecimento = false;
    }

    public void ConfigurarParametros(int tempo, int potencia = 10)
    {
        if (tempo < 1 || tempo > 120)
            throw new ArgumentException("O tempo deve ser entre 1 segundo e 2 minutos.");

        if (potencia < 1 || potencia > 10)
            throw new ArgumentException("A potência deve estar entre 1 e 10.");

        TempoEmSegundos = tempo;
        Potencia = potencia;
    }

    // Regra: Início rápido assume 30s e potência 10
    public void InicioRapido()
    {
        TempoEmSegundos = 30;
        Potencia = 10;
        EmAquecimento = true;
    }

    // Regra: Iniciar com o que foi configurado, ou acrescentar 30s se já estiver rodando
    public void IniciarOuAcrescentarTempo()
    {
        if (EmAquecimento)
        {
            TempoEmSegundos += 30;
        }
        else
        {
            EmAquecimento = true;
        }
    }

    // Regra: Pausar e Cancelar (Botão único)
    public void PausarOuCancelar()
    {
        if (EmAquecimento)
        {
            EmAquecimento = false; // Apenas pausa
        }
        else
        {
            // Se já estava pausado (ou antes de iniciar), limpa tudo
            TempoEmSegundos = 0;
            Potencia = 10;
            StringInformativa = "";
        }
    }

    // Regra: Gerar a string de aquecimento com base na potência
    public string ObterPontinhosPorSegundo()
    {
        return new string('.', Potencia);
    }
}