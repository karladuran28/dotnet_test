import { useParams } from 'react-router-dom';
import FormEditComponent from '../components/form-edit/form-edit.component';

const EditFormPage = () => {

  const { formularioId } = useParams();

  return (
    <>
      <h2>Modificación</h2>
      <FormEditComponent
        id={formularioId}
      />
    </>
  )
}

export default EditFormPage