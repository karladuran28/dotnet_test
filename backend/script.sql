USE formsdb;

INSERT INTO Formularios (Nombre)
VALUES ('Personas'), ('Mascotas');

INSERT INTO Inputs (FormularioId, Nombre, TipoDato, EsObligatorio)
VALUES (1, 'Nombre', 1, 1), (1, 'Apellido', 1, 1);