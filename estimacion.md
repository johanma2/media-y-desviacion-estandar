# Estimación PSP0 — Programa 1: Media y desviación estándar

**Versión:** Ajuste de la estimación inicial de Planeación — PSP0.

## Método de estimación

La estimación se realiza mediante **descomposición del trabajo**: el programa se divide en fases y tareas pequeñas y a cada una se le asigna un tiempo estimado.

Como todavía no se dispone de datos históricos propios de proyectos PSP anteriores, los tiempos constituyen una primera estimación basada en el juicio sobre la complejidad del programa, los requisitos que debe cubrir, la cantidad de componentes que deben diseñarse e implementarse y los casos de validación que deben comprobarse. No se utilizan tiempos medidos de trabajos anteriores como base de la estimación.

El proyecto también requiere actividades propias del proceso PSP, como el registro de tiempos, documentación, análisis de defectos, pruebas y elaboración del postmortem. Por esta razón, la estimación contempla no solamente la programación, sino el proceso completo de desarrollo.

En el Postmortem se comparará esta estimación con los tiempos reales registrados en PSP Tracker para determinar el error de estimación y analizar las causas de las diferencias.

## Base de la estimación

La estimación considera que el programa es pequeño en funcionalidad, pero requiere varias actividades de diseño, implementación y verificación debido a las restricciones del ejercicio. Entre ellas se encuentran:

- uso obligatorio de una lista enlazada propia;
- lectura de números reales desde un archivo;
- validación línea por línea;
- control de líneas vacías y datos inválidos;
- cálculo de media;
- cálculo de desviación estándar muestral utilizando `n - 1`;
- manejo de errores de entrada;
- ejecución de los casos de prueba definidos;
- documentación de las actividades realizadas;
- registro de tiempos y defectos en PSP Tracker.

La estimación inicial de la fase de Planificación se amplía a 40 minutos para incluir la revisión del Assignment Kit, la definición de requisitos, la identificación de restricciones y la elaboración de la estimación.

El Diseño se estima en 85 minutos porque, además del pseudocódigo, requiere realizar trazas de escritorio, definir las responsabilidades de las clases, diseñar la arquitectura y flujo del programa, establecer la interfaz de consola y documentar las decisiones de diseño.

El Código se estima en 135 minutos debido a que la implementación debe realizarse desde cero y debe respetar la estructura de datos obligatoria. El trabajo se divide entre la lista enlazada, los cálculos estadísticos, la lectura y validación del archivo y el programa principal.

La Compilación se estima en 20 minutos considerando la compilación inicial, revisión de errores y advertencias y posibles correcciones.

Las Pruebas se estiman en 75 minutos porque deben comprobarse los resultados esperados de las dos columnas del Assignment Kit, el ejemplo proporcionado por el ejercicio y los diferentes casos de entrada inválida. También se contempla el tiempo necesario para corregir defectos encontrados durante las pruebas.

El Postmortem se estima en 35 minutos para revisar los registros de PSP Tracker, analizar los defectos registrados, comparar los tiempos planeados con los tiempos reales y elaborar las conclusiones y el PIP.

Se reserva una contingencia de 60 minutos para retrasos, correcciones adicionales, problemas de compilación, defectos no previstos o tareas de documentación que requieran más tiempo del estimado. La contingencia no se asigna previamente a una fase concreta.

## Tareas y tiempos estimados

| Fase | Tarea | Requisitos que cubre | Minutos |
|---|---|---|---:|
| Planificación | Leer el kit, resolver dudas, escribir requisitos y estimar | RF-01 a RF-05, RNF-01 a RNF-06 | 40 |
| Diseño | Pseudocódigo y decisiones de diseño | RF-01 a RF-05, RNF-03 a RNF-06 | 20 |
| Diseño | Traza de escritorio y validación manual del algoritmo | RF-01 a RF-05, RNF-06 | 15 |
| Diseño | Diseño de clases y responsabilidades | RF-01 a RF-05, RNF-02 | 20 |
| Diseño | Arquitectura, flujo, interfaz y datos de entrada | RF-01 a RF-05, RNF-01 a RNF-06 | 15 |
| Diseño | Revisión y documentación del diseño | RF-01 a RF-05, RNF-01 a RNF-06 | 15 |
| Código | Implementar nodo y lista enlazada | RF-02, RNF-02 | 35 |
| Código | Implementar cálculo de media y desviación estándar | RF-03, RF-04, RNF-03, RNF-05 | 30 |
| Código | Implementar lectura del archivo y validaciones | RF-01, RNF-03, RNF-04, RNF-06 | 40 |
| Código | Implementar programa principal y salida por consola | RF-05, RNF-05 | 30 |
| Compilación | Compilar, revisar errores/advertencias y corregir | RNF-01 | 20 |
| Pruebas | Diseñar y ejecutar casos de prueba | RF-01 a RF-05, RNF-02 a RNF-06 | 50 |
| Pruebas | Corregir defectos encontrados y repetir pruebas | RF-01 a RF-05, RNF-02 a RNF-06 | 25 |
| Postmortem | Revisar registros, comparar estimación con resultados y elaborar PIP | PSP0 | 35 |
|  | **Subtotal de tareas** |  | **390** |
|  | **Contingencia** | Retrasos, correcciones y trabajo adicional no previsto | **60** |
|  | **Tiempo total planeado** | 390 + 60 | **450** |

## Resumen por fase

| Fase | Minutos planeados |
|---|---:|
| Planificación | 40 |
| Diseño | 85 |
| Código | 135 |
| Compilación | 20 |
| Pruebas | 75 |
| Postmortem | 35 |
| Contingencia | 60 |
| **Total** | **450** |

**Tiempo total planeado: 450 minutos = 7 horas 30 minutos.**

## Valor para PSP Tracker

El tiempo planeado del proyecto es de **450 minutos (7 horas y 30 minutos)**, incluyendo la contingencia.

Este valor representa la estimación inicial del proyecto y debe registrarse en PSP Tracker antes de continuar con las fases posteriores. El tiempo real de cada fase se registrará mediante el Time Log.

La estimación no se modificará posteriormente para hacerla coincidir con el tiempo real. Las diferencias entre el tiempo planeado y el tiempo real serán analizadas en el Postmortem.

## Reglas de seguimiento

- El tiempo de cada fase se registra en PSP Tracker mediante el Time Log.
- Las interrupciones se registran cuando ocurran y no se ocultan dentro del tiempo de trabajo.
- Los defectos encontrados durante el desarrollo se registran en el Defect Log.
- Cada defecto debe registrar, como mínimo, su descripción, fase en la que fue introducido, fase en la que fue encontrado, solución/reparación y tiempo empleado.
- La contingencia no se asigna previamente a una fase concreta; se utiliza únicamente si aparece trabajo adicional, retrasos o correcciones no previstas.
- Los tiempos reales no se modifican para ajustarlos a la estimación.
- En el Postmortem se comparará el tiempo planeado con el tiempo real registrado y se analizarán las diferencias.