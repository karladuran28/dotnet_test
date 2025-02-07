import axios from 'axios';

const API_URL = 'http://localhost:5001/api';

const api = axios.create({
  baseURL: API_URL,
});

// Obtener todos los formularios
export const obtenerFormularios = async () => {
  try {
    const response = await api.get('formularios');
    return response.data;
  } catch (error) {
    console.error('Error al obtener los formularios:', error);
    throw error;
  }
};

export const obtenerFormularioPorId = async (id) => {
  try {
    const response = await api.get(`formularios/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error al obtener el formulario:', error);
    throw error;
  }
};

export const obtenerInputPorId = async (id) => {
  try {
    const response = await api.get(`inputs/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error al obtener los inputs:', error);
    throw error;
  }
};

export const actualizarInput = async (id, nuevoNombre, nuevoTipoDato, nuevoEsObligatorio) => {
  try {
    const respuesta = await api.put(`inputs/${id}`, {
      nombre: nuevoNombre,
      tipoDato: nuevoTipoDato,
      esObligatorio: nuevoEsObligatorio
    }, {
      headers: {
        "Content-Type": "application/json"
      }
    });

    console.log("Input actualizado:", respuesta.data);
  } catch (error) {
    console.error("Error al actualizar el input", error);
  }
};

export const eliminarInput = async (id) => {
  try {
    await axios.delete(`inputs/${id}`);
    console.log("Input eliminado con éxito");
  } catch (error) {
    console.error("Error al eliminar el input", error);
  }
};