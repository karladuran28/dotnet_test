import { useParams } from 'react-router-dom';

const FormPage = () => {

  const { formularioId } = useParams();

  return (
    <div>
      <h2>Histórico de Registros, formulario: {formularioId}</h2>
    </div>
  )
}

export default FormPage