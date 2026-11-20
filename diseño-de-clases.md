# Diseño de clases — Programa 1: Media y desviación estándar

## Comentario de la actividad

En esta actividad se define la estructura de clases del Programa 1: la responsabilidad de cada clase, sus atributos y métodos principales y la relación entre ellas. El diseño se basa en los requisitos y en el pseudocódigo ya definidos, en especial en el uso obligatorio de una lista enlazada propia para almacenar los números (RNF-02).

---

## 1. Diseño de clases

| Clase | Responsabilidad | Atributos principales | Métodos principales |
| :--- | :--- | :--- | :--- |
| **`Nodo`** | Representar un elemento de la lista enlazada y mantener la referencia al siguiente. | `Valor : double`<br>`Siguiente : Nodo` (nulo si es el último) | Constructor `Nodo(valor)`, que deja `Siguiente` en nulo. |
| **`ListaEnlazada`** | Almacenar los números en el orden en que fueron leídos y permitir recorrerlos. | `Cabeza : Nodo` (primer nodo)<br>`Cola : Nodo` (último nodo)<br>`Cantidad : int` | `Agregar(valor)`: crea un nodo y lo enlaza al final.<br>Consulta de `Cabeza` y `Cantidad` (solo lectura) para recorrer la lista. |
| **`CalculadoraEstadistica`** | Calcular la media y la desviación estándar muestral de los números de la lista. No lee archivos ni muestra nada. | Ninguno: trabaja con lo que recibe. | `CalcularMedia(lista) : double`<br>`CalcularDesviacionEstandar(lista, media) : double`, con \(\sqrt{\frac{\sum(x - \text{media})^2}{n - 1}}\). |
| **`LectorArchivoNumeros`** | Abrir el archivo, leer sus líneas, ignorar las vacías, validar que cada valor sea un número real con punto decimal y almacenarlos en la lista enlazada. | `RutaArchivo : string` | `Leer(ruta) : ListaEnlazada`. Detecta archivo inexistente, archivo vacío y valores no numéricos, indicando la línea cuando corresponda, y comunica el error al `Program` para que sea mostrado mediante `ConsolaUI`. No realiza salida directa por consola. |
| **`ResultadoEstadistico`** | Contener los resultados calculados para que la consola los pueda utilizar. | `Cantidad : int`<br>`Media : double`<br>`DesviacionEstandar : double` | Constructor `ResultadoEstadistico(cantidad, media, desviacion)`. Solo consulta. |
| **`ConsolaUI`** | Gestionar la entrada y la salida por consola, sin encargarse de los cálculos. | Ninguno. | `PedirRutaArchivo() : string`<br>`MostrarError(mensaje)`<br>`MostrarResultado(resultado)`: muestra `n`, `media` y `desviación` con rótulos, punto decimal y 2 decimales. |
| **`Program`** | Coordinar el flujo del programa sin hacer el trabajo de las demás clases. | Ninguno propio; usa variables locales: `ruta`, `lista`, `media`, `desviación` y `resultado`. | `Main(args)`: obtiene la ruta (argumento o `ConsolaUI`), llama al lector, comprueba que haya al menos 2 datos, llama a la calculadora, crea el `ResultadoEstadistico` y lo muestra. Si hay un error, lo muestra con `ConsolaUI` y termina. |

---

## 2. Relaciones entre las clases

- `Program` usa a `LectorArchivoNumeros`, `CalculadoraEstadistica` y `ConsolaUI`.
- `LectorArchivoNumeros` crea la `ListaEnlazada` y la llena con los valores del archivo.
- `ListaEnlazada` contiene `Nodo`s: cada nodo apunta al siguiente.
- `CalculadoraEstadistica` recorre la `ListaEnlazada` que recibe, sin modificarla.
- `ConsolaUI` recibe un `ResultadoEstadistico` para mostrarlo.

```
Program
 ├── LectorArchivoNumeros ──► ListaEnlazada ──► Nodo
 ├── CalculadoraEstadistica ──► (recorre) ListaEnlazada
 ├── ResultadoEstadistico
 └── ConsolaUI ──► (muestra) ResultadoEstadistico
```

---

## 3. Decisiones de diseño

* **Cola en la lista:** se guarda el último nodo para agregar al final sin recorrer toda la lista.
* **El lector informa, la consola muestra:** `LectorArchivoNumeros` solo detecta y comunica los problemas; quien los muestra es `ConsolaUI`.
* **Comprobación de 2 datos:** la hace `Program` antes de calcular, porque la desviación con n - 1 no se puede calcular con un solo dato.
* **Quién crea el resultado:** `Program` toma n, la media y la desviación y crea el `ResultadoEstadistico`; la calculadora no lo conoce.
* **Desviación con la media recibida:** `CalcularDesviacionEstandar` recibe la media ya calculada para no recalcularla.
* **Configuración regional:** la lectura de números utilizará punto (`.`) como separador decimal independientemente de la configuración regional del sistema (RNF-03). La salida mostrará los resultados con punto y exactamente dos decimales (RNF-05), por ejemplo `550.60` y no `550,60`.

---

## 4. Arquitectura y flujo del programa

### 4.1 Flujo general

El programa seguirá el siguiente flujo:

1. `Program` obtiene la ruta del archivo desde los argumentos. Si no se proporciona, solicita la ruta mediante `ConsolaUI`.
2. `LectorArchivoNumeros` verifica y abre el archivo.
3. El lector procesa el archivo línea por línea.
4. Las líneas vacías se ignoran.
5. Cada valor válido se agrega a `ListaEnlazada`.
6. Si se encuentra un valor inválido, el lector comunica el error al `Program`, que lo muestra mediante `ConsolaUI`, y el programa termina sin realizar los cálculos.
7. Al terminar la lectura, `Program` verifica que existan al menos dos datos. Si no es así, se muestra un error y el programa termina.
8. `CalculadoraEstadistica` calcula la media.
9. `CalculadoraEstadistica` calcula la desviación estándar muestral.
10. `Program` crea un `ResultadoEstadistico`.
11. `ConsolaUI` muestra la cantidad de datos, la media y la desviación estándar con dos decimales.

### 4.2 Flujo entre clases

```
Entrada del usuario / argumentos
               │
               ▼
            Program
               │
               ▼
     LectorArchivoNumeros
               │
               ▼
         ListaEnlazada
               │
               ▼
    CalculadoraEstadistica
         │           │
         ▼           ▼
       Media     Desviación
         │           │
         └─────┬─────┘
               ▼
     ResultadoEstadistico
               │
               ▼
           ConsolaUI
               │
               ▼
           Resultado
```

`ConsolaUI` también interviene al inicio, para solicitar la ruta cuando no se recibe como argumento, y cuando hay un error, para mostrar el mensaje.

### 4.3 Entrada de datos

La fuente de datos será un archivo de texto con un número real por línea. Se utilizará el punto (`.`) como separador decimal. Las líneas vacías o que contengan únicamente espacios se ignorarán y no se almacenarán como datos.

La ruta del archivo podrá recibirse como argumento de la aplicación. Si no se proporciona, el programa solicitará la ruta mediante la consola.

Ejemplo:

```
160
591
114
229
230
270
128
1657
624
1503
```

También se debe permitir la lectura de valores con decimales como:

```
15.0
69.9
6.5
22.4
```

La entrada se almacenará exclusivamente en la lista enlazada definida para el programa.

### 4.4 Salida por consola

Cuando el procesamiento termina correctamente, la consola mostrará:

```
n = 10
media = 550.60
desviación = 572.03
```

Los valores de media y desviación estándar se mostrarán con exactamente dos decimales. En caso de error, se mostrará un mensaje en español que explique la causa. No se mostrarán resultados estadísticos si la entrada no es válida.
