import { Routes, Navigate, Route } from 'react-router-dom'
import './App.css'
import HomePage from './pages/HomePage'
import FormPage from './pages/FormPage'
import EditFormPage from './pages/EditFormPage'
import EditItemPage from './pages/EditItemPage'

function App() {
  return (
    <>
      <h1>Gestión de Formularios</h1>
      <Routes>
        <Route path="/" element={<HomePage/>}/>
        <Route path="/formulario/view/:formularioId" element={<FormPage/>}/>
        <Route path="/formulario/edit/:formularioId" element={<EditFormPage/>}/>
        <Route path="/input/edit/:inputId" element={<EditItemPage/>}/>
        <Route path="/*" element={<Navigate to="/"/>}/>
      </Routes>
    </>
  )
}

export default App
