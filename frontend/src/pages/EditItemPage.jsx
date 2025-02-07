import { useParams } from 'react-router-dom';
import FormInputEditComponent from '../components/form-input-edit/form-input-edit.component';

const EditItemPage = () => {

  const { inputId } = useParams();

  return (
    <>
      <FormInputEditComponent 
        inputId={inputId}
      />
    </>
  )
}

export default EditItemPage