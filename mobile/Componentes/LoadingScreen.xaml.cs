using RGPopup.Maui.Pages;
using RGPopup.Maui.Services;

namespace FluxoDeCaixa.MAUI.Componentes;

/// <summary>
/// Gerencia uma tela de loading para exibi��o durante opera��es ass�ncronas em um aplicativo MAUI.
/// Permite gerenciar m�ltiplas chamadas simult�neas de loading com identificadores �nicos.
/// </summary>
public partial class LoadingScreen : PopupPage
{
    private static LoadingScreen instance;
    private static readonly Dictionary<string, bool> activeCalls = new();
    private static bool isOpen = false;
    private static bool blocksNewLoadings = false;

    /// <summary>
    /// Singleton que retorna a inst�ncia �nica da tela de loading.
    /// </summary>
    public static LoadingScreen Instance
    {
        get
        {
            if (instance == null)
                instance = new LoadingScreen();
            return instance;
        }
    }

    /// <summary>
    /// Construtor privado para evitar a cria��o direta de inst�ncias.
    /// Inicializa os componentes da tela de loading e impede o fechamento ao clicar no fundo.
    /// </summary>
    private LoadingScreen()
	{
		InitializeComponent();
        this.CloseWhenBackgroundIsClicked = false;
    }

    /// <summary>
    /// Inicia a exibi��o da tela de loading associada a um identificador �nico.
    /// </summary>
    /// <param name="callId">Identificador �nico para a chamada de loading.</param>
    /// <param name="transparentBackground">Define se o fundo da tela de loading ser� transparente.</param>
    /// <exception cref="ArgumentException">Lan�ado quando o <paramref name="callId"/> � nulo ou vazio.</exception>
    public async Task Start(string callId, string message = null, bool transparentBackground = false)
    {
        if (blocksNewLoadings)
            return;

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (string.IsNullOrEmpty(callId))
                throw new ArgumentException("callId cannot be null or empty.");

            if (!activeCalls.ContainsKey(callId))
                activeCalls.Add(callId, true);

            if (!isOpen)
            {
                if (transparentBackground)
                    BackgroundColor = Colors.Transparent;

                if (!string.IsNullOrEmpty(message))
                {
                    (FindByName("MessageLabel") as Label).SetValue(Label.TextProperty, message);
                    (FindByName("MessageLabel") as Label).SetValue(Label.IsVisibleProperty, true);
                }

                isOpen = true;

                await PopupNavigation.Instance.PushAsync(this).ConfigureAwait(false);
            }
        }).ConfigureAwait(false);
    }

    /// <summary>
    /// Encerra a exibi��o da tela de loading associada ao identificador �nico fornecido.
    /// </summary>
    /// <param name="callId">Identificador �nico da chamada de loading a ser encerrada.</param>
    /// <exception cref="ArgumentException">Lan�ado quando o <paramref name="callId"/> � nulo ou vazio.</exception>
    public async Task Stop(string callId)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (string.IsNullOrEmpty(callId))
                throw new ArgumentException("callId cannot be null or empty.");

            if (activeCalls.ContainsKey(callId))
                activeCalls.Remove(callId, out _);


            if (activeCalls.Count == 0 && isOpen)
            {
                isOpen = false;

                if (PopupNavigation.Instance.PopupStack.Contains(this))
                    await PopupNavigation.Instance.RemovePageAsync(this).ConfigureAwait(false);


                if (BackgroundColor == Colors.Transparent)
                    instance = null;
            }
        }).ConfigureAwait(false);
    }

    /// <summary>
    /// Gera um identificador �nico e aleat�rio para ser usado nas chamadas de <see cref="Start"/> e <see cref="Stop"/>.
    /// </summary>
    /// <returns>Um identificador �nico em formato de string.</returns>
    public static string GenerateCallId()
    {
        return Guid.NewGuid().ToString();
    }

    public static async Task BlocksNewLoadings()
    {
        await RemoveAllLoadings();
        blocksNewLoadings = true;
    }

    public static void ReleasesNewLoadings()
    {
        blocksNewLoadings = false;
    }

    /// <summary>
    /// Remove todos os Loadings em execu��o.
    /// </summary>
    public static async Task RemoveAllLoadings()
    {
        activeCalls.Clear();

        if (PopupNavigation.Instance.PopupStack.Contains(instance))
            await PopupNavigation.Instance.RemovePageAsync(instance).ConfigureAwait(false);
    }
}