import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const listarProducto = createAsyncThunk("producto/listarProducto",
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

export const obtenerProducto = createAsyncThunk("producto/obtenerProducto",
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

export const agregarProducto = createAsyncThunk("producto/agregarProducto",
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

export const eliminarProducto = createAsyncThunk("producto/eliminarProducto",
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

export const editarProducto = createAsyncThunk("producto/editarProducto",
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
