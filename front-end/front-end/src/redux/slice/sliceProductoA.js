import { createSlice } from "@reduxjs/toolkit";
import { listarProducto, obtenerProducto } from '../actions/actionProductoA';

const initialState = {
  productos: [],
  producto: {},
  loading: false,
  error: null,
};

const ProductoASlice = createSlice({
  name: "getProducto",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarProducto.pending, (state) => {
        state.productos = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarProducto.fulfilled, (state, action) => {
        state.productos = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarProducto.rejected, (state, action) => {
        state.productos = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerProducto.pending, (state) => {
        state.producto = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerProducto.fulfilled, (state, action) => {
        state.producto = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerProducto.rejected, (state, action) => {
        state.producto = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getProductoAReducer = ProductoASlice.reducer;