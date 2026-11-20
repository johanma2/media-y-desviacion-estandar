# Pseudocódigo — Programa 1: media y desviación estándar

## 1. Decisiones de diseño

| Tema | Decisión | Requisito |
| :--- | :--- | :--- |
| **Reparto por clases** | `Program` coordina; `ConsolaUI` hace toda la entrada y salida por consola; `LectorArchivoNumeros` lee y valida; `ListaEnlazada` y `Nodo` almacenan; `CalculadoraEstadistica` calcula; `ResultadoEstadistico` agrupa los resultados. | RNF-02 |
| **Ruta del archivo** | `Program` usa la ruta recibida como argumento; si no hay, la pide mediante `ConsolaUI`. | RNF-04 |
| **Línea vacía** | Se ignora y se continúa con la siguiente (incluye las que solo tienen espacios). | RNF-04 |
| **Formato de los números** | El punto es el único separador decimal, sin depender de la configuración regional del equipo; cualquier otro formato (por ejemplo, con coma) se trata como dato inválido. | RNF-03 |
| **Comunicación de errores** | `LectorArchivoNumeros` detecta el problema y lo comunica a `Program` con un mensaje en español; `Program` lo muestra mediante `ConsolaUI`. El lector no escribe en la consola. | RNF-06 |
| **Dato inválido** | Se informa el número de línea y el texto, y el programa termina sin calcular. | RNF-06 |
| **Archivo vacío (n = 0)** | Lo detecta el lector. Se informa que no hay datos y se termina sin calcular. | RNF-06 |
| **Un solo dato (n = 1)** | Lo detecta `Program` antes de calcular. Se informa que la desviación no se puede calcular y se termina sin calcular. | RNF-06 |
| **Almacenamiento** | Lista enlazada propia que conserva el orden de lectura y guarda su cantidad de nodos. | RF-02, RNF-02 |
| **Cálculo** | Dos recorridos de la lista: el primero obtiene la media y el segundo la desviación muestral (n − 1). | RF-03, RF-04 |
| **Salida** | Tres líneas rotuladas (n, media, desviación) con exactamente 2 decimales y punto decimal. | RF-05, RNF-05 |

## 2. Operaciones que necesita la lista (conceptual)

* Crear una lista vacía (`Cantidad = 0`, sin nodos).
* Agregar un número al final (crea un nodo, lo enlaza y aumenta la cantidad), de modo que el orden de lectura se conserva.
* Consultar la cantidad de elementos.
* Consultar el primer nodo (`Cabeza`) para poder recorrer los nodos hasta el último, entregando el valor de cada uno.

## 3. Pseudocódigo por clases

```
CLASE Nodo
    Valor : número real
    Siguiente : Nodo (vacío si es el último)

    Nodo(valor):
        Valor ← valor
        Siguiente ← vacío


CLASE ListaEnlazada
    Cabeza : Nodo (vacío si la lista está vacía)
    Cola : Nodo (vacío si la lista está vacía)
    Cantidad : entero

    ListaEnlazada():
        Cabeza ← vacío
        Cola ← vacío
        Cantidad ← 0

    Agregar(valor):
        nuevo ← crear Nodo(valor)
        Si Cabeza está vacía:
            Cabeza ← nuevo
            Cola ← nuevo
        Si no:
            Cola.Siguiente ← nuevo
            Cola ← nuevo
        Cantidad ← Cantidad + 1


CLASE LectorArchivoNumeros
    -- COMUNICAR ERROR(mensaje) termina Leer sin devolver la lista
    -- y entrega el mensaje a Program.

    Leer(ruta):
        -- Abrir el archivo --
        Si el archivo no existe:
            COMUNICAR ERROR "El archivo no existe: " y la ruta

        Intentar abrir el archivo para lectura
        Si no se pudo abrir (sin permisos, en uso, etc.):
            COMUNICAR ERROR "No se pudo abrir el archivo: " y el motivo

        -- Preparar el almacenamiento --
        lista ← crear ListaEnlazada vacía
        numeroDeLinea ← 0

        -- Leer el archivo línea por línea --
        Mientras queden líneas por leer:
            Leer la siguiente línea
            numeroDeLinea ← numeroDeLinea + 1
            Quitar los espacios del inicio y del final de la línea

            Si la línea quedó vacía:
                Ignorarla y pasar a la siguiente

            Intentar interpretar el texto como un número real, exigiendo
            estrictamente el punto (.) como separador decimal y rechazando
            la coma (,) u otros formatos regionales.

            Si el texto NO representa un número válido:
                Cerrar el archivo
                COMUNICAR ERROR "Dato inválido en la línea " y numeroDeLinea
                                y el texto encontrado

            valor ← el número obtenido
            lista.Agregar(valor)

        Cerrar el archivo

        Si lista.Cantidad = 0:
            COMUNICAR ERROR "El archivo no contiene datos numéricos"

        DEVOLVER lista


CLASE CalculadoraEstadistica
    CalcularMedia(lista):
        suma ← 0
        actual ← lista.Cabeza
        Mientras actual no esté vacío:
            suma ← suma + actual.Valor
            actual ← actual.Siguiente
        DEVOLVER suma / lista.Cantidad

    CalcularDesviacionEstandar(lista, media):
        sumaCuadrados ← 0
        actual ← lista.Cabeza
        Mientras actual no esté vacío:
            diferencia ← actual.Valor − media
            sumaCuadrados ← sumaCuadrados + (diferencia × diferencia)
            actual ← actual.Siguiente
        varianza ← sumaCuadrados / (lista.Cantidad − 1)
        DEVOLVER raíz cuadrada de varianza


CLASE ResultadoEstadistico
    Cantidad : entero
    Media : número real
    DesviacionEstandar : número real

    ResultadoEstadistico(cantidad, media, desviacion):
        Cantidad ← cantidad
        Media ← media
        DesviacionEstandar ← desviacion


CLASE ConsolaUI
    PedirRutaArchivo():
        Pedir al usuario que escriba la ruta del archivo
        DEVOLVER el texto que escribió el usuario

    MostrarError(mensaje):
        Mostrar mensaje

    MostrarResultado(resultado):
        -- Un dato por línea, con exactamente 2 decimales y punto decimal --
        Mostrar "n = " y resultado.Cantidad
        Mostrar "media = " y resultado.Media con 2 decimales
        Mostrar "desviación = " y resultado.DesviacionEstandar con 2 decimales


CLASE Program
    Main(argumentos):
        -- Obtener la ruta del archivo --
        Si el programa recibió una ruta como argumento:
            ruta ← la ruta recibida
        Si no:
            ruta ← ConsolaUI.PedirRutaArchivo()

        Si la ruta está vacía:
            ConsolaUI.MostrarError("No se indicó ninguna ruta")
            TERMINAR con error

        -- Leer y almacenar los datos --
        lista ← LectorArchivoNumeros.Leer(ruta)
        Si el lector comunicó un error:
            ConsolaUI.MostrarError(mensaje del error)
            TERMINAR con error

        -- Validar que hay datos suficientes --
        n ← lista.Cantidad
        Si n = 1:
            ConsolaUI.MostrarError("Con un solo dato no se puede calcular la
                                    desviación estándar (se necesitan al menos 2)")
            TERMINAR con error

        -- Calcular --
        media ← CalculadoraEstadistica.CalcularMedia(lista)
        desviacion ← CalculadoraEstadistica.CalcularDesviacionEstandar(lista, media)

        -- Mostrar el resultado --
        resultado ← crear ResultadoEstadistico(n, media, desviacion)
        ConsolaUI.MostrarResultado(resultado)

        TERMINAR con éxito
```

## 4. Casos de error contemplados

| Situación | Quién la detecta | Mensaje | Resultado |
| :--- | :--- | :--- | :--- |
| **Ruta vacía** | `Program` | No se indicó ninguna ruta | Termina con error |
| **El archivo no existe** | `LectorArchivoNumeros` | El archivo no existe: `ruta` | Termina con error |
| **No se puede abrir el archivo** | `LectorArchivoNumeros` | No se pudo abrir el archivo: `motivo` | Termina con error |
| **Línea vacía** | `LectorArchivoNumeros` | *(ninguno)* | Se ignora y continúa |
| **Dato inválido (incluye coma decimal)** | `LectorArchivoNumeros` | Dato inválido en la línea k: `texto` | Cierra el archivo y termina con error |
| **Archivo vacío o solo con líneas en blanco (n = 0)** | `LectorArchivoNumeros` | El archivo no contiene datos numéricos | Termina con error |
| **Un solo dato (n = 1)** | `Program` | Con un solo dato no se puede calcular la desviación estándar | Termina con error |

> **Nota:** Los cuatro casos de RNF-06 (archivo inexistente, archivo vacío, valor no numérico con su número de línea y un solo dato) están cubiertos. La ruta vacía y la imposibilidad de abrir el archivo son casos adicionales que el requisito no menciona, pero aseguran la robustez operativa.

## 5. Trazabilidad con los requisitos

| Requisito | Dónde se atiende |
| :--- | :--- |
| **RF-01 Leer los datos** | `LectorArchivoNumeros.Leer`: lectura línea por línea |
| **RF-02 Almacenar los números** | `ListaEnlazada` y `Nodo`: lista con cantidad; orden de lectura conservado |
| **RF-03 Media** | `CalculadoraEstadistica.CalcularMedia` (primer recorrido) |
| **RF-04 Desviación estándar** | `CalculadoraEstadistica.CalcularDesviacionEstandar` (segundo recorrido), dividiendo entre (n − 1) |
| **RF-05 Mostrar resultados** | `ConsolaUI.MostrarResultado`: tres líneas rotuladas |
| **RNF-03 Números reales** | `LectorArchivoNumeros.Leer`: interpretación con punto decimal estricto, independiente de la región |
| **RNF-04 Fuente de entrada** | `Program.Main` y `ConsolaUI.PedirRutaArchivo`: ruta por argumento o por consola; `LectorArchivoNumeros`: líneas en blanco ignoradas |
| **RNF-05 Formato** | `ConsolaUI.MostrarResultado`: 2 decimales en media y desviación |
| **RNF-06 Datos inválidos** | `LectorArchivoNumeros` y `Program`, con los mensajes mostrados por `ConsolaUI` (tabla de errores) |

> **Nota:** RNF-01 y RNF-02 (C# de consola y lista enlazada propia) se resuelven en el diseño de clases, no en el pseudocódigo.

## 6. Valores esperados para verificar el diseño

| Conjunto | n | Media | Desviación |
| :--- | :---: | :---: | :---: |
| **Columna 1** | 10 | 550.60 | 572.03 |
| **Columna 2** | 10 | 60.32 | 62.26 |
| **186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601** | 10 | 638.90 | 625.63 |