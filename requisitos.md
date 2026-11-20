Requisitos — Programa 1: Media y desviación estándar
Requisitos Funcionales
RF-01 — Leer los datos de entrada

Descripción: El programa debe leer un conjunto de n números reales desde un archivo de texto y cargarlos para su procesamiento.

Criterio de aceptación: Al proporcionar un archivo con los 10 valores de la columna 1 (160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503), el programa carga exactamente 10 valores, en el mismo orden. Lo mismo ocurre con los 10 valores de la columna 2 (15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2).

RF-02 — Almacenar los números

Descripción: El programa debe guardar todos los números leídos y conocer cuántos son (n), conservando el orden en que fueron leídos. n es necesario para calcular la media y la desviación.

Criterio de aceptación: Después de leer el archivo de la columna 1, la estructura contiene 10 elementos y al recorrerla se obtienen los valores en el orden del archivo (160 primero, 1503 último).

RF-03 — Calcular la media

Descripción: El programa debe calcular la media aritmética de los n números almacenados: la suma de todos los valores dividida entre n.

Criterio de aceptación: Con los datos de la columna 1 el resultado es 550.60, y con los de la columna 2 es 60.32 (diferencia máxima permitida: ±0.01).

RF-04 — Calcular la desviación estándar

Descripción: El programa debe calcular la desviación estándar de los n números almacenados: la raíz cuadrada de la suma de los cuadrados de (valor − media) dividida entre (n − 1). Es decir, la desviación estándar muestral.

Criterio de aceptación: Con los datos de la columna 1 el resultado es 572.03, y con los de la columna 2 es 62.26 (±0.01). Con el conjunto 186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601 la media es 638.9 y la desviación es 625.633981.

RF-05 — Mostrar los resultados

Descripción: El programa debe mostrar al usuario la cantidad de datos (n), la media y la desviación estándar, cada uno con su rótulo.

Criterio de aceptación: Al ejecutar el programa con el archivo de la columna 1, la salida muestra tres líneas rotuladas con n = 10, media = 550.60 y desviación = 572.03.

Requisitos No Funcionales
RNF-01 — Lenguaje y tipo de aplicación

Descripción: El programa se desarrolla como aplicación de consola en C# (.NET), sin interfaz gráfica.

Criterio de aceptación: El proyecto compila con 0 errores y 0 advertencias y se ejecuta desde la consola.

RNF-02 — Estructura de datos obligatoria

Descripción: Los números deben almacenarse en una lista enlazada de implementación propia (clase de nodo y clase de lista). No se usan List<T> ni arreglos para guardar los valores leídos.

Criterio de aceptación: En el código existe una clase de nodo y una clase de lista enlazada, y los valores leídos se almacenan en ella; no se usa List<T> ni un arreglo para guardarlos. Esta restricción aplica solo al almacenamiento de los datos, no al resto del programa.

RNF-03 — Manejo de números reales

Descripción: Los datos y los cálculos usan números reales (tipo double). La lectura no depende de la configuración regional del equipo: el punto es el separador decimal.

Criterio de aceptación: Con la cultura del sistema configurada en es-CO, el valor "15.0" se lee como 15.0 y no como 150, y la media de la columna 2 sigue siendo 60.32.

RNF-04 — Fuente de entrada

Descripción: Los datos se leen de un archivo de texto con un número por línea y punto decimal. Las líneas en blanco se ignoran. La ruta del archivo se recibe como argumento o se pide por consola.

Criterio de aceptación: Un archivo con líneas en blanco intercaladas entre los 10 valores produce los mismos resultados que el archivo sin ellas. La ruta indicada por argumento o por consola es la que se abre.

RNF-05 — Precisión y formato de los resultados

Descripción: Los resultados deben coincidir con los valores esperados con una tolerancia de ±0.01 y mostrarse con 2 decimales.

Criterio de aceptación: Las salidas para las columnas 1 y 2 son 550.60 / 572.03 y 60.32 / 62.26 respectivamente, escritas con exactamente 2 decimales.

RNF-06 — Comportamiento ante datos inválidos

Descripción: Ante datos que impiden el cálculo, el programa muestra un mensaje en español que explica la causa y termina sin calcular, en lugar de fallar o mostrar un resultado erróneo.

Criterio de aceptación: Cada uno de estos casos muestra un mensaje claro y no produce resultados: archivo inexistente; archivo vacío; una línea con un valor no numérico (el mensaje indica el número de línea); un solo dato (la desviación con n − 1 no se puede calcular).