import React, { useState, useEffect } from "react";
import { actualizarInput, obtenerInputPorId } from "../../services/api";

const FormInputEditComponent = ({inputId}) => {

  const [error, setError] = useState(null);
  const [newValues, setNewValues] = useState({
    nuevoNombre: '',
    nuevoTipoDato: '',
    nuevoEsObligatorio: false
  })

  // Cargando Input
  useEffect(() => {
    obtenerInputPorId(inputId)
      .then(data => {
        setNewValues({
          nuevoNombre: data.nombre,
          nuevoTipoDato: data.tipoDato,
          nuevoEsObligatorio: data.esObligatorio
        })
      })
      .catch(err => {
        setError('Hubo un error al obtener el input')
        console.err(error)
      })
  }, [inputId]);

  console.log('new values: ', newValues)

  // Actualizando Input
  const handleActualizar = async (e) => {
    e.preventDefault();
    actualizarInput(inputId, newValues.nombre, newValues.nuevoTipoDato, newValues.nuevoEsObligatorio)
    .then( data => {
      console.log('input actualizado: ', data)
    })
    .catch(err => {
      setError('Hubo un error al actualizar el input')
      console.err(error)
    })
  };

  return (
    <form onSubmit={handleActualizar} className="form-input-edit-container">
      <h2 className="text-lg font-semibold mb-2">Modificar Input</h2>
      <label className="block mb-2">Nombre:</label>
      <input
        type="text"
        value={newValues?.nombre}
        onChange={(e) => setNewValues({ ...newValues, nombre: e.target.value })}
        className=""
      />
      <label className="block mb-2">Tipo de Dato:</label>
      <input
        type="text"
        value={newValues?.tipoDato}
        onChange={(e) => setNewValues({ ...newValues, tipoDato: e.target.value })}
        className=""
      />
      <label className="block mb-2">
        <input
          type="checkbox"
          checked={newValues?.esObligatorio}
          onChange={(e) => setNewValues({ ...newValues, esObligatorio: e.target.checked })}
          className=""
        />
        Es obligatorio
      </label>
      <br />
      <button
        type="submit"
        className=""
      >
        Guardar Cambios
      </button>
    </form>
  )
}

export default FormInputEditComponent