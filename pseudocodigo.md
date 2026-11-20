# Pseudocódigo — Programa 1: media y desviación estándar

## 1. Decisiones de diseño

| Tema | Decisión | Requisito |
| :--- | :--- | :--- |
| **Ruta del archivo** | Si llega una ruta como argumento, se usa; si no, se pide por consola. | RNF-04 |
| **Línea vacía** | Se ignora y se continúa con la siguiente. | RNF-04 |
| **Formato de los números** | El punto es el único separador decimal, sin depender de la configuración regional del equipo; cualquier otro formato (por ejemplo, con coma) se trata como dato inválido. | RNF-03 |
| **Dato inválido** | Se informa el número de línea y el texto, y el programa termina sin calcular. | RNF-06 |
| **Archivo vacío (\(n = 0\))** | Se informa que no hay datos y se termina sin calcular. | RNF-06 |
| **Un solo dato (\(n = 1\))** | Se informa que la desviación no se puede calcular y se termina sin calcular. | RNF-06 |
| **Almacenamiento** | Lista enlazada propia que conserva el orden de lectura y guarda su cantidad de nodos. | RF-02, RNF-02 |
| **Cálculo** | Dos recorridos de la lista: el primero obtiene la media y el segundo la desviación muestral (\(n - 1\)). | RF-03, RF-04 |
| **Salida** | Tres líneas rotuladas (\(n\), media, desviación) con 2 decimales. | RF-05, RNF-05 |

## 2. Operaciones que necesita la lista (conceptual)

* Crear una lista vacía (`cantidad = 0`, sin nodos).
* Agregar un número al final (crea un nodo, lo enlaza y aumenta la cantidad), de modo que el orden de lectura se conserva.
* Consultar la cantidad de elementos.
* Recorrer los nodos desde el primero hasta el último, entregando el valor de cada uno.

## 3. Pseudocódigo

```text
INICIO
    -- Obtener la ruta del archivo --
    Si el programa recibió una ruta como argumento:
        ruta ← la ruta recibida
    Si no:
        Pedir al usuario que escriba la ruta del archivo
        ruta ← el texto que escribió el usuario

    Si la ruta está vacía:
        Mostrar "No se indicó ninguna ruta"
        TERMINAR con error

    -- Abrir el archivo --
    Si el archivo no existe:
        Mostrar "El archivo no existe: " y la ruta
        TERMINAR con error

    Intentar abrir el archivo para lectura
    Si no se pudo abrir (sin permisos, en uso, etc.):
        Mostrar "No se pudo abrir el archivo" y el motivo
        TERMINAR con error

    -- Preparar el almacenamiento --
    Crear una lista enlazada vacía
    numeroDeLinea ← 0

    -- Leer el archivo línea por línea --
    Mientras queden líneas por leer:
        Leer la siguiente línea
        numeroDeLinea ← numeroDeLinea + 1
        Quitar los espacios del inicio y del final de la línea

        Si la línea quedó vacía:
            Ignorarla y pasar a la siguiente

        Intentar interpretar el texto como un número real, exigiendo estrictamente
        el punto (.) como separador decimal y rechazando la coma (,) u otros
        formatos regionales.

        Si el texto NO representa un número válido:
            Mostrar "Dato inválido en la línea " y numeroDeLinea y el texto encontrado
            Cerrar el archivo
            TERMINAR con error

        valor ← el número obtenido
        Agregar valor al final de la lista

    Cerrar el archivo

    -- Validar que hay datos suficientes --
    n ← cantidad de elementos de la lista

    Si n = 0:
        Mostrar "El archivo no contiene datos numéricos"
        TERMINAR con error

    Si n = 1:
        Mostrar "Con un solo dato no se puede calcular la desviación estándar (se necesitan al menos 2)"
        TERMINAR con error

    -- Primer recorrido: media --
    suma ← 0
    Recorrer la lista desde el primer nodo hasta el último:
        suma ← suma + valor del nodo actual
    media ← suma / n

    -- Segundo recorrido: desviación estándar --
    sumaCuadrados ← 0
    Recorrer la lista desde el primer nodo hasta el último:
        diferencia ← valor del nodo actual − media
        sumaCuadrados ← sumaCuadrados + (diferencia × diferencia)
    varianza ← sumaCuadrados / (n − 1)
    desviacion ← raíz cuadrada de varianza

    -- Mostrar el resultado (2 decimales, un dato por línea) --
    Mostrar "n = " y n
    Mostrar "Media = " y media con 2 decimales
    Mostrar "Desviación estándar = " y desviacion con 2 decimales

    TERMINAR con éxito
FIN
```

## 4. Casos de error contemplados

| Situación | Mensaje | Resultado |
| :--- | :--- | :--- |
| **Ruta vacía** | No se indicó ninguna ruta | Termina con error |
| **El archivo no existe** | El archivo no existe: `ruta` | Termina con error |
| **No se puede abrir el archivo** | No se pudo abrir el archivo: `motivo` | Termina con error |
| **Línea vacía** | *(ninguno)* | Se ignora y continúa |
| **Dato inválido (incluye coma decimal)** | Dato inválido en la línea $k$: `texto` | Cierra el archivo y termina con error |
| **Archivo vacío o solo con líneas en blanco ($n = 0$)** | El archivo no contiene datos numéricos | Termina con error |
| **Un solo dato ($n = 1$)** | Con un solo dato no se puede calcular la desviación estándar | Termina con error |

> **Nota:** Los cuatro casos de RNF-06 (archivo inexistente, archivo vacío, valor no numérico con su número de línea y un solo dato) están cubiertos. La ruta vacía y la imposibilidad de abrir el archivo son casos adicionales que el requisito no menciona, pero aseguran la robustez operativa.

## 5. Trazabilidad con los requisitos

| Requisito | Dónde se atiende |
| :--- | :--- |
| **RF-01 Leer los datos** | Lectura línea por línea |
| **RF-02 Almacenar los números** | Lista enlazada con cantidad; orden de lectura conservado |
| **RF-03 Media** | Primer recorrido |
| **RF-04 Desviación estándar** | Segundo recorrido, dividiendo entre $(n - 1)$ |
| **RF-05 Mostrar resultados** | Tres líneas rotuladas |
| **RNF-03 Números reales** | Interpretación con punto decimal estricto, independiente de la región |
| **RNF-04 Fuente de entrada** | Ruta por argumento o por consola; líneas en blanco ignoradas |
| **RNF-05 Formato** | 2 decimales en media y desviación |
| **RNF-06 Datos inválidos** | Sección de validaciones y tabla de errores |

> **Nota:** RNF-01 y RNF-02 (C# de consola y lista enlazada propia) se resuelven en el diseño de clases, no en el pseudocódigo.

## 6. Valores esperados para verificar el diseño

| Conjunto | $n$ | Media | Desviación |
| :--- | :---: | :---: | :---: |
| **Columna 1** | 10 | 550.60 | 572.03 |
| **Columna 2** | 10 | 60.32 | 62.26 |
| **186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601** | 10 | 638.90 | 625.63 |

