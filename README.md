# 📦 Sistema de Almacén - InventHIBA

Sistema de gestión de almacén desarrollado en **VB.NET**, usando **Excel como base de datos centralizada**. Pensado para el control preciso de entradas y salidas de materiales, con funcionalidades avanzadas, validaciones automáticas y generación de reportes PDF.

> Proyecto desarrollado durante mi estancia de prácticas profesionales, implementado en una empresa real con éxito.

---

## ✨ Módulos principales

### 🔐 1. Login
- Espacio para ingresar **usuario, contraseña** e **IP del servidor** (útil si cambia la IP por router o configuración).
- Incluye un apartado de **soporte técnico** con datos de contacto del desarrollador.
- Control de acceso según **nivel de usuario** (ej. permisos para editar/eliminar).

---

### 📦 2. Inventario
- Registro de **nuevos materiales**: piezas, consumibles, herramienta, etc.
- Ingreso de:
  - Código
  - Nombre
  - Cantidad en stock
  - Tipo de inventario (seleccionable)
- Funciones adicionales:
  - **Filtro dinámico** por tipo de inventario
  - **Búsqueda avanzada**
  - **Edición y eliminación** (según permisos)
  - Generación de reportes filtrados

---

### ➕ 3. Entradas
- Registro de entradas con campos como:
  - Código (autocompleta el nombre automáticamente)
  - Cantidad
  - Proveedor
  - Unidad (kg, mm, m, cm, etc.)
  - Orden de producción
  - Fecha
  - Factura
  - Orden de compra
  - Lote
  - Comentarios
- Genera un **Folio único** por entrada
- El stock se **actualiza automáticamente**
- Botón para mandar datos a **Reporte Específico**

---

### ➖ 4. Salidas
- Similar al módulo de Entradas pero enfocado a retiros de inventario
- Cambios principales:
  - Reemplazo de “Proveedor” por “Personal”
  - Se eliminan campos como: Orden de compra, Precio unitario, Factura
- Suma o resta del stock en tiempo real
- También puede mandar registros a Reporte Específico

---

### 📄 5. Reporte General
- Muestra **todas las operaciones** (entradas y salidas)
- Filtros por:
  - Rango de fechas
  - Tipo de movimiento
  - Folio
- Botón para generar **reportes en PDF**
- Opción para mandar un filtro personalizado al módulo de Reporte Específico

---

### 🧾 6. Reporte Específico
- Se mantiene vacío hasta que se le envía información desde los otros módulos
- Útil para generar reportes personalizados de:
  - Solo entradas
  - Solo salidas
  - Combinaciones por fechas específicas (ej. enero, abril, septiembre)
  - Registros filtrados por tipo de movimiento o usuario

---

## 💡 Funcionalidades extra

- Soporte para **conexión en red local** (multiusuario)
- Permite cambiar IP de servidor manualmente si hay cambios en la red
- Previene errores de captura con autocompletado y validaciones
- Generación de **reportes PDF** usando **iTextSharp**
- Desarrollo complementario en Python de un sistema de **reconocimiento facial** (propuesta de mejora)

---

## 🧰 Tecnologías usadas

- Visual Basic .NET
- Excel como base de datos centralizada
- Windows Forms
- iTextSharp para PDF

---

## 🛠 Requisitos

- Sistema operativo Windows
- .NET Framework
- Microsoft Excel instalado
- Acceso de red si se usa la BD en otro equipo

---

## 📌 Estado actual

✅ Sistema funcional  
✅ Implementado en ambiente empresarial  
✅ Alta fiabilidad en registros y reportes  
✅ Documentado y validado

---

## 📞 Soporte

Para dudas, sugerencias o soporte técnico, puedes contactar al desarrollador (yo 😄).

📧 **ulisescorreag01@gmail.com**  
🔧 Disponible para colaboraciones o mejoras al sistema

---

## 📝 Licencia

Este proyecto es para uso personal/educativo y no tiene licencia formal.

