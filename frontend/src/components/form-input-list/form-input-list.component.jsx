import { Link } from "react-router-dom"

const FormInputListComponent = ({inputList}) => {

  // Esto debería de obtenerse desde el backend
  const dataTypes = {1: 'String', 2: 'Entero', 3: 'Fecha', 4: 'Booleano', 5: 'Flotante'}

  return (
    <>
    <table className="form-input-list-table">
      <tbody>
        <tr>
          {/* Esto debe ser dinámico */}
          <th>Id</th>
          <th>Nombre</th>
          <th>Tipo de Dato</th>
          <th>Requerido</th>
          <th>Acción</th>
        </tr>
        {inputList?.map((input, index) => (
          <tr key={index}>
            <td>{input.id}</td>
            <td>{input.nombre}</td>
            <td>{dataTypes[input.tipoDato]}</td>
            <td>{input.esObligatorio ? 'Sí' : 'No'}</td>
            <td>
              <div>
                <Link to={`/input/edit/${input.id}`}>
                  <button>Modificar</button>
                </Link>
              </div>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
    </>
  )
}

export default FormInputListComponent