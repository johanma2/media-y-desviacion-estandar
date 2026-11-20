# Traza de escritorio — Programa 1: Media y desviación estándar

## Pseudocódigo que se traza

```
PROGRAMA Principal(rutaArchivo)
    lista ← nueva ListaEnlazada
    SI NO existe(rutaArchivo) ENTONCES
        MOSTRAR "Error: el archivo no existe"
        TERMINAR
    numeroLinea ← 0
    PARA CADA linea EN archivo HACER
        numeroLinea ← numeroLinea + 1
        linea ← recortarEspacios(linea)
        SI linea está vacía ENTONCES CONTINUAR
        SI NO esNumeroReal(linea) ENTONCES
            MOSTRAR "Error: valor no numérico en la línea " + numeroLinea
            TERMINAR
        lista.Agregar(convertirADouble(linea))
    SI lista.n = 0 ENTONCES
        MOSTRAR "Error: el archivo está vacío"
        TERMINAR
    SI lista.n = 1 ENTONCES
        MOSTRAR "Error: se necesitan al menos 2 datos"
        TERMINAR
    media ← CalcularMedia(lista)
    desviacion ← CalcularDesviacion(lista, media)
    MOSTRAR "n = " + lista.n
    MOSTRAR "media = " + formato2Decimales(media)
    MOSTRAR "desviación = " + formato2Decimales(desviacion)

ListaEnlazada.Agregar(valor)
    nuevo ← nuevo Nodo(valor)
    SI cabeza = nulo ENTONCES
        cabeza ← nuevo
        cola ← nuevo
    SI NO
        cola.siguiente ← nuevo
        cola ← nuevo
    n ← n + 1

CalcularMedia(lista)
    suma ← 0
    actual ← lista.cabeza
    MIENTRAS actual ≠ nulo HACER
        suma ← suma + actual.valor
        actual ← actual.siguiente
    RETORNAR suma / lista.n

CalcularDesviacion(lista, media)
    suma ← 0
    actual ← lista.cabeza
    MIENTRAS actual ≠ nulo HACER
        diferencia ← actual.valor − media
        suma ← suma + diferencia × diferencia
        actual ← actual.siguiente
    RETORNAR raízCuadrada(suma / (lista.n − 1))
```

## Caso 1 — Archivo con 4, 6, 8, 10

Contenido del archivo, un número por línea: `4`, `6`, `8`, `10`.

### Lectura del archivo

El archivo existe. Inicia `numeroLinea = 0` y `lista` vacía (`n = 0`).

| Paso | numeroLinea | Contenido | ¿Vacía? | ¿Numérica? | Acción | Lista | n |
|---:|---:|---|---|---|---|---|---:|
| 1 | 1 | 4 | No | Sí | Agregar 4 | 4 | 1 |
| 2 | 2 | 6 | No | Sí | Agregar 6 | 4 → 6 | 2 |
| 3 | 3 | 8 | No | Sí | Agregar 8 | 4 → 6 → 8 | 3 |
| 4 | 4 | 10 | No | Sí | Agregar 10 | 4 → 6 → 8 → 10 | 4 |

Fin del archivo. Validaciones: `n = 4`, no es 0 ni 1, así que se continúa.

### CalcularMedia

| Iteración | actual.valor | suma antes | suma después |
|---:|---:|---:|---:|
| 1 | 4 | 0 | 4 |
| 2 | 6 | 4 | 10 |
| 3 | 8 | 10 | 18 |
| 4 | 10 | 18 | 28 |

Después de la iteración 4, `actual = nulo` y el ciclo termina.

media = 28 / 4 = **7**

### CalcularDesviacion (media = 7)

| Iteración | actual.valor | diferencia | diferencia² | suma antes | suma después |
|---:|---:|---:|---:|---:|---:|
| 1 | 4 | −3 | 9 | 0 | 9 |
| 2 | 6 | −1 | 1 | 9 | 10 |
| 3 | 8 | 1 | 1 | 10 | 11 |
| 4 | 10 | 3 | 9 | 11 | 20 |

desviación = raíz(20 / (4 − 1)) = raíz(6.6667) = **2.5820**

### Salida

```
n = 4
media = 7.00
desviación = 2.58
```

### Comprobación

| Dato | Esperado | Obtenido en la traza |
|---|---|---|
| n | 4 | 4 |
| Media | 7.00 | 7.00 |
| Desviación estándar muestral | 2.58 | 2.58 |

Con divisor *n* en vez de *n* − 1 el resultado sería raíz(20 / 4) = 2.24, que no coincide. La traza confirma que el pseudocódigo usa el divisor correcto.

## Caso 2 — Archivo con 10, 20, abc, 40

Contenido del archivo, un valor por línea: `10`, `20`, `abc`, `40`.

El archivo existe. Inicia `numeroLinea = 0` y `lista` vacía (`n = 0`).

| Paso | numeroLinea | Contenido | ¿Vacía? | ¿Numérica? | Acción | Lista | n |
|---:|---:|---|---|---|---|---|---:|
| 1 | 1 | 10 | No | Sí | Agregar 10 | 10 | 1 |
| 2 | 2 | 20 | No | Sí | Agregar 20 | 10 → 20 | 2 |
| 3 | 3 | abc | No | **No** | Mostrar el error y terminar | 10 → 20 | 2 |

El valor `40` (línea 4) nunca se lee: el programa termina en la línea 3.

### Salida

```
Error: valor no numérico en la línea 3
```

No se llama a `CalcularMedia` ni a `CalcularDesviacion`, y no se muestran n, media ni desviación.

### Comprobación

| Aspecto | Esperado | Obtenido en la traza |
|---|---|---|
| Mensaje claro con el número de línea | Sí | Sí (línea 3) |
| Se calculan resultados | No | No |
| Termina sin fallar | Sí | Sí |