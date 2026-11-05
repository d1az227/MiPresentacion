using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private const string MensajeInicial = "Completa el formulario y presiona «Presentarme».";

    private bool _saludoAlterno = false;      // false = saludo 1, true = saludo 2
    private bool _hayPresentacion = false;    // indica si ya se mostró una presentación válida

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
    {
        string nombre   = TxtNombre.Text?.Trim()   ?? "";
        string apellido = TxtApellido.Text?.Trim() ?? "";
        string edadTxt  = TxtEdad.Text?.Trim()     ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarAdvertencia("⚠ El nombre no puede estar vacío.");
            return;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            MostrarAdvertencia("⚠ El apellido no puede estar vacío.");
            return;
        }

        if (!int.TryParse(edadTxt, out int edad))
        {
            MostrarAdvertencia("⚠ Ingresa una edad numérica (solo números enteros).");
            return;
        }

        if (edad <= 0)
        {
            MostrarAdvertencia("⚠ La edad debe ser un número entero mayor que cero.");
            return;
        }

        _hayPresentacion = true;
        MostrarPresentacion();
    }

    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text   = string.Empty;
        TxtApellido.Text = string.Empty;
        TxtEdad.Text     = string.Empty;

        _hayPresentacion = false;
        TxtResultado.ClearValue(TextBlock.ForegroundProperty);
        TxtResultado.Text = MensajeInicial;

        TxtNombre.Focus();
    }

    private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        _saludoAlterno = !_saludoAlterno;

        // Si ya hay una presentación visible, se actualiza al instante
        if (_hayPresentacion)
            MostrarPresentacion();
    }

    private void MostrarPresentacion()
    {
        string nombre   = TxtNombre.Text!.Trim();
        string apellido = TxtApellido.Text!.Trim();
        int edad        = int.Parse(TxtEdad.Text!.Trim());

        TxtResultado.ClearValue(TextBlock.ForegroundProperty);
        TxtResultado.Text = _saludoAlterno
            ? $"¡Buen día! Soy {nombre} {apellido}, tengo {edad} años\n" +
              "y me emociona crear mis primeras ventanas con Avalonia UI."
            : $"¡Hola! Mi nombre es {nombre} {apellido},\n" +
              $"tengo {edad} años y estoy aprendiendo\n" +
              "a desarrollar interfaces gráficas con C#.";
    }

    private void MostrarAdvertencia(string mensaje)
    {
        _hayPresentacion = false;
        TxtResultado.Foreground = Brushes.Firebrick;
        TxtResultado.Text = mensaje;
    }
}
