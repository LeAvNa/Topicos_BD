import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const listarCocteleria = createAsyncThunk("cocteleria/listarCocteleria",
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

export const obtenerCocteleria = createAsyncThunk("cocteleria/obtenerCocteleria",
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

export const agregarCocteleria = createAsyncThunk("cocteleria/agregarCocteleria",
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

export const eliminarCocteleria = createAsyncThunk("cocteleria/eliminarCocteleria",
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

export const editarCocteleria = createAsyncThunk("cocteleria/editarCocteleria",
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
