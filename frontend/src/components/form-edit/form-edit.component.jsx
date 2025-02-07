import { useEffect, useState } from "react";
import { obtenerFormularioPorId } from "../../services/api";
import FormInputListComponent from "../form-input-list/form-input-list.component";

const FormEditComponent = ({id}) => {

  const [formulario, setFormulario] = useState(null)
  const [nombreFormulario, setNombreFormulario] = useState('')
  const [error, setError] = useState(null);

  useEffect(() => {
      obtenerFormularioPorId(id)
        .then(data => {
          setFormulario(data);
        })
        .catch(err => {
          setError('Hubo un error al obtener el formulario')
          console.err(error)
        })
    }, [])

    useEffect(() => {
      setNombreFormulario(formulario?.nombre)
    }, [formulario])
    

  if (error) {
    return <div>Error: {error}</div> 
  }

  return (
    <div>
      <div className="form-edit-contentbox">
        <div className="form-edit-content-editname">
          <h3> Id: {formulario?.id}</h3>
          <div className="form-edit-content-editname-der">
            <h3>Nombre:</h3>
            {!!nombreFormulario && 
              <input 
                type="text" 
                value={nombreFormulario} 
                readOnly={!!nombreFormulario}
              />
            }
            <button>Modificar</button>
          </div>
        </div>
        <h3>Inputs</h3>
        {formulario?.inputs.length 
        ? 
          <FormInputListComponent
            inputList={formulario?.inputs} 
          />
        : 
          <div>No contiene inputs</div>
        }
      </div>
      <br/>
      <div>
        <button>Añadir Input</button>
      </div>
    </div>
  )
}

export default FormEditComponent