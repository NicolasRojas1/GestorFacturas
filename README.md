# 🏠 Gestor de Facturas

Este es un proyecto de consola desarrollado en **C# y .NET 10.0** diseñado para automatizar el cálculo y la distribución de costos de servicios públicos (Agua, Luz y Gas) en apartamentos con medidores compartidos.

## 🚀 Características
* **Gestión Multiservicio:** Soporte para cálculos específicos de Agua, Luz y Gas.
* **Cálculo de Consumo Real:** Algoritmo que cruza lecturas de recibos oficiales vs. consumos internos de medidores por apartamento.
* **Arquitectura por Capas:** Separación clara entre Modelos (datos) y Servicios (lógica).
* **Código Limpio:** Configuración del proyecto para simplificar la sintaxis de consola y reducir líneas repetitivas (Usings implícitos).

## 🏗️ Estructura del Proyecto
El sistema aplica principios de Programación Orientada a Objetos (POO):

* **Models/**: Contiene la clase base `Factura` y las clases derivadas `Agua`, `Luz` y `Gas`.
* **Services/**: El `GestorFacturasService` actúa como orquestador de la lógica de negocio.
* **Program.cs**: Punto de entrada que orquesta la ejecución secuencial de los registros de servicios públicos.

## 💻 Cómo ejecutarlo
Al ejecutar la aplicación, el sistema solicitará de forma secuencial los datos para:
1.  Registro de Agua (Lecturas por apartamento).
2.  Registro de Luz.
3.  Registro de Gas.

## 🛠️ Stack Tecnológico
* **Lenguaje:** C#
* **Framework:** .NET 10.0
* **IDE:** Visual Studio Code / Visual Studio 2022

## 💻 Instalación y Uso
1.  Clona el repositorio:
    ```bash
    git clone [https://github.com/TU_USUARIO/GestorFacturas.git](https://github.com/TU_USUARIO/GestorFacturas.git)
    ```
2.  Navega a la carpeta del proyecto:
    ```bash
    cd GestorFacturas
    ```
3.  Restaura y ejecuta:
    ```bash
    dotnet run
    ```

## 📝 Notas del Desarrollador
Este proyecto fue creado para resolver una necesidad real de distribución de costos en Bogotá, aplicando conceptos  de C# como:
* Herencia y Polimorfismo.
* Manejo de colecciones dinámicas.
* Separación de responsabilidades (SRP).

---