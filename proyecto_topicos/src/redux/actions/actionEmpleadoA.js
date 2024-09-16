import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const listarEmpleado = createAsyncThunk("empleado/listarEmpleado",
    async () => {
        try
        {      
            const resp = await axios.get('');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const obtenerEmpleado = createAsyncThunk("empleado/obtenerEmpleado",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const agregarEmpleado = createAsyncThunk("empleado/agregarEmpleado",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const eliminarEmpleado = createAsyncThunk("empleado/eliminarEmpleado",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editarEmpleado = createAsyncThunk("empleado/editarEmpleado",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put(``, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
