# Registro de Ejecución y Pruebas — Programa 1 (PSP0)

## 1. Resumen de Ejecución y Logros
El programa compiló sin errores y se ejecutó de manera satisfactoria en todos los escenarios probados (datos válidos, casos borde y casos negativos):

- **Cálculo estadístico:** Con datos válidos (`C:\psp1\column1.txt`, 10 elementos), el sistema leyó los valores desde la lista enlazada propia (`ListaEnlazada` / `Nodo`) y calculó correctamente la cantidad de datos (`10`), la media (`638.90`) y la desviación estándar muestral (`625.63`) con formato de dos decimales y punto decimal invariante, finalizando con código de salida `0`.
- **Control de excepciones y validaciones:** Todas las situaciones de error (ruta inexistente, archivo vacío, texto no numérico, coma decimal y cantidad insuficiente de datos) fueron interceptadas de forma controlada y mostradas en consola mediante `ConsolaUI`, deteniendo el cálculo y finalizando con código de salida `1` sin caídas del programa.
- **Separación de responsabilidades:** Se mantuvo la arquitectura modular prevista (`Program`, `ConsolaUI`, `LectorArchivoNumeros`, `CalculadoraEstadistica`, `ResultadoEstadistico`, `ListaEnlazada` y `Nodo`).

---

## 2. Registro de Casos de Prueba

| ID | Caso | Entrada | Resultado Esperado | Resultado Obtenido | Estado |
| :--- | :--- | :--- | :--- | :--- | :---: |
| **PR-00** | Datos válidos (10 datos) | `C:\psp1\ejemplo_trabajado.txt` (10 números reales con punto decimal) | `Cantidad de datos: 10`, `Media: 638.90`, `Desviación estándar: 625.63` | `Cantidad de datos: 10`, `Media: 638.90`, `Desviación estándar: 625.63` (código `0`) | bien |
| **PR-01** | Archivo inexistente | `C:\psp1\ejemplo_trabajado.txt` | Mensaje indicando que el archivo no existe | `El archivo no existe: C:\psp1\no_existe.txt` (código `1`) | bien |
| **PR-02** | Archivo vacío | `C:\psp1\ejemplo_trabajado.txt` (archivo sin datos) | Mensaje indicando que no contiene datos numéricos | `El archivo no contiene datos numéricos.` (código `1`) |bien |
| **PR-03** | Dato inválido / varias líneas con error | `C:\psp1\ejemplo_trabajado.txt` (`10`, `abc`, `20`) | Detener lectura/cálculo e indicar dato inválido y número de línea | `Dato inválido en la línea 2: abc` (código `1`) | bien |
| **PR-04** | Coma decimal | `C:\psp1\ejemplo_trabajado.txt` (`10.0`, `15,5`) | Rechazar dato con coma decimal indicando la línea | `Dato inválido en la línea 2: 15,5` (código `1`) | bien |
| **PR-05** | Un solo dato | `C:\psp1\ejemplo_trabajado.txt` (`15`) | No calcular e indicar que se necesitan mínimo 2 datos | `Se necesitan al menos dos datos para calcular la media y la desviación estándar muestral.` (código `1`) | bien |
| **PR-06** | Líneas vacías y decimal con punto | `C:\psp1\ejemplo_trabajado.txt` (`15.5`, línea vacía, `24.5`) | Ignorar líneas vacías, aceptar decimales con punto y calcular | `Cantidad de datos: 2`, `Media: 20.00`, `Desviación estándar: 6.36` (código `0`) | bien |

---

## 3. Defectos Detectados Durante las Pruebas
- **Defectos encontrados en fase de pruebas:** `0`
- **Observaciones:** No se presentaron fallos funcionales ni excepciones no controladas durante la ejecución de los casos positivos y negativos; los defectos previos (`D-01` a `D-06`) fueron resueltos durante las fases de diseño, codificación y revisión de código antes de la ejecución final.