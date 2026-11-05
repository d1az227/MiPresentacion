# MiPresentacion

Aplicación de escritorio hecha con **Avalonia UI 11** y **C#** (.NET 8). Un formulario pide
nombre, apellido y edad, valida los datos y muestra una presentación personalizada.

## Controles utilizados
- **TextBlock**: título y área de resultado (`TxtResultado`).
- **TextBox** (`TxtNombre`, `TxtApellido`, `TxtEdad`): entrada de datos.
- **Button** (`BtnPresentarme`, `BtnLimpiar`, `BtnCambiarSaludo`): acciones del usuario.
- **StackPanel** con `Margin` y `Spacing`: organización de la interfaz.

## Funcionamiento de los eventos
- **Presentarme**: lee los tres campos, valida que nombre y apellido no estén vacíos ni solo con
  espacios, verifica con `int.TryParse()` que la edad sea un entero mayor que cero y muestra la
  presentación o una advertencia.
- **Limpiar**: vacía los campos, restaura el mensaje inicial y devuelve el cursor al nombre con `Focus()`.
- **Cambiar saludo** (reto): alterna entre dos mensajes sin reiniciar la app; si ya hay una
  presentación visible, la actualiza al instante.

## Pruebas realizadas
| Caso | Datos | Resultado |
|---|---|---|
| 1 | Datos válidos | Muestra la presentación |
| 2 | Nombre vacío | Advertencia |
| 3 | Apellido vacío | Advertencia |
| 4 | Edad con letras | Pide una edad numérica |
| 5 | Edad ≤ 0 | Rechaza la edad |
| 6 | Limpiar | Restablece el formulario |

## Cómo ejecutar
Requisito: .NET 8 SDK.
```bash
git clone <URL-DEL-REPOSITORIO>
cd MiPresentacion
dotnet run
```

## Capturas
![Formulario](capturas/formulario.png)
![Presentación correcta](capturas/presentacion.png)
![Mensaje de validación](capturas/validacion.png)

## Pregunta de reflexión
**¿Cuál es la función de MainWindow.axaml y MainWindow.axaml.cs, y cómo se relacionan mediante
x:Name y los eventos Click?**

`MainWindow.axaml` es la parte visual: ahí describo qué hay en la ventana (títulos, cajas de
texto, botones) y cómo se acomoda. `MainWindow.axaml.cs` es la parte lógica: ahí escribo qué
debe pasar cuando el usuario hace algo. Por sí solo, el XAML solo dibuja y el C# no sabría
qué controles existen.

Se conectan de dos maneras. Con `x:Name`, le pongo un nombre a un control en el XAML (por
ejemplo `TxtNombre`) y desde C# puedo usarlo como una variable, para leer `TxtNombre.Text`
o cambiar `TxtResultado.Text`. Con `Click="BtnPresentarme_Click"`, le digo al botón qué método
ejecutar cuando lo presionen. Así, el usuario toca el botón, Avalonia llama al método, el
método lee los campos por su nombre, valida y escribe el resultado en pantalla.
