import { Link } from "react-router-dom"

const FormListItemComponent = ({id, nombre}) => {

  return (
    <div className="form-list-item">
      <div className="form-list-item-title">{`[${id}]`} {nombre}</div>
      <div className="form-list-item-btnbox">
        <Link className="form-list-item-link" to={`/formulario/view/${id}`}>
          <button>Registros</button>
        </Link>
        <Link className="form-list-item-link" to={`/formulario/edit/${id}`}>
          <button>Modificar Formulario</button>
        </Link>
      </div>
    </div>
  )
}

export default FormListItemComponent