import { useEffect, useState } from "react"
import { obtenerFormularios } from "../../services/api";
import FormListItemComponent from "./form-list-item.component";

const FormListComponent = () => {

  const [Formularios, setFormularios] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    obtenerFormularios()
      .then(data => {
        setFormularios(data);
      })
      .catch(err => {
        setError('Hubo un error al obtener los formularios')
        console.err(error)
      })
  }, [])
  
  if (error) {
    return <div>Error: {error}</div>
  }

  return (
    <>
      {Formularios.map((form, index) => (
        <FormListItemComponent
          key={index}
          id={form.id}
          nombre={form.nombre}
        />
      ))}
    </>
  )
}

export default FormListComponent